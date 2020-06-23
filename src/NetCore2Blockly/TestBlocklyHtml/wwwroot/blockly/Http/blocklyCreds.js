Blockly.Blocks['credsforhttp'] = {
    init: function () {
        this.appendDummyInput()
            .appendField("Http with Creds");
        this.appendValueInput("HttpDomain")
            .setCheck("String")
            .appendField("Domain");
        this.appendValueInput("WithCreds")
            .setCheck("Boolean")
            .appendField("With Creds ?");
        this.setPreviousStatement(true, null);
        this.setNextStatement(true, null);
        //this.setColour(230);
        //this.setTooltip("");
        //this.setHelpUrl("");
    }
};
Blockly.JavaScript['credsforhttp'] = function (block) {
    var value_httpdomain = Blockly.JavaScript.valueToCode(block, 'HttpDomain', Blockly.JavaScript.ORDER_ATOMIC) || '(localSite)';
    var value_headername = Blockly.JavaScript.valueToCode(block, 'WithCreds', Blockly.JavaScript.ORDER_ATOMIC);
    var code = 'withCredsForDomain[' + value_httpdomain + ']=' + value_headername + ';\n';
    return code;
};
