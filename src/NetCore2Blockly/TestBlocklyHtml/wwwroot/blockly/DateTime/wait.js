Blockly.Blocks['wait'] = {
    init: function() {
      this
			.appendValueInput('VALUE')            
            .appendField('wait secs');
          // .appendField("delay")
          // .appendField(new Blockly.FieldNumber(10, 0), "wait")
          // .appendField("secs");
      this.setPreviousStatement(true, null);
      this.setNextStatement(true, null);
      //this.setColour();
      //this.setTooltip('');
      //this.setHelpUrl('');
    }
  };

  Blockly.JavaScript['wait'] = function(block) {
    var number_wait = Blockly.JavaScript.valueToCode(block, 'VALUE', Blockly.JavaScript.ORDER_ATOMIC)|| '';    
    var code= 'waitTime('+ 	number_wait+');';
	return code;
  };