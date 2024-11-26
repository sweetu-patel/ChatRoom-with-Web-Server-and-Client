
using System.Net.WebSockets;
using System.Text;

var ws = new ClientWebSocket();

string name;

Console.WriteLine("Input Name: ");
name = Console.ReadLine();

Console.WriteLine("Connecting Server");
await ws.ConnectAsync(new Uri($"ws://localhost:5134/ws?name={name}"), CancellationToken.None);
Console.WriteLine("Connected");



var sendTask = Task.Run(async () =>
{
    while (true)
    {
        var message = Console.ReadLine();
        if (message.ToLower() == "exit")
        {
            break;
        }
        var bytes = Encoding.UTF8.GetBytes(message);
        await ws.SendAsync(new ArraySegment<byte>(bytes),
            WebSocketMessageType.Text,
            true,
            CancellationToken.None);

    }
});

var reciveTask = Task.Run(async () =>
{
    var buffer = new byte[1024 * 5];
    while (true)
    {

        var result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

        if (result.MessageType == WebSocketMessageType.Close)
        {
            Console.WriteLine("Server requested closure");
            await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", CancellationToken.None);
            break;
        }

        var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
        Console.WriteLine("Received: " + message);

    }
});

await Task.WhenAny(reciveTask, sendTask);

if (ws.State == WebSocketState.Closed)
{
    await ws.CloseAsync(WebSocketCloseStatus.NormalClosure,
        "Closing",
        CancellationToken.None);

}

await Task.WhenAll(sendTask, reciveTask);