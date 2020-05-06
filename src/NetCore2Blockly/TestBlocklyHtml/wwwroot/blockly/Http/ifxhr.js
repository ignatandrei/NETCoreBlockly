Blockly.Blocks['blockxhrresult'] = {
  init: function() {
    this.appendDummyInput()
        .appendField("XHR interpreter");
    this.appendValueInput("XhrValue")
        .setCheck(null)
        .appendField("XhrValue");
    this.appendStatementInput("valueIfOK")
        .setCheck(null)
        .appendField("If ok");
    this.appendStatementInput("valueIfError")
        .setCheck(null)
        .appendField("if error");
    this.setPreviousStatement(true, null);
    this.setNextStatement(true, null);
    
 this.setTooltip("");
 this.setHelpUrl("");
  }
};
//inspired by Blockly.JavaScript['controls_if']
Blockly.JavaScript['blockxhrresult'] = function(block) {
  var code = '';
  var value_xhrvalue = Blockly.JavaScript.valueToCode(block, 'XhrValue', Blockly.JavaScript.ORDER_ATOMIC);
  //code= 'alert('+value_xhrvalue+');';
  var branchCode = Blockly.JavaScript.statementToCode(block, 'valueIfOK');
  
  
  code += 'if (JSON.parse(' + value_xhrvalue + ').statusOK) {\n' + branchCode + '}';

  branchCode = Blockly.JavaScript.statementToCode(block, 'valueIfError');
    code += ' else {\n' + branchCode + '};';
	//code= 'alert('+value_xhrvalue+');'+ '\n';
	return code+ '\n';
};