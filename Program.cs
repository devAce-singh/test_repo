var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/", async webhookPayload => {
    //var requestBody = await context.Request.ReadFromJsonAsync<WebhookPayload>();
    Console.WriteLine("Webhook Call is Successfull!");
    Console.WriteLine("webhookPayload : " + webhookPayload);
    Console.WriteLine("webhookPayload Request : " + webhookPayload.Request);
    Console.WriteLine($"webhookPayload Request Header: {webhookPayload.Request.Headers}, webhookPayload Request Body: {webhookPayload.Request.Body}");

    webhookPayload.Response.StatusCode = 200;
    await webhookPayload.Response.WriteAsync("Webhook Calling Successfully!");
});

app.Run();

public class WebhookPayloadSchema
{
    public string Header { get; set; }
    public string Body { get; set; }

}
