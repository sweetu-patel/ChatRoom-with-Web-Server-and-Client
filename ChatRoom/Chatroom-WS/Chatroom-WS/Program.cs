using System.Net.WebSockets;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


var connections = new List<WebSocket>();

app.UseWebSockets();
app.MapGet("/ws", async context =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        var curName = context.Request.Query["name"];
        using var ws = await context.WebSockets.AcceptWebSocketAsync();
        connections.Add(ws);

        await BroadCast($"{curName} Joined the room");

        await BroadCast($"{connections.Count} User connected");

        await ReciveMessage(ws,
            async (result, buffer) =>
            {
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                    await BroadCast(curName + ": " + message);
                }
                else if (result.MessageType == WebSocketMessageType.Close ||
                ws.State == WebSocketState.Aborted)
                {
                    connections.Remove(ws);
                    await BroadCast($"{curName} Left the room");
                    await BroadCast($"{connections.Count} users connected");
                    ws.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
                }

            });
    }
    else
    {
        context.Response.StatusCode = (int)StatusCodes.Status400BadRequest;
    }
});

async Task ReciveMessage(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage)
{
    var buffer = new byte[1024 * 4];
    while (socket.State == WebSocketState.Open)
    {
        var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        handleMessage(result, buffer);
    }
}

async Task BroadCast(string message)
{
    var bytes = Encoding.UTF8.GetBytes(message);
    foreach (var socket in connections)
    {
        if (socket.State == WebSocketState.Open)
        {
            var arraySegment = new ArraySegment<byte>(bytes, 0, bytes.Length);
            await socket.SendAsync(arraySegment, WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}

await app.RunAsync();