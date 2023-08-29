var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



// ���� ���������� � �������� ����������
if (app.Environment.IsDevelopment())
{
    // �� ������� ���������� �� ������, ��� ������� ������
    app.UseDeveloperExceptionPage();
}
// ��������� ����������� �������������
app.UseRouting();

// ������������� ������, ������� ����� ��������������
app.UseEndpoints(endpoints =>
{
    // ��������� ������� - �������� ��������� ������� � ���� ������� context
    endpoints.MapGet("/", () => "Hello World!!");
    /*
    endpoints.MapGet("/", async context =>
    {
        // �������� ������ � ���� ������ "Hello World!"
        await context.Response.WriteAsync("Hello World!!!");
    });*/
});
//app.MapGet("/", () => "Hello World!");

app.Run();
