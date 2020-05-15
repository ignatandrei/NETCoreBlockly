https://gist.github.com/mark-friedman/48f43a9b62b1c8ad029a75d4b4e61f31
Blockly.JavaScript['object_from_json'] = function(block) {
  const value_json = Blockly.JavaScript.valueToCode(block, 'JSON', Blockly.JavaScript.ORDER_ATOMIC);
  // TODO: Maybe check that the parsed value is actually an object.
  const code = `JSON.parse(${value_json})`;
  return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['object_to_json'] = function(block) {
  const value_object = Blockly.JavaScript.valueToCode(block, 'object', Blockly.JavaScript.ORDER_ATOMIC);
  const code = `JSON.stringify(${value_object})`;
  return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['object_get'] = function(block) {
  const text_field_name = block.getFieldValue('field_name');
  const value_object = Blockly.JavaScript.valueToCode(block, 'object', Blockly.JavaScript.ORDER_ATOMIC);
  const code = `${value_object}['${text_field_name}']`;
  return [code, Blockly.JavaScript.ORDER_NONE];
};

Blockly.JavaScript['object_set'] = function(block) {
  const text_field_name = block.getFieldValue('field_name');
  const value_object_field = Blockly.JavaScript.valueToCode(block, 'object_field', Blockly.JavaScript.ORDER_ATOMIC);
  const value_value_field = Blockly.JavaScript.valueToCode(block, 'value_field', Blockly.JavaScript.ORDER_ATOMIC);
  return `${value_object_field}['${text_field_name}'] = ${value_value_field};\n`;
};

Blockly.JavaScript['object_create'] = function(block) {
  if (!block.numFields) {
    return ['{}', Blockly.JavaScript.ORDER_NONE];
  }
  let fieldInitCode = '';
  for (let i = 1; i <= block.numFields; i++) {
    const fieldName = block.getFieldValue('field' + i);
    const fieldValue = Blockly.JavaScript.valueToCode(block, 'field_input' + i, Blockly.JavaScript.ORDER_ATOMIC);
    fieldInitCode += `"${fieldName}": ${fieldValue}, `
  }
  const code = `{ ${fieldInitCode} }`;
  return [code, Blockly.JavaScript.ORDER_NONE];
};


const CUSTOM_OBJECT_FROM_JSON_BLOCK_NAME = 'object_from_json';
const CUSTOM_OBJECT_TO_JSON_BLOCK_NAME = 'object_to_json';
const CUSTOM_OBJECT_GET_BLOCK_NAME = 'object_get';
const CUSTOM_OBJECT_SET_BLOCK_NAME = 'object_set';
const CUSTOM_OBJECT_CREATE_BLOCK_NAME = 'object_create';
const CUSTOM_OBJECT_MUTATOR_FIELD_BLOCK_NAME = 'object_field';
const CUSTOM_OBJECT_CREATE_MUTATOR_TOP_BLOCK_NAME = 'object_create_mutator_top';
const CUSTOM_OBJECT_BLOCK_COLOR = '#F99EA3';

const getMessage = (msgName, ...arg) => {
  const MESSAGES = {
    object_from_json: "get object from JSON %1",
    object_from_json_tooltip: "Create object from JSON string.",
    object_to_json: "generate JSON from object %1",
    object_to_json_tooltip: "Save object as a JSON string.",
    object_get_json: "get property %1 %2 of object %3",
    object_get_json_tooltip: "Get a property of an object.",
    object_set_json: "set property %1 %2 of object %3 to %4",
    object_set_json_tooltip: "Set a property of an object.",
    object_create: "create object",
    object_create_tooltip: "Create a new object, optionally with some property values.",
    object_field_name: "property name",
  };
  return MESSAGES[msgName];
};

const objectFromJSONBlockDef = {
  "type": "object_from_json",
  "message0": getMessage('object_from_json'),
  "args0": [
    {
      "type": "input_value",
      "name": "JSON",
      "check": "String"
    }
  ],
  "output": "Object",
  "colour": CUSTOM_OBJECT_BLOCK_COLOR,
  "tooltip": getMessage('object_from_json_tooltip'),
  "helpUrl": "http://www.json.org/"
};

Blockly.Blocks[CUSTOM_OBJECT_FROM_JSON_BLOCK_NAME] = {
  init: function () {
    this.jsonInit(objectFromJSONBlockDef);
  }
};

const objectToJSONBlockDef = {
    "type": "object_to_json",
    "message0": getMessage('object_to_json'),
    "args0": [
      {
        "type": "input_value",
        "name": "object",
        "check": "Object"
      }
    ],
    "output": null,
    "colour": CUSTOM_OBJECT_BLOCK_COLOR,
    "tooltip": getMessage('object_to_json_tooltip'),
  "helpUrl": "http://www.json.org/"
};

Blockly.Blocks[CUSTOM_OBJECT_TO_JSON_BLOCK_NAME] = {
  init: function () {
    this.jsonInit(objectToJSONBlockDef);
  }
};

const objectGetBlockDef = {
    "type": "object_get",
    "message0": getMessage('object_get_json'),
    "args0": [
      {
        "type": "field_input",
        "name": "field_name",
        "text": "default"
      },
      {
        "type": "input_dummy"
      },
      {
        "type": "input_value",
        "name": "object",
        "check": "Object",
        "align": "RIGHT"
      }
    ],
    "output": null,
    "colour": CUSTOM_OBJECT_BLOCK_COLOR,
    "tooltip": getMessage('object_get_json_tooltip'),
    "helpUrl": ""
};

Blockly.Blocks[CUSTOM_OBJECT_GET_BLOCK_NAME] = {
  init: function () {
    this.jsonInit(objectGetBlockDef);
  }
};

const objectSetBlockDef =  {
  "type": "object_set",
  "message0": getMessage('object_set_json'),
  "args0": [
    {
      "type": "field_input",
      "name": "field_name",
      "text": getMessage('object_field_name'),
    },
    {
      "type": "input_dummy"
    },
    {
      "type": "input_value",
      "name": "object_field",
      "check": "Object",
      "align": "RIGHT"
    },
    {
      "type": "input_value",
      "name": "value_field",
      "align": "RIGHT"
    }
  ],
  "previousStatement": null,
  "nextStatement": null,
  "colour": CUSTOM_OBJECT_BLOCK_COLOR,
  "tooltip": getMessage('object_set_json_tooltip'),
  "helpUrl": ""
};


Blockly.Blocks[CUSTOM_OBJECT_SET_BLOCK_NAME] = {
  init: function () {
    this.jsonInit(objectSetBlockDef);
  }
};  

const objectCreateBlockDef = {
  "type": "object_create",
  "message0": getMessage('object_create'),
  "output": "Object",
  "mutator": "controls_create_mutator",
  "colour": 15,
  "tooltip": getMessage('object_create_tooltip'),
  "helpUrl": ""
};

Blockly.Blocks[CUSTOM_OBJECT_CREATE_BLOCK_NAME] = {
  init: function () {
    this.jsonInit(objectCreateBlockDef);
  }
};

const objectFieldBlockDef = {
  "type": "object_field",
  "message0": "%1 %2",
  "args0": [
    {
      "type": "field_input",
      "name": "field_name",
      "text": getMessage('object_field_name')
    },
    {
      "type": "input_value",
      "name": "field_value"
    }
  ],
  "previousStatement": null,
  "nextStatement": null,
  "colour": 15,
  "tooltip": "",
  "helpUrl": ""
};

Blockly.Blocks[CUSTOM_OBJECT_MUTATOR_FIELD_BLOCK_NAME] = {
  init: function () {
    this.jsonInit(objectFieldBlockDef);
  }
};

const objectCreateMutatorBlockDef = {
  "type": "object_create_mutator",
  "message0": getMessage('object_create'),
  "nextStatement": null,
  "colour": 15,
  "tooltip": getMessage('object_create_tooltip'),
  "helpUrl": ""
};

Blockly.Blocks[CUSTOM_OBJECT_CREATE_MUTATOR_TOP_BLOCK_NAME] = {
  init: function () {
    this.jsonInit(objectCreateMutatorBlockDef);
  }
};

const objectCreateMutator = {
  numFields: 0,
  fields: [],

  /**
   * Standard function for Mutator mixin. It's called to update the block based on contents of the mutator's XML
   * DOM element.
   */
  domToMutation: function(xmlElement) {
    this.fields = [];
    for (let i = 0, childNode; childNode = xmlElement.childNodes[i]; i++) {
      if (childNode.nodeName.toLowerCase() == 'field') {
        this.fields.push(childNode.getAttribute('name'));
      }
    }
    this.numFields = this.fields.length;
    this.updateShape();
  },

  /**
   * Standard function for Mutator mixin. It's called to generate the mutator's XML DOM element based on the content
   * of the block.
   */
  mutationToDom: function() {
    if (!this.numFields) {
      return null;
    }
    const container = document.createElement('mutation');
    container.setAttribute('num_fields', '' + this.numFields);
    for (let i = 0; i < this.fields.length; i++) {
      const field = document.createElement('field');
      field.setAttribute('name', this.fields[i]);
      container.appendChild(field);
    }
    return container;
  },

  /**
   * Standard function for Mutator mixin when the mutator uses the standard mutator UI. It's called to update the
   * block based on changes to the mutator's UI.
   */
  compose: function(topBlock) {
    let fieldBlock = topBlock.nextConnection && topBlock.nextConnection.targetBlock();
    this.numFields = 0;
    this.fields = [];
    let connectionsToRestore = [null];
    while (fieldBlock) {
      this.fields.push(fieldBlock.getFieldValue('field_name'));
      this.numFields++;
      connectionsToRestore.push(fieldBlock.savedConnection);
      fieldBlock = fieldBlock.nextConnection && fieldBlock.nextConnection.targetBlock();
    }
    this.updateShape();
    // Reconnect any child blocks.
    for (let i = 1; i <= this.numFields; i++) {
      Blockly.Mutator.reconnect(connectionsToRestore[i], this, 'field_input' + i);
    }
  },

  /**
   * Standard function for Mutator mixin when the mutator uses the standard mutator UI.  It's called to populate the
   * mutator UI.
   */
  decompose: function(workspace) {
    const topBlock = workspace.newBlock(CUSTOM_OBJECT_CREATE_MUTATOR_TOP_BLOCK_NAME);
    topBlock.initSvg();
    let connection = topBlock.nextConnection;
    for (let i = 0; i < this.fields.length; i++) {
      const fieldBlock = workspace.newBlock(CUSTOM_OBJECT_MUTATOR_FIELD_BLOCK_NAME);
      fieldBlock.initSvg();
      fieldBlock.setFieldValue(this.fields[i], 'field_name');
      connection.connect(fieldBlock.previousConnection);
      connection = fieldBlock.nextConnection;
    }
    return topBlock;
  },

  /**
   * Standard function for Mutator mixin when the mutator uses the standard mutator UI.  It's called on any changes to
   * the block and is generally used to keep track of input connections (by saving them with their corresponding mutator
   * blocks), so that if the mutator later causes changes to the block it can restore those input connections.
   *
   * We're also using this function to update the mutator block field name values if the user changes the name in the
   * block.
   */
  saveConnections: function(topBlock) {
    let fieldBlock = topBlock.nextConnection && topBlock.nextConnection.targetBlock();
    let i = 1;
    while (fieldBlock) {
      const input = this.getInput('field_input' + i);
      fieldBlock.savedConnection = input && input.connection.targetConnection;
      // Set mutator block field name from the corresponding 'real' Object.create block
      fieldBlock.setFieldValue(this.getFieldValue('field' + i), 'field_name');
      i++;
      fieldBlock = fieldBlock.nextConnection &&
        fieldBlock.nextConnection.targetBlock();
    }
  },

  updateShape: function() {
    // Delete everything.
    if (this.getInput('with')) {
      this.removeInput('with');
    }
    let i = 1;
    while (this.getInput('field_input' + i)) {
      this.removeInput('field_input' + i);
      i++;
    }
    // Rebuild block.
    if (this.numFields > 0) {
      this.appendDummyInput('with')
      .setAlign(Blockly.ALIGN_RIGHT)
      .appendField("with fields");
    }
    for (let i = 1; i <= this.numFields; i++) {
      const fieldName = this.fields[i - 1];
      this.appendValueInput("field_input" + i)
        .setCheck(null)
        .setAlign(Blockly.ALIGN_RIGHT)
        .appendField(new Blockly.FieldTextInput(fieldName), "field" + i);
    }
  },

};

Blockly.Extensions.registerMutator('controls_create_mutator', objectCreateMutator, null, ['object_field']);