using Project1.Data;
using Project1.Classes;
using Microsoft.AspNetCore.Mvc;

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

app.MapPost("/login", (AccountSqlRepository repo, [FromBody]UserAccount user) =>
{
    return repo.getAccount(user.email, user.password);
});

app.MapPost("/register", (AccountSqlRepository repo, [FromBody]UserAccount user) =>
{

    if(repo.createAccount(user.email, user.password, user.role))
    {
        return repo.getAccount(user.email, user.password);
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

app.MapPost("/createticket", (TicketSqlRepository repo, [FromBody]Ticket ticket) =>
{
    return repo.createTicket(ticket.amount, ticket.description);
});

app.MapGet("/getpendingtickets", (TicketSqlRepository repo) => 
{
    return repo.getPendingTickets();
});

app.MapPut("/updateticketstatus/{ticketID}", (TicketSqlRepository repo, int ticketID, Ticket ticket) =>
{
    repo.updateTicketStatus(ticketID, ticket.status);
    return Results.NoContent();
});


app.Run();





