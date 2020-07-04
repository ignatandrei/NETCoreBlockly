const playwright = require('playwright');
console.log('start');
(async () => {
    for (const browserType of ['chromium'/*, 'firefox', 'webkit'*/]) {
      const browser = await playwright[browserType].launch();
      const context = await browser.newContext();
      var page = await context.newPage();
      await page.goto('https://netcoreblockly.herokuapp.com/');
      page = await context.newPage();
      await page.goto('https://netcoreblockly.herokuapp.com/blockly.html');

      await page.keyboard.press('Escape');
      //await clickExecute('firstDemo',page,browserType);
      //const text = await page.evaluate(() => Array.from(document.querySelectorAll('#results > li'), element => element));//.textContent
      const allTests = await page.$$('#results > li');
      console.log(allTests.length);
      for(var i=0;i<allTests.length;i++){
        var nr= (i+1).toString().padStart(3,'0');
        var li  = allTests[i];
        await li.scrollIntoViewIfNeeded();
        var text=await li.$("a");
        text=await text.getProperty("innerHTML");
        text = await text.jsonValue();
        text = "Test_" + nr +"_"+text;
        //console.log(text);
        await li.click();
        await sleep(1000);
        await clickExecute(text,page,browserType);
        break;
      }
      
      
            //await text[3].click();
      //.await clickExecute('firstDemo',page,browserType);
      // const handle = await page.$('//ul[@id="results"]/li');
      // console.log(handle);
      // var prop=await handle.getProperty("value");
      // console.log(await prop.jsonValue());
      await browser.close();
    }
  })();

  async function clickExecute(name, page, browserType){
    console.log(`start ${name} ${browserType}`);
    await page.click('text=E X E C U T E');

    await sleep(5000);
    const handle = await page.$('//textarea[@id="output"]');
    await handle.focus();
    //console.log(handle);
    var x=await handle.getProperty("value");
    var  text = (await x.jsonValue());
    if(!text.includes("Program complete"))
        throw `error in  ${name}`;

    await page.screenshot({ path: `${name}-${browserType}.png` });

  }
  function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
  }