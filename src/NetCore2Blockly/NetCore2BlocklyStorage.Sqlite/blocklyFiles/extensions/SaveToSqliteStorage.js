
var StorageHandler = function () {



    this.length = (function () {
        var href = '/blocklyStorageLength';
        let req = new XMLHttpRequest();
        req.open('GET', href, false);
        req.send(null);
        if (req.status === 200) {
            var res = req.responseText;
            window.alert('length' + res);
            return res;
        }
        window.alert('length no answer' );
        return 0;
    })();


    this.get = function (key) {

        window.alert('get !!' + key);
        var href = '/blocklyStorageget?key=' + (key + 1);
        window.alert(href);
        let req = new XMLHttpRequest();
        req.open('GET', href, false);
        req.send(null);
        if (req.status === 200) {
            var res = req.responseText;
            window.alert('get ' + res);
            return res;
        }
        window.alert('get no answer');
        return 0;

        throw req;



    };


    this.set = function (key, val) {
        window.alert('set ' + key);
        var href = '/blocklyStorageset?key='+key;
        let req = new XMLHttpRequest();
        req.open('POST', href, false);
        req.send(JSON.stringify(val));
        return this.get(key);

    };

    this.key = function (index) {
        //window.alert('key ' + index);
        return this.get(index);

        
    };

    this.data = function () {
        window.alert('data !!' );

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
