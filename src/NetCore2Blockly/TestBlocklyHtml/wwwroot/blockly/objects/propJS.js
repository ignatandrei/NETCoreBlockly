Blockly.Blocks['modifyproperty'] = {
            init: function () {
                this.appendDummyInput()
                    .appendField("Modify ");
                this.appendValueInput("ObjectToChange")
                    .setCheck(null)
                    .setAlign(Blockly.ALIGN_CENTRE)
                    .appendField(new Blockly.FieldLabelSerializable("object"), "objectName");
                this.appendValueInput("PropertyName")
                    .setCheck(null)
                    .setAlign(Blockly.ALIGN_RIGHT)
                    .appendField(new Blockly.FieldLabelSerializable(",property"), "prop");
                this.appendValueInput("NewValue")
                    .setCheck(null)
                    .setAlign(Blockly.ALIGN_RIGHT)
                    .appendField(new Blockly.FieldLabelSerializable("toValue"), "newValue");
                this.setInputsInline(true);
                this.setPreviousStatement(true, null);
                this.setNextStatement(true, null);
                this.setTooltip("");
                this.setHelpUrl("");
            }
        };
        Blockly.JavaScript['modifyproperty'] = function (block) {
            var value_objecttochange = Blockly.JavaScript.valueToCode(block, 'ObjectToChange', Blockly.JavaScript.ORDER_ATOMIC);
            var value_propertyname = Blockly.JavaScript.valueToCode(block, 'PropertyName', Blockly.JavaScript.ORDER_ATOMIC);
            var value_newvalue = Blockly.JavaScript.valueToCode(block, 'NewValue', Blockly.JavaScript.ORDER_ATOMIC);
            var code = value_objecttochange + "[" + value_propertyname + ']=' + value_newvalue + ";";
            return code;
        };
        Blockly.Blocks['getproperty'] = {
            init: function () {
                this.appendDummyInput()
                    .appendField("Get from");
                this.appendValueInput("ObjectToChange")
                    .setCheck(null)
                    .setAlign(Blockly.ALIGN_CENTRE)
                    .appendField(new Blockly.FieldLabelSerializable("object"), "objectName");
                this.appendValueInput("PropertyName")
                    .setCheck(null)
                    .setAlign(Blockly.ALIGN_RIGHT)
                    .appendField(new Blockly.FieldLabelSerializable("property"), "prop");
                this.setInputsInline(true);
                this.setOutput(true, null)
                //this.setTooltip("");
                //this.setHelpUrl("");
            }

        };
        Blockly.JavaScript['getproperty'] = function (block) {
            var value_objecttochange = Blockly.JavaScript.valueToCode(block, 'ObjectToChange', Blockly.JavaScript.ORDER_ATOMIC);
            
			
			
			var value_propertyname = Blockly.JavaScript.valueToCode(block, 'PropertyName', Blockly.JavaScript.ORDER_ATOMIC);

            var code = '(function(t){ if (typeof t === "string") return JSON.parse(t);  return t;}('+value_objecttochange+"))[" + value_propertyname + ']';
            
            return [code, Blockly.JavaScript.ORDER_NONE];
        };

		