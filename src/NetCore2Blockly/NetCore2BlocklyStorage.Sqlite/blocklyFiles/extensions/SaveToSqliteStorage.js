
var StorageHandler = function () {

    var arr = [];

    this.length = (function () {
        var href = '/blocklyStorageLength';
        let req = new XMLHttpRequest();
        req.open('GET', href, false);
        req.send(null);
        if (req.status === 200) {
            var res = req.responseText;
            //window.alert('length' + res);
            return res;
        }
        ////window.alert('length no answer' );
        return 0;
    })();


    this.get = function (key) {

        var exists = arr.filter(it => it.name == key);

        if (exists.length == 1)
            return exists[0];
        
        var href = '/blocklyStorageget?key=' + key;
        //window.alert(href);
        let req = new XMLHttpRequest();
        req.open('GET', href, false);
        req.send(null);
        if (req.status === 200) {
            var res = req.responseText;
            var data = JSON.parse(res);
            arr.push(data);
            return data;
        }
        //window.alert('get no answer');
        

        throw req;



    };


    this.set = function (key, val) {
        //window.alert('set ' + key);
        var href = '/blocklyStorageset?key='+key;
        let req = new XMLHttpRequest();
        req.open('POST', href, false);
        req.send(JSON.stringify(val));
        return this.get(key);

    };

    this.key = function (index) {
        if (arr.length < index)
            return arr[index].name;
        //window.alert('index !!' + index);
        var href = '/blocklyStorageget?key=' + (index + 1);
        //window.alert(href);
        let req = new XMLHttpRequest();
        req.open('GET', href, false);
        req.send(null);
        if (req.status === 200) {
            var res = req.responseText;
            var data = JSON.parse(res);
            arr.push(data);
            return data.name;
        }

        
    };

    this.data = function () {
        //window.alert('data !!' );

        var i = 0;

        var data = [];


        //while (_ls.key(i)) {

        //    data[i] = [_ls.key(i), this.get(_ls.key(i))];

        //    i++;

        //}



        return data.length ? data : null;

    };

    this.remove = function (keyOrIndex) {

        throw "not implemented";
    };



    this.clear = function () {

        throw "not implemented";
    };

}
