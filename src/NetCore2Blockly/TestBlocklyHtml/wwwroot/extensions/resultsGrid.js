
var dataObject = [];
var objectsForGrid = [];
var hot;
function initGrid(gridElement) {
    //console.log(gridElement);
    hot = new gridjs.Grid({
        columns: ['Step'],
        data: [['next steps']]

    }).render(gridElement);
}
function AddStringToGrid(value) {
    if (value.startsWith("{") && value.endsWith("}")) {
        try {
            var obj = JSON.parse(value);
            objectsForGrid.push(obj);
        }
        catch(err)  {
            //do nothing
        }
    };
    if (value.startsWith("[") && value.endsWith("]")) {
        try {
            var arr = JSON.parse(value);
            for (var i = 0; i < arr.length; i++) {
                objectsForGrid.push(arr[i]);
            };
        }
        catch(err) {
            //do nothing
        }

    };

}
function AddDataToGrid(value, gridElement) {
    dataObject.push([value]);
    gridElement.innerHTML = '';
    hot.updateConfig({ data: dataObject });
    hot.forceRender();
    //window.alert(JSON.stringify(value) + typeof value);
    if (typeof value === 'string') {
        AddStringToGrid(value);
        return;
    }
    if (typeof value === 'object') {
        AddStringToGrid(JSON.stringify(value));
        return;
    }
}
function ClearDataGrid() {
    dataObject = [];
    objectsForGrid = [];
    if (hot != null) {
        hot.updateConfig({
            columns: ['Step'],
            data: [['next steps']]
        });
        hot.forceRender();
    }

}
function FinishGrid() {

    if (objectsForGrid.length == 0)
        return;

    var headers = [];
    var obj = objectsForGrid;
    for (var i = 0; i < obj.length; i++) {
        var data = obj[i];
        headers.push(...Object.keys(data));

    }
    var mySet = new Set(headers);
    headers = Array.from(mySet);

    var fullData = [];
    for (var i = 0; i < obj.length; i++) {
        var data = obj[i];
        //console.log(data);
        var res = [i + 1];
        for (var p = 0; p < headers.length; p++) {
            var key = headers[p];
            
            //console.log(`${key} ${data && data.hasOwnProperty(key)} `)
            if (data && data.hasOwnProperty(key)) {
                var val = data[key];
                if (typeof val === "object")
                    res.push(JSON.stringify(val));
                else
                    res.push(val);
            }
            else
                res.push('');
        }
        fullData.push(res);
    }
    headers.splice(0, 0, "Nr");
    hot.updateConfig({
        columns: headers,
        data: fullData
    });
    hot.forceRender();


}

