Blockly.Blocks['displayCurrentDate'] = {
    init: function () {
        //this.appendField('Date representation of');
        this.setOutput(true, null);
        this.setColour(100);
        this.setTooltip('Show current date.');
        this.setHelpUrl('https://www.w3schools.com/jsref/jsref_obj_date.asp');

    }
}

Blockly.JavaScript['displayCurrentDate'] = () => {
   // let data = Blockly.JavaScript.valueToCode(block, 'VALUE', Blockly.JavaScript.ORDER_ATOMIC);
    let code = 'displayCurrentDate();'
    //return code;
    return [code, Blockly.JavaScript.ORDER_NONE];
}

//https://www.toptal.com/software/definitive-guide-to-datetime-manipulation
let displayCurrentDate = () => {

    //undefine - get the date format form user browser.
    let today = new Date().toLocaleDateString(undefined, {
        day: 'numeric',
        month: 'numeric',
        year: 'numeric',
        hour: '2-digit',
        minute: '2-digit'
    });

    console.log(today);
    return today
}