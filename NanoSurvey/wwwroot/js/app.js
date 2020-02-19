const App = {
    hello: function () {
        alert("Hello!");
    },
};

const Surveys = {
    getList: function (count, offset) {

    },
    get: function (id) {

    },
    saveResults: function (model) {

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