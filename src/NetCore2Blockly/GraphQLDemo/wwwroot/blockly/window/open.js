Blockly.Blocks['window_open'] = {
  
  init: function() {
    this.jsonInit({
      "message0": 'Open %1',
      "args0": [
        {
          "type": "input_value",
          "name": "TEXT"
        }
      ],
      "previousStatement": null,
      "nextStatement": null,
      "style": "text_blocks"
      
    });
  }
};
	

	
Blockly.JavaScript['window_open'] = function(block) {
  // Print statement.
  var msg = Blockly.JavaScript.valueToCode(block, 'TEXT',
      Blockly.JavaScript.ORDER_NONE) || '\'\'';
  return 'open(' + msg + ');\n';
};