Blockly.Blocks['DateFromText'] = {
    init: function() {
        this.appendValueInput('VALUE')            
            .appendField('Date from ');
        this.setOutput(true, null); 
		this.setHelpUrl('https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Date/parse#Date_Time_String_Format');
		
    }
}

Blockly.JavaScript['DateFromText'] = block => {
    let data = Blockly.JavaScript.valueToCode(block, 'VALUE', Blockly.JavaScript.ORDER_ATOMIC)|| '';
    //console.log(data);
	//console.log(data.length);
	//read about formats at https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Date/parse#Date_Time_String_Format
	//if(!(data.length ==12 || data.length ==21))// '' means 10+2 or 19+2
	//	throw " data should be yyyy-MM-dd or yyyy-MM-ddTHH:mm:ss";
	
	let code = 'Date.parse(' + data +')';
    return [code, Blockly.JavaScript.ORDER_NONE];
	
}