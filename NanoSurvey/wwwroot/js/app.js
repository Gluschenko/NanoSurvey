const App = {
    hello: function () {
        alert("Hello!");
    },
};

const SurveysAPI = {
    getList: function (count, offset, response) {
        API.CallMethod("surveys/getList", { count: count, offset: offset }, function (data) {
            if (data.response) {
                response(data.response);
            }
            else {
                alert(data.error.error_msg);
            }
        });
    },
    get: function (id, response) {
        API.CallMethod("surveys/get", { id: id }, function (data) {
            if (data.response) {
                response(data.response);
            }
            else {
                alert(data.error.error_msg);
            }
        });
    },
    saveResults: function (model, response) {
        API.CallMethod("surveys/saveResults", {}, function (data) {
            if (data.response) {
                response(data.response);
            }
            else {
                alert(data.error.error_msg);
            }
        });
    },
};

const API = {
    ReceiverURI: "/api/",
    CallMethod: function (method, params, response) {
        let url = API.ReceiverURI + method;
        let action = function (data) {
            data = JSON.parse(data);
            response(data);
        };
        AJAX.Post(params, action, url);
    },
};

$$ = {
    body: function () { return document.body; },
    create: function (parent, tag, classList) {
        classList = classList || "";
        tag = tag || "div";

        let e = document.createElement(tag);
        if (classList !== "") e.classList = classList;
        parent.appendChild(e);
        return e;
    },
    ready: function (func) { document.addEventListener("DOMContentLoaded", func); },
    find: function (id) { return document.getElementById(id); },
    select: function (selector) { return document.querySelector(selector); },
    selectAll: function (selector) { return document.querySelectorAll(selector); },
    isObject: function (obj) {
        let type = typeof obj;
        return type === 'function' || type === 'object' && !!obj;
    },
    clear: function (obj) {
        while (obj.firstChild) {
            obj.removeChild(obj.firstChild);
        }
    },
};