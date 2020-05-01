Blockly.Blocks['httprequest'] = {
    init: function () {
        this.appendDummyInput()
            .appendField(new Blockly.FieldDropdown([["JSON", "JSON"], ["Text", "Text"]]), "TypeOutput")
            .appendField("HttpRequest");
        this.appendValueInput("TheUrl")
            .setCheck(null)
            .appendField(new Blockly.FieldDropdown([["GET", "GET"], ["POST", "POST"]]), "TypeRequest")
            .appendField("URL");
        this.appendValueInput("Data")
            .setCheck(null)
            .appendField("Data");
        this.setOutput(true, null);
        //this.setColour(230);
        //this.setTooltip("");
        //this.setHelpUrl("");
    }
};

Blockly.JavaScript['httprequest'] = function (block) {
    var dropdown_typeoutput = block.getFieldValue('TypeOutput');
    var dropdown_typerequest = block.getFieldValue('TypeRequest');
    var value_theurl = Blockly.JavaScript.valueToCode(block, 'TheUrl', Blockly.JavaScript.ORDER_ATOMIC);
    var value_data = Blockly.JavaScript.valueToCode(block, 'Data', Blockly.JavaScript.ORDER_ATOMIC);
    // TODO: Assemble JavaScript into code variable.
    var operation = '';
    switch (dropdown_typerequest.toString()) {
        case "GET":
            operation = "(function(url){ var res=JSON.parse(getXhr(url));alert('andrei'+res.statusOK); if(res.statusOK) return res.text;errHandler(JSON.stringify(res)); throw res;}("+ value_theurl +") )";
            break;
        case "POST":
            throw 'not implemented';
            break;
    }
    
    var code = operation;
    switch (dropdown_typeoutput) {
        case "JSON":
            code = "JSON.parse(" + code + ')';
    }

    return [code, Blockly.JavaScript.ORDER_NONE];
};