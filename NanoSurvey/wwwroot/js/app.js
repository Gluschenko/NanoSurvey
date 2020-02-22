const App = {
    hello: function () {
        alert("Hello!");
    },
    throwError: function (text) {
        if (Array.isArray(text)) {
            alert(text.join('\n'));
        }
        else {
            alert(text);
        }
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

API.Surveys = {
    getList: function (count, offset, response) {
        API.CallMethod("surveys/getList", { count: count, offset: offset }, function (data) {
            if (data.response) {
                response(data.response);
            }
            else {
                App.throwError(data.error.error_msg);
            }
        });
    },
    get: function (id, response) {
        API.CallMethod("surveys/get", { id: id }, function (data) {
            if (data.response) {
                response(data.response);
            }
            else {
                App.throwError(data.error.error_msg);
            }
        });
    },
    getQuestion: function (id, prev, on_response, on_error) {
        API.CallMethod("surveys/getQuestion", { id: id, previous: prev }, function (data) {
            if (data.response) {
                if (on_response)
                    on_response(data.response);
            }

            if (data.error) {
                if (on_error)
                    on_error(data.error);
            }
        });
    },
    saveResult: function (interviewID, questionID, value, response) {
        API.CallMethod("surveys/saveResult", { interviewID: interviewID, questionID: questionID, value: value }, function (data) {
            if (data.response) {
                response(data.response);
            }
            else {
                App.throwError(data.error.error_msg);
            }
        });
    },
};

API.Interviews = {
    save: function (survieyID, firstName, lastName, middleName, email, response) {
        let model = {
            surveyID: survieyID,
            firstName: firstName,
            lastName: lastName,
            middleName: middleName,
            email: email
        };

        API.CallMethod("interviews/save", model, function (data) {
            if (data.response) {
                response(data.response);
            }
            else {
                App.throwError(data.error.error_msg);
            }
        });
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