Blockly.Blocks['filterlist'] = {
  init: function() {
    this.appendDummyInput()
        .appendField("filterList");
    this.appendValueInput("list")
        .setCheck("Array")
        .appendField("List");
    this.appendValueInput("Logic")
        .setCheck("String")
        .appendField("item=>");
    this.setInputsInline(true);
    this.setOutput(true, "Array");
    this.setColour(230);
 this.setTooltip("");
 this.setHelpUrl("");
  }
};

Blockly.JavaScript['filterlist'] = function(block) {
  var value_list = Blockly.JavaScript.valueToCode(block, 'list', Blockly.JavaScript.ORDER_ATOMIC);
  var value_logic = Blockly.JavaScript.valueToCode(block, 'Logic', Blockly.JavaScript.ORDER_ATOMIC);

  var code = '\n';
  return [code, Blockly.JavaScript.ORDER_FUNCTION_CALL];
};