// common js functionalities
// Initialization for ES Users
import { Input, initMDB } from "mdb-ui-kit";
initMDB({ Input });

function displayStatus(message, type) {
    const messageContainer = document.getElementById("message-container");
    const statusMessage = document.createElement("div");
    statusMessage.classList.add('status-message', type);
    statusMessage.textContent = message;
    messageContainer.appendChild(statusMessage);

    setTimeout(() => {
        statusMessage.remove();
    }, 5000);
}

