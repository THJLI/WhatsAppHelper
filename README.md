# WhatsAppHelper for C# .NET Core Developers

WhatsAppHelper is a utility library designed to simplify interactions with the WhatsApp Business API. It provides a set of functionalities that allow developers to send and receive messages, manage contacts, and handle various aspects of WhatsApp communication within their .NET Core applications.

## Features

- Send templated messages to WhatsApp contacts.
- Send text messages to WhatsApp contacts.
- Receive and process incoming WhatsApp messages.
- Manage authentication and token renewal for WhatsApp Business API.
- Handle various aspects of WhatsApp communication.

## Installation

You can install the WhatsAppHelper library using NuGet Package Manager:

```nuget
dotnet add package WhatsAppHelper
```

## Setting Up Services
In your Startup.cs file, configure the necessary services:

```csharp
using WhatsAppHelper.Extensions;
// ...
public void ConfigureServices(IServiceCollection services)
{
    services.AddHttpClient();
    services.AddWaHelper();
}
```

### Sending Templated Messages

```csharp
using WhatsAppHelper.Models;
using WhatsAppHelper.Components;

// ...
var config = GetConfig();
var waConfig = new WaConfig(config.clientId, config.clientSecret, config.idPhoneNumber, config.idWaBusiness, config.token);
var httpWaRequest = DepGet<IHttpWaClient>();
httpWaRequest.SetToken(waConfig);

var waTplMsg = new WaContactTplSend(
    config.mobilePhone,
    "template_token",
    "pt_BR",
    new BodyComponent(new Parameter("text", "123456")),
    new ButtonComponent(new Parameter("text", "123456"))
);

var resp = await httpWaRequest.SendOneContactByTplAsync(waTplMsg);
```

### Sending Text Messages

```csharp
using WhatsAppHelper.Models;

// ...

var config = GetConfig();
var waConfig = new WaConfig(config.clientId, config.clientSecret, config.idPhoneNumber, config.idWaBusiness, config.token);
var httpWaRequest = DepGet<IHttpWaClient>();
httpWaRequest.SetToken(waConfig);

var waMsg = new WaContactTextSend(
    config.mobilePhone,
    false,
    $"Teste envio mensagem via WhatsApp, '{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}'"
);

var resp = await httpWaRequest.SendOneContactByTextAsync(waMsg);
```

### Receiving WhatsApp Messages

```csharp
using WhatsAppHelper.Factories;

// ...

var factory = DepGet<IWaMsgReceiveFactory>();
var json = "your_received_message_json_string_here";
var result = factory.GetResult(json)?.ToList();
// Process and handle the received messages as needed

```






