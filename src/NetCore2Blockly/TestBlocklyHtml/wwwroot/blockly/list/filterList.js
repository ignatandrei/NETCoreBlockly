Blockly.Blocks['filterlist'] = {
  init: function() {
    this.appendDummyInput()
        .appendField("filterList");
    this.appendValueInput("LIST")
        .setCheck("Array");
        
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
  var list = Blockly.JavaScript.valueToCode(block, 'LIST',
      Blockly.JavaScript.ORDER_MEMBER) || '[]';
	  
  var value_logic = Blockly.JavaScript.valueToCode(block, 'Logic', Blockly.JavaScript.ORDER_ATOMIC);
  if(typeof value_logic === 'string')// remove '
	  value_logic = value_logic.substr(1,value_logic.length-2);
	  
  var code = '';
  code += list + '.filter(function (item){ return ' + value_logic +';})';
  code += '';
  
  return [code, Blockly.JavaScript.ORDER_FUNCTION_CALL];
};