(function () {
    var controllerId = 'app.views.about';
    angular.module('app').controller(controllerId, [
        '$scope', function ($scope) {
            var vm = this;
            //About logic...

            "use strict";
            var chatHub = $.connection.myChatHub;
            console.log(chatHub);
            chatHub.client.getMessage = function (user, message) { // Register for incoming messages
                console.log('received message: ' + message);
            };
            document.getElementById("sendButton").addEventListener("click", function (event) {
                var message = document.getElementById("messageInput").value;
                chatHub.server.sendMessage(message);
            });
        }
    ]);
})();