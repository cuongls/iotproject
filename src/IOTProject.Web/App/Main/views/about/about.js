(function () {
    var controllerId = 'app.views.about';
    angular.module('app').controller(controllerId, [
        '$scope', function ($scope) {
            var vm = this;
            //About logic...

            "use strict";
            var chatHub = $.connection.myChatHub;

            chatHub.client.getMessage = function (message) { 
                console.log(message);
            };

            document.getElementById("sendButton").addEventListener("click", function (event) {
                var message = document.getElementById("messageInput").value;
                chatHub.server.sendMessage(message);
            });
        }
    ]);
})();