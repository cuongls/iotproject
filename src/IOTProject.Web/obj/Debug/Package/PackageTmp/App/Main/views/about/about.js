(function () {
    var controllerId = 'app.views.about';
    angular.module('app').controller(controllerId, [
        '$scope', function ($scope) {
            var vm = this;
            //About logic...

            "use strict";
            var chatHub = $.connection.myChatHub; // Get a reference to the hub

            chatHub.client.getMessage = function (message) { // Register for incoming messages
                console.log(message);
            };

            document.getElementById("sendButton").addEventListener("click", function (event) {
                var message = document.getElementById("messageInput").value;
                chatHub.server.sendMessage(message);
            });
        }
    ]);
})();