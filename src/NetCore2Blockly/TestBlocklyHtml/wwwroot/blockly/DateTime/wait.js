Blockly.Blocks['wait'] = {
    init: function() {
      this.appendDummyInput()
          .appendField("delay")
          .appendField(new Blockly.FieldNumber(10, 0), "wait")
          .appendField("in secs");
      this.setPreviousStatement(true, null);
      this.setNextStatement(true, null);
      //this.setColour();
      //this.setTooltip('');
      //this.setHelpUrl('');
    }
  };

  Blockly.JavaScript['wait'] = function(block) {
    var number_wait = block.getFieldValue('wait');
    delays = Number(number_wait);
    var code= 'waitTime('+ 	delays+');';
	return code;
  };