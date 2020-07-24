Blockly.Blocks['comment'] = {
  init: function() {
    this.appendValueInput("TEXT")
        .setCheck(null)
        .appendField("comment /* */")
        .appendField(new Blockly.FieldLabelSerializable(""), "NAME");
    //this.setOutput(true, null);
	  this.setPreviousStatement(true, null);
    this.setNextStatement(true, null);
 this.setTooltip("");
 this.setHelpUrl("");
  }
};

Blockly.JavaScript['comment'] = function(block) {
  // Print statement.
  var msg = Blockly.JavaScript.valueToCode(block, 'TEXT',
      Blockly.JavaScript.ORDER_ATOMIC) || '\'\'';
	
  var code= '/*\n' + msg+'\n*/;\n';
  return code;
};

