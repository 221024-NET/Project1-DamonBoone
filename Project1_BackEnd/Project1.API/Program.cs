using Project1.Data;
using Project1.Classes;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conn = File.ReadAllText("F:/Revature/Project1/Project1_BackEnd/connectionString.txt");
//var conn = builder.Configuration.GetValue<string>("ConnectionString:DamonDB");

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
    return repo.getAccount(email, password);
});

app.MapPost("/createaccount", (AccountSqlRepository repo, string email, string password, string role) =>
{

    if(repo.createAccount(email, password, role))
    {
        return repo.getAccount(email, password);
    }
    else
    {
        return null;
    }
    

});

app.MapGet("/gettickets", (TicketSqlRepository repo) =>
{
    return repo.getAllTickets();
});

app.MapPost("/createticket", (TicketSqlRepository repo, double amount, string description) =>
{
    return repo.createTicket(amount, description);
});



app.Run();





