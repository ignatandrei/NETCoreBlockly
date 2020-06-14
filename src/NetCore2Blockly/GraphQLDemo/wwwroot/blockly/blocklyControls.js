Blockly.Blocks['valuefromtext'] = {
  init: function() {
    this.appendDummyInput()
        .appendField("InputFromText");
    this.appendValueInput("IdOfText")
        .setCheck("String")
        .appendField("Text id");
	this.appendValueInput("ValueToObtain")
        .setCheck("String")
        .appendField("Property");
    this.setOutput(true, null);
    this.setColour(230);
 this.setTooltip("");
 this.setHelpUrl("");
  }
}
  
 Blockly.JavaScript['valuefromtext'] = function(block) {
  var value_idoftext = Blockly.JavaScript.valueToCode(block, 'IdOfText', Blockly.JavaScript.ORDER_ATOMIC);
  var value_valuetoobtain = Blockly.JavaScript.valueToCode(block, 'ValueToObtain', Blockly.JavaScript.ORDER_ATOMIC)||'"value"';
  var code = 'getIDProp('+ value_idoftext+','+ value_valuetoobtain+')';
  return [code, Blockly.JavaScript.ORDER_NONE];
};