'use strict';
        const connection = new signalR.HubConnectionBuilder()
            .withUrl("/chathub")
            .build();


        connection.on("ReceiveNotification", (sender, message) => {
            // Update message count
            const messageCountElement = document.getElementById('messageCount');
            let messageCount = parseInt(messageCountElement.textContent) || 0;
            messageCount++;
            messageCountElement.textContent = messageCount;

            // Add new message to the dropdown
            const notifications = document.getElementById('messageNotifications');
            const notificationItem = document.createElement('div');
            notificationItem.className = 'dropdown-item';
            notificationItem.textContent = `${sender}: ${message}`;
            notifications.appendChild(notificationItem);

            // Add new notification to the notifications section
            const notificationsList = document.getElementById('notifications-list');
            const li = document.createElement('li');
            li.className = 'notification';
            li.textContent = `${sender}: ${message}`;
            li.onclick = () => navigate('/chat'); // Adjust URL as needed
            notificationsList.appendChild(li);

            // Show notifications section if hidden
            document.querySelector('.notifications-section').style.display = 'block';
        });

        connection.start().catch(err => console.error('Error connecting to SignalR: ' + err.toString()));

        function sendMessage(event) {
            event.preventDefault();  // Prevent form submission
            const sendingUser = document.getElementById('sendingUser').value;
            const destuser = document.getElementById('destuser').value;
            const message = document.getElementById('messageInput').value;
            connection.invoke("SendMessage", destuser, message)
                .catch(err => console.error('Error sending message: ' + err.toString()));
            document.getElementById('messageInput').value = '';
        }

        function loadMessages(event) {
            event.preventDefault();  // Prevent form submission
            const destuser = document.getElementById('destuser').value;
            connection.invoke("LoadPreviousMessages", destuser)
                .catch(err => console.error('Error loading messages: ' + err.toString()));
        }

        function appendMessage(sender, message, prepend = false) {
            const sendingUser = document.getElementById('sendingUser').value;
            const msg = document.createElement('li');
            msg.className = 'clearfix';

            if (sender === sendingUser) {
                msg.innerHTML = `
                    <div class="message-data text-end me-2">
                        <span class="message-data-time">${new Date().toLocaleTimeString()}, ${new Date().toLocaleDateString()}</span>
                        <span class="message-data"><b>${sender}</b></span>
                    </div>
                    <div class="message my-message float-right">${message}</div>
                `;
            } else {
                msg.innerHTML = `
                    <div class="message-data text-end me-2">
                        <span class="message-data-time">${new Date().toLocaleTimeString()}, ${new Date().toLocaleDateString()}</span>
                        <span class="message-data"><b>${sender}</b></span>
                    </div>
                    <div class="message other-message float-right">${message}</div>
                `;
            }
            const chatMessages = document.getElementById('chatMessages');
            if (prepend) {
                chatMessages.insertBefore(msg, chatMessages.firstChild);
            } else {
                chatMessages.appendChild(msg);
            }
        }

        function navigate(url) {
            window.location.href = url;
        }