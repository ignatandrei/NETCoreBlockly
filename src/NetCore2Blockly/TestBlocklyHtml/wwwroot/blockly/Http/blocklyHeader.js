Blockly.Blocks['headersbeforehttp'] = {
  init: function() {
    this.appendDummyInput()
        .appendField("Add Headers");
    this.appendValueInput("HttpDomain")
        .setCheck("String")
        .appendField("Domain");
    this.appendValueInput("HeaderName")
        .setCheck("String")
        .appendField("Header Name");
    this.appendValueInput("HeaderValue")
        .setCheck("String")
        .appendField("Header Value");
	this.setPreviousStatement(true, null);
    this.setNextStatement(true, null);
    //this.setColour(230);
 //this.setTooltip("");
 //this.setHelpUrl("");
  }
};
Blockly.JavaScript['headersbeforehttp'] = function(block) {
  var value_httpdomain = Blockly.JavaScript.valueToCode(block, 'HttpDomain', Blockly.JavaScript.ORDER_ATOMIC)||'(localSite)';
  var value_headername = Blockly.JavaScript.valueToCode(block, 'HeaderName', Blockly.JavaScript.ORDER_ATOMIC);
  var value_headervalue = Blockly.JavaScript.valueToCode(block, 'HeaderValue', Blockly.JavaScript.ORDER_ATOMIC);
  
  var code = 'alert("a" + JSON.stringify(headersForDomain)+"a");\n';
  code +='{\n';
  code +='if(!(' + value_httpdomain + ' in headersForDomain))\n';
  code +='{\n';
  code +='headersForDomain[' + value_httpdomain +']=[];\n';
  code +='};\n';
  code +='var arr = headersForDomain[' + value_httpdomain +'];\n';
  code +='arr.push({name:' + value_headername +', value:'+value_headervalue+'});\n';
  code +='//alert("a" + JSON.stringify(arr)+"a");\n';
  code +='//alert("a" + JSON.stringify(headersForDomain[' + value_httpdomain +'])+"a");\n';
  code +='};\n';
  return code;
};