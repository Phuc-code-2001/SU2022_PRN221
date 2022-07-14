// Write your JavaScript code.
"use strict";

// Define connection to use for whole project

const connection = new signalR.HubConnectionBuilder().withUrl("/serverHub").build();
connection.start().then(function () {

    console.log("Connected to Hub...");
}).catch(function () {

    console.log("Connected to hub failed!...");
});

const chatConnection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
chatConnection.start().then(function () {

}).catch(function () {

	console.log("Connected to chathub failed!...");
});

const callHubMethod = function (methodName, ...args) {
    connection.invoke(methodName, ...args);
}