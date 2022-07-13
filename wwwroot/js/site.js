// Write your JavaScript code.
"use strict";

// Define connection to use for whole project

var connection = new signalR.HubConnectionBuilder().withUrl("/serverHub").build();
connection.start().then(function () {

    console.log("Connected to Hub...");
}).catch(function () {

    console.log("Connected to hub failed!...");
});

const callHubMethod = function (methodName, ...args) {
    connection.invoke(methodName, ...args);
}