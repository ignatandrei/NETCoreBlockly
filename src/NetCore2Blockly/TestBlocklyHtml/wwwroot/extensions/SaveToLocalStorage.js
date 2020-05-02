//https://github.com/joaocunha/javascript-localstorage-handler/blob/master/LocalStorageHandler.js

var StorageHandler = function () {



        /**

         * @property _ls

         * @private

         * @type Object

         */

        var _ls = window.localStorage;



        /**

         * @property length

         * @type Number

         */

        this.length = _ls.length;



        /**

         * @method get

         * @param key {String} Item key

         * @return {String|Object|Null}

         */

        this.get = function(key) {

            try {

                return JSON.parse(_ls.getItem(key));

            } catch(e) {

                return _ls.getItem(key);

            }

        };



        /**

         * @method set

         * @param key {String} Item key

         * @param val {String|Object} Item value

         * @return {String|Object} The value of the item just set

         */

        this.set = function(key, val) {

            _ls.setItem(key,JSON.stringify(val));

            return this.get(key);

        };



        /**

         * @method key

         * @param index {Number} Item index

         * @return {String|Null} The item key if found, null if not

         */

        this.key = function(index) {

            if (typeof index === 'number') {

                return _ls.key(index);

            }

        };



        /**

         * @method data

         * @return {Array|Null} An array containing all items in localStorage through key{string}-value{String|Object} pairs

         */

        this.data = function() {

            var i       = 0;

            var data    = [];



            while (_ls.key(i)) {

                data[i] = [_ls.key(i), this.get(_ls.key(i))];

                i++;

            }



            return data.length ? data : null;

        };



        /**

         * @method remove

         * @param keyOrIndex {String|Number} Item key or index (which will be converted to key anyway)

         * @return {Boolean} True if the key was found before deletion, false if not

         */

        this.remove = function(keyOrIndex) {

            var result = false;

            var key = (typeof keyOrIndex === 'number') ? this.key(keyOrIndex) : keyOrIndex;



            if (key in _ls) {

                result = true;

                _ls.removeItem(key);

            }



            return result;

        };



        /**

         * @method clear

         * @return {Number} The total of items removed

         */

        this.clear = function() {

            var len = _ls.length;

            _ls.clear();

            return len;

        };

}
