{
  "swagger": "2.0",
  "info": {
    "title": "TestDrupal",
    "description": "",
    "version": ""
  },
  "host": "127.0.0.1:8081",
  "schemes": [
    "http"
  ],
  "paths": {
    "/rest/users/": {
      "get": {
        "operationId": "users_list",
        "responses": {
          "200": {
            "description": ""
          }
        },
        "parameters": [],
        "tags": [
          "rest"
        ]
      },
      "post": {
        "operationId": "users_create",
        "responses": {
          "201": {
            "description": ""
          }
        },
        "parameters": [
          {
            "name": "data",
            "in": "body",
            "schema": {
              "type": "object",
              "properties": {
                "username": {
                  "description": "Wow",
                  "type": "string"
                },
                "email": {
                  "description": "",
                  "type": "string"
                },
                "forAdmin": {
                  "description": "Next",
                  "type": "boolean"
                }
              },
              "required": [
                "username"
              ]
            }
          }
        ],
        "consumes": [
          "application/json"
        ],
        "tags": [
          "rest"
        ]
      }
    },
    "/rest/users/{id}/": {
      "get": {
        "operationId": "users_read",
        "responses": {
          "200": {
            "description": ""
          }
        },
        "parameters": [
          {
            "name": "id",
            "required": true,
            "in": "path",
            "description": "id of the user",
            "type": "integer"
          }
        ],
        "tags": [
          "rest"
        ]
      },
      "put": {
        "operationId": "users_update",
        "responses": {
          "200": {
            "description": ""
          }
        },
        "parameters": [
          {
            "name": "id",
            "required": true,
            "in": "path",
            "description": "again id.",
            "type": "integer"
          },
          {
            "name": "data",
            "in": "body",
            "schema": {
              "type": "object",
              "properties": {
                "username": {
                  "description": "data",
                  "type": "string"
                },
                "email": {
                  "description": "",
                  "type": "string"
                },
                "forAdmin": {
                  "description": "mre.",
                  "type": "boolean"
                }
              },
              "required": [
                "username"
              ]
            }
          }
        ],
        "consumes": [
          "application/json"
        ],
        "tags": [
          "rest"
        ]
      },
      "patch": {
        "operationId": "users_partial_update",
        "responses": {
          "200": {
            "description": ""
          }
        },
        "parameters": [
          {
            "name": "id",
            "required": true,
            "in": "path",
            "description": "my ud",
            "type": "integer"
          },
          {
            "name": "data",
            "in": "body",
            "schema": {
              "type": "object",
              "properties": {
                "username": {
                  "description": "this is desc",
                  "type": "string"
                },
                "email": {
                  "description": "",
                  "type": "string"
                },
                "forAdmin": {
                  "description": "my admin",
                  "type": "boolean"
                }
              }
            }
          }
        ],
        "consumes": [
          "application/json"
        ],
        "tags": [
          "rest"
        ]
      },
      "delete": {
        "operationId": "users_delete",
        "responses": {
          "204": {
            "description": ""
          }
        },
        "parameters": [
          {
            "name": "id",
            "required": true,
            "in": "path",
            "description": "the id",
            "type": "integer"
          }
        ],
        "tags": [
          "rest"
        ]
      }
    },
    "/swagger/": {
      "get": {
        "operationId": "list",
        "responses": {
          "200": {
            "description": ""
          }
        },
        "parameters": [],
        "tags": [
          "swagger"
        ]
      }
    }
  },
  "securityDefinitions": {
    "basic": {
      "type": "basic"
    }
  }
}