const playwright = require('playwright');
console.log('start');
(async () => {
    for (const browserType of ['chromium', 'firefox'/*, 'webkit'*/]) {
      const browser = await playwright[browserType].launch();
      const context = await browser.newContext();
      const page = await context.newPage();
      await page.goto('https://netcoreblockly.herokuapp.com/blockly.html');
      await page.keyboard.press('Escape');
      await clickExecute('firstDemo',page,browserType);

      
      await browser.close();
    }
  })();

  async function clickExecute(name, page, browserType){

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