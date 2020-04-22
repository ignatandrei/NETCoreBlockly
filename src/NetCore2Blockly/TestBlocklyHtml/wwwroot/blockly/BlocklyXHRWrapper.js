// XHR wrapper functions

const doGet = (href, callback) => {

    console.log(href, callback);
    let req = new XMLHttpRequest();
    req.open('GET', href, true);
    req.onreadystatechange = function () {
        if (req.readyState == 4) {
            if (req.status >= 200 && req.status < 300) {
                return callback(req.responseText);
            } else {
                throw `${href} status :${req.status}`;
            }

        }
        else {
            //window.alert(`error ${href} ${req.status}`);
        }
    };
    req.send(null);
}