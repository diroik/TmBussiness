var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



// если приложение в процессе разработки
if (app.Environment.IsDevelopment())
{
    // то выводим информацию об ошибке, при наличии ошибки
    app.UseDeveloperExceptionPage();
}
// добавляем возможности маршрутизации
app.UseRouting();

// устанавливаем адреса, которые будут обрабатываться
app.UseEndpoints(endpoints =>
{
    // обработка запроса - получаем констекст запроса в виде объекта context
    endpoints.MapGet("/", () => "Hello World!!");
    /*
    endpoints.MapGet("/", async context =>
    {
        // отправка ответа в виде строки "Hello World!"
        await context.Response.WriteAsync("Hello World!!!");
    });*/
});
//app.MapGet("/", () => "Hello World!");

app.Run();
