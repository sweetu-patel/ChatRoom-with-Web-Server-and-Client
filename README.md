💬 ChatRoom with Web Server and Client (ASP.NET Core)
ChatRoom with Web Server and Client is a real-time chat application built using ASP.NET Core and SignalR. This project demonstrates how to build a real-time messaging system with a web server that allows multiple users to join a chat room and exchange messages instantly.

✨ Features
🗨️ Real-time messaging using SignalR.
💬 Multiple users can join and participate in the same chat room.
🔗 Simple and responsive web client interface.
🚀 Instant message delivery with low-latency communication.
🌐 Web client built with HTML, CSS, and JavaScript.
🛠️ Built With
ASP.NET Core: Framework for building the server-side application.
SignalR: A library for adding real-time web functionality to apps.
HTML/CSS/JavaScript: For the front-end client interface.
Bootstrap: For responsive UI design.
📦 Installation
To run the ChatRoom application locally, follow these steps:

1. Clone the repository:
Use the following command to clone the repository to your local machine:

git clone https://github.com/sweetu-patel/ChatRoom-with-Web-Server-and-Client.git

2. Open the Solution in Visual Studio:
Open the ChatRoom.sln solution file in Visual Studio.

3. Restore Dependencies:
Use NuGet to restore all project dependencies.

4. Run the Application:
Press F5 or Ctrl + F5 to build and run the application. The server will start and listen for WebSocket connections using SignalR.

5. Open the Client:
Open index.html in a web browser to join the chat room.

🌟 Usage
Connect to the Chat Room: Open the client in your browser. The chat room will connect to the server via SignalR.
Send and Receive Messages: Type messages in the chat interface and hit send to share them in real-time.
Simulate Multiple Users: Open the chat room in multiple browser tabs to simulate multiple users chatting.
Server Logs: The server will log all incoming connections and messages in the output console.
🛠️ File Structure
/ChatRoom: The main ASP.NET Core project containing SignalR configurations and chat logic.
ChatHub.cs: The SignalR hub that manages message broadcasting to clients.
Startup.cs: The configuration file to set up SignalR services and endpoints.
/wwwroot: Contains the static files like index.html, style.css, and script.js for the client-side interface.
ChatRoom.sln: The solution file for the ASP.NET Core project.
🔧 Technologies Used
ASP.NET Core: The framework used to build the server-side logic.
SignalR: A library to implement real-time communication.
Bootstrap: Used for responsive and modern UI styling.
JavaScript/HTML/CSS: For the client-side functionality and layout.
📜 License
This project is licensed under the MIT License.

🙋‍♂️ Support
If you face any issues or need further assistance, please open an issue.

👨‍💻 Author
Developed by Sweetu Patel.

Thank you for checking out ChatRoom with Web Server and Client (ASP.NET Core)! Enjoy chatting in real-time. 😊
