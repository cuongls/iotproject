(function () {
    var controllerId = 'app.views.about';
    angular.module('app').controller(controllerId, [
        '$scope', function ($scope) {
            var vm = this;
            //About logic...

            "use strict";
            var chatHub = $.connection.myChatHub; // Get a reference to the hub

            chatHub.client.getMessage = function (message) { // Register for incoming messages
                console.log('received message: ' + message);
            };

            abp.event.on('abp.signalr.connected', function () { // Register to connect event
                chatHub.server.sendMessage("Hi everybody, I'm connected to the chat!"); // Send a message to the server
            });
            
        }
    ]);
})();