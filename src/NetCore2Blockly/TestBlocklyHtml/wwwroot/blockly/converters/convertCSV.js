Blockly.Blocks['convertcsv'] = {
    init: function () {
        this.appendDummyInput()
            .appendField("Convert CSV");
        this.appendValueInput("ArrayToConvert")
            .setCheck(null)
            .appendField("Array to convert");
        //this.setPreviousStatement(true, null);
        //this.setNextStatement(true, null);
        this.setOutput(true, null);
        this.setTooltip("");
        this.setHelpUrl("");
    }
};
Blockly.JavaScript['convertcsv'] = function (block) {
    var data = Blockly.JavaScript.valueToCode(block, 'ArrayToConvert', Blockly.JavaScript.ORDER_ATOMIC);
    var code = 'convertToCSV(' + data+')';
    //return code;
    return [code, Blockly.JavaScript.ORDER_NONE];
};

const convertCSV = function (arrayOrString) {
    
    
    let arr = typeof arrayOrString != 'object' ? JSON.parse(arrayOrString) : objArray;

    arr = [Object.keys(arr[0])].concat(arr)
    var data = arr.map(it => {
        return Object.values(it).toString()
    }).join('\n');
    console.log(data);
    return data;
}