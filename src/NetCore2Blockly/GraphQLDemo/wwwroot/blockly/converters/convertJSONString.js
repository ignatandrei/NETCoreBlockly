        Blockly.Blocks['converttojson'] = {
            init: function () {
                this.appendDummyInput()
                    .appendField("ConvertToJSON");
                this.appendValueInput("ValueToConvert")
                    .setCheck(null);
                this.setInputsInline(true);
                this.setOutput(true, null);
                this.setTooltip("Convert to JSON");
                this.setHelpUrl("");
            }
        };
        Blockly.JavaScript['converttojson'] = function (block) {
            var value_ValueToConvert = Blockly.JavaScript.valueToCode(block, 'ValueToConvert', Blockly.JavaScript.ORDER_ATOMIC);
            //value_ValueToConvert = value_ValueToConvert.replace(/(\r\n|\n|\r)/gm, "")
            const code = 'JSON.parse(' + value_ValueToConvert + ')';
            return [code, Blockly.JavaScript.ORDER_NONE];

        };

		        Blockly.Blocks['converttostring'] = {
            init: function () {
                this.appendDummyInput()
                    .appendField("ConvertToString");
                this.appendValueInput("ValueToConvert")
                    .setCheck(null);
                this.setInputsInline(true);
                this.setOutput(true, null);
                this.setTooltip("Convert to String");
                this.setHelpUrl("");
            }
        };
        Blockly.JavaScript['converttostring'] = function (block) {
            var value_ValueToConvert = Blockly.JavaScript.valueToCode(block, 'ValueToConvert', Blockly.JavaScript.ORDER_ATOMIC);
            var code = 'JSON.stringify(' + value_ValueToConvert + ')';
            return [code, Blockly.JavaScript.ORDER_NONE];
        };
