/*
 * Block that display the current date time
 * @Author: Popescu Ionut Cosmin (cosmin.popescu93@gmail.com)
 * https://github.com/cosminpopescu14
 */
Blockly.Blocks['displayCurrentDate'] = {
    init: function () {
        this.appendDummyInput()
            .appendField("Current Date");
        this.appendDummyInput()
            .appendField('Pick date format:')
            .appendField(new Blockly.FieldDropdown([
                ['Unix format', 'unix'],
                ['ISO format', 'iso'],
                ['Human format', 'human']
            ]), 'dateFormat');

        this.setOutput(true, null);
        this.setColour(100);
        this.setTooltip('Show current date.');
        this.setHelpUrl('https://www.w3schools.com/jsref/jsref_obj_date.asp');

    }
}
const dateFormats = {
    UNIX: 'unix',
    ISO: 'iso',
    HUMAN: 'human'
}

Blockly.JavaScript['displayCurrentDate'] = block => {
    const dropdownOption = block.getFieldValue('dateFormat');
    console.log(dropdownOption);

    let operation = ''
    switch (dropdownOption) {

        case dateFormats.HUMAN:
            operation = `displayDateFormatted(${dateFormats.HUMAN})`;
            break;
        case dateFormats.ISO:
            operation = `displayDateFormatted(${dateFormats.ISO})`;
            break;
        case dateFormats.UNIX:
            operation = `displayDateFormatted(${dateFormats.UNIX})`;
            break;

        default:
            console.log('Date time format not suported')
    }
    console.log(operation);

    let code = operation;
    return [code, Blockly.JavaScript.ORDER_NONE];
}

function displayDateFormatted(format = '') {

    switch (format) {
        case 'human':
            displayDateCurrentAsHuman();
            break;
        case 'iso':
            displayDateCurrentAsIso();
            break;
        case 'unix':
            displayDateCurrentAsUnix();
            break;
        default:
            console.log('Date time format not suported')
    }
}
//https://www.toptal.com/software/definitive-guide-to-datetime-manipulation
let displayDateCurrentAsHuman = () => {

    //undefined - get the date format form user browser.
    let today = new Date().toLocaleDateString(undefined, {
        day: 'numeric',
        month: 'numeric',
        year: 'numeric',
        hour: '2-digit',
        minute: '2-digit'
    });

    console.log(today);
    return today;
}

let displayDateCurrentAsIso = () => {
    let today = new Date().toISOString();
    return today;
}

let displayDateCurrentAsUnix = () => {
    return Date.now();
}

