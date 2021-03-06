var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost/chat", {
    accessTokenFactory: () => "JWT here"
}).build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${user} -> ${message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    var group = document.getElementById("group").value;

    var obj = {
        Group: group,
        User: user,
        Message: message
    }

    connection.invoke("SendMessageToGroup", obj).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

function clearChat() {
    document.getElementById("messagesList").innerHTML = "";
}

function joinRoom(group) {
    clearChat();

    connection.invoke("AddToGroup", group).catch(function (err) {
        return console.error(err.toString());
    });
}