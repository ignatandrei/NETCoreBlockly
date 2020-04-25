Blockly.Blocks['exportfile'] = {
    init: function () {
        this.appendDummyInput()
            .appendField("ExportToFile");
        this.appendValueInput("fileName")
            .setCheck(null)
            .appendField("FileName");
        this.appendValueInput("contentFile")
            .setCheck(null)
            .appendField("Content");
        this.appendValueInput("convertToByte")
            .setCheck("Boolean")
            .appendField("ConvertToByteFromBase64");
        this.setInputsInline(true);
        this.setPreviousStatement(true, null);
        this.setNextStatement(true, null);
        this.setColour(230);
        this.setTooltip("");
        this.setHelpUrl("");
    }
};

Blockly.JavaScript['exportfile'] = function (block) {

    var value_filename = Blockly.JavaScript.valueToCode(block, 'fileName', Blockly.JavaScript.ORDER_ATOMIC);
    var value_contentfile = Blockly.JavaScript.valueToCode(block, 'contentFile', Blockly.JavaScript.ORDER_ATOMIC);
    var value_converttobyte = Blockly.JavaScript.valueToCode(block, 'convertToByte', Blockly.JavaScript.ORDER_ATOMIC);
    
    var code = 'exportToFile('+ value_filename+','+value_contentfile+','+ value_converttobyte + ')';
    return code;
};
const exportToFile = function (nameFile, content, toByte) {

    try {
        var isFileSaverSupported = !!new Blob;
    } catch (e) {
        window.alert('file saving not supported');
        return;
    }


    var blob ;
    
    if (toByte) {
        blob = b64toBlob(content);
    }
    else {
        blob = new Blob([content], { type: "text/plain;charset=utf-8" });
    }    
    saveAs(blob, nameFile);    
    return nameFile;
}
const b64toBlob = (b64Data, contentType = '', sliceSize = 512) => {
    const byteCharacters = atob(b64Data);
    const byteArrays = [];

    for (let offset = 0; offset < byteCharacters.length; offset += sliceSize) {
        const slice = byteCharacters.slice(offset, offset + sliceSize);

        const byteNumbers = new Array(slice.length);
        for (let i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }

        const byteArray = new Uint8Array(byteNumbers);
        byteArrays.push(byteArray);
    }

    const blob = new Blob(byteArrays, { type: contentType });
    return blob;
}