using Project1.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conn = File.ReadAllText("F:/Revature/Project1/connectionString.txt");

builder.Services.AddTransient<AccountSqlRepository>();
builder.Services.AddTransient<TicketSqlRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/getaccount", (AccountSqlRepository repo, string email, string password) =>
{
    repo.getAccount(email, password);
});

app.MapPost("/createaccount", (AccountSqlRepository repo, string email, string password, string role) =>
{
    repo.createAccount(email, password, role);
    return Results.NoContent();
});

app.MapGet("/gettickets", (TicketSqlRepository repo) =>
{
    repo.getAllTickets();
});

app.MapPost("/createticket", (TicketSqlRepository repo, double amount, string description) =>
{
    repo.createTicket(amount, description);
    return Results.NoContent();
});


app.Run();
