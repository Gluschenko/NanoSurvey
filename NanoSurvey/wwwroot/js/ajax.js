// AJAX
// Author: Alexander Gluschenko © 2019

const HTTPMethod = {
    GET: "GET",
    POST: "POST"
};

const AJAXOptionsDefault = {
    url: "",
    data: {},
    type: HTTPMethod.GET,
    timeout: 60 * 10 * 1000, // 600 seconds
    success: function (data) { console.log(data); },
    error: function (error) { console.log("AJAX error: " + error); },
};

AJAX = {
    Progress: { current: 0, total: 1, onChanged: function (e) { } },
    CreateXMLHTTP: function () {
        return new XMLHttpRequest();
    },
    Post: function (data, action, url) {
        AJAX.Request({
            type: HTTPMethod.POST,
            url: url,
            data: data,
            success: function (data) { action(data); },
        });
    },
    Get: function (data, action, url) {
        AJAX.Request({
            type: HTTPMethod.GET,
            url: url,
            data: data,
            success: function (data) { action(data); },
        });
    },
    UploadFile: function (file, callback, receiver) {
        let Data = new FormData();
        Data.append("file", file);
        //
        let XHR = new XMLHttpRequest();

        XHR.timeout = 3600 * 1000;
        XHR.onreadystatechange = function (response) { console.log(response); };
        XHR.onloadend = function (response) { callback(response); };
        XHR.open("POST", receiver, true);
        //
        XHR.upload.onprogress = function (e) {
            if (e.lengthComputable) {
                AJAX.Progress.current = e.loaded;
                AJAX.Progress.total = e.total;
            }
            AJAX.Progress.onChanged(e);
        };

        XHR.upload.onloadstart = function (e) {
            AJAX.Progress.current = 0;
            AJAX.Progress.onChanged(e);
        };

        XHR.upload.onloadend = function (e) {
            AJAX.Progress.current = e.loaded;
            AJAX.Progress.onChanged(e);
        };
        //
        XHR.send(Data);
    },
    Request: function (options) {
        let XHR = AJAX.CreateXMLHTTP();
        //
        options = Object.assign(AJAXOptionsDefault, options);
        //
        function ToURL(arr) {
            let output = "";

            for (let key in arr) {
                if (typeof arr[key] != "function") {
                    output += key + "=" + encodeURIComponent(arr[key]) + "&";
                }
            }

            return output;
        }

        if (options.type === HTTPMethod.POST || options.type === HTTPMethod.GET) {
            let post_data = null;

            if (options.type === HTTPMethod.POST) {
                post_data = ToURL(options.data);
            }

            if (options.type === HTTPMethod.GET) {
                options.url += "?" + ToURL(options.data);
            }

            //
            XHR.timeout = options.timeout;
            //XHR.responseType = "text";

            XHR.onprogress = function (e) {
                if (e.lengthComputable) {
                    AJAX.Progress.current = e.loaded;
                    AJAX.Progress.total = e.total;
                }
                //console.log(e);
            };

            XHR.onloadstart = function (e) { AJAX.Progress.current = 0; };
            XHR.onloadend = function (e) { AJAX.Progress.current = e.loaded; };

            XHR.open(options.type, options.url, true);

            //console.log(XHR);

            if (options.type === HTTPMethod.POST)
                XHR.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

            XHR.onreadystatechange = function () {
                if (XHR.readyState === 4) {
                    if (XHR.status === 200) {
                        options.success(XHR.responseText);
                    }
                    else {
                        options.error(XHR.statusText);
                    }
                }
            };

            XHR.send(post_data);
        }
    },
};