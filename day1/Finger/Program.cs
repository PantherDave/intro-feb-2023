using Finger;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


app.MapGet("/status", () => {
    var status = new StatusMessage("All good!", DateTimeOffset.Now);
    return status;
});

app.MapPost("/status", (StatusRequest req) => {
    return req;
});

app.Run();

public record StatusRequest(string Message);