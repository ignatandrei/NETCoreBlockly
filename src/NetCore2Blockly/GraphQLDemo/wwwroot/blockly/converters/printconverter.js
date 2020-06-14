Blockly.Blocks['text_print_return'] = {
  init: function() {
    this.appendValueInput("TEXT")
        .setCheck(null)
        .appendField("print return")
        .appendField(new Blockly.FieldLabelSerializable(""), "NAME");
    this.setOutput(true, null);
    
 this.setTooltip("");
 this.setHelpUrl("");
  }
};

Blockly.JavaScript['text_print_return'] = function(block) {
  // Print statement.
  var msg = Blockly.JavaScript.valueToCode(block, 'TEXT',
      Blockly.JavaScript.ORDER_ATOMIC) || '\'\'';
	
  var code= '(function(){window.alert(' + msg + ');\n;return (' + msg + ');}())\n';
  return [code, Blockly.JavaScript.ORDER_NONE];
};

