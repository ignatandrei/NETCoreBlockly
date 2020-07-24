Blockly.Blocks['azureTokenData'] = {
  init: function() {
    this.appendDummyInput()
        .appendField("Azure Token");
    this.appendValueInput("client_id")
        .setCheck(null)
        .appendField("client_id");
    this.appendValueInput("client_secret")
        .setCheck(null)
        .appendField("client_secret");
    this.appendValueInput("resource")
        .setCheck(null)
        .appendField("resource");
    this.appendValueInput("grant_type")
        .setCheck(null)
        .appendField("grant_type");
    this.setOutput(true, null);
    this.setColour(230);
 this.setTooltip("");
 this.setHelpUrl("");
  }
};

Blockly.JavaScript['azureTokenData'] = function(block) {
  
  var value_client_id = Blockly.JavaScript.valueToCode(block, 'client_id', Blockly.JavaScript.ORDER_ATOMIC);
  var value_client_secret = Blockly.JavaScript.valueToCode(block, 'client_secret', Blockly.JavaScript.ORDER_ATOMIC);
  var value_resource = Blockly.JavaScript.valueToCode(block, 'resource', Blockly.JavaScript.ORDER_ATOMIC);
  var value_grant_type = Blockly.JavaScript.valueToCode(block, 'grant_type', Blockly.JavaScript.ORDER_ATOMIC);
  
  var code = '{"client_id":'+ value_client_id;
  code+=',"client_secret":'+ value_client_secret;
  code+=',"resource":'+ value_resource;
  code+=',"grant_type":'+ value_grant_type;
  code+='}';
  
  return [code, Blockly.JavaScript.ORDER_NONE];
};

