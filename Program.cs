var app = WebApplication.Create(args);

app.MapGet("/download", async context =>
{
   context.Response.ContentType = "application/octet-stream";

   var random = new Random();
   byte[] buffer = new byte[64 * 1024]; // 64KB buffer

   while(!context.RequestAborted.IsCancellationRequested)
    {
        random.NextBytes(buffer);
        await context.Response.Body.WriteAsync(buffer);
        await context.Response.Body.FlushAsync();
    }
});

app.Run();