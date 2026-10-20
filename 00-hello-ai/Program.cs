using System.ClientModel;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
var key = config["AI:Key"]!;

IChatClient client = new OpenAIClient(
        new ApiKeyCredential("ollama"),   // koi bhi text, Ollama check nahi karta
        new OpenAIClientOptions { Endpoint = new Uri("http://localhost:11434/v1") })
    .GetChatClient("llama3.2")
    .AsIChatClient();

var response = await client.GetResponseAsync("Explain RAG AI Related in 2 lines");
Console.WriteLine(response.Text);