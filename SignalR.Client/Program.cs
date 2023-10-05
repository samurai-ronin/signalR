// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

const string url = "http://localhost:5110/chat";

await using var connection = new HubConnectionBuilder()
.WithUrl(url)
.Build();

await connection.StartAsync();

await foreach (var date in connection.StreamAsync<DateTime>("streaming"))
{
    Console.WriteLine(date);
}
