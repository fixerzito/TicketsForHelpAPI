using Microsoft.EntityFrameworkCore;
using TicketsForHelp.Domain.Interfaces.Repositories.Customer;
using TicketsForHelp.Domain.Interfaces.Repositories.Ticket;
using TicketsForHelp.Domain.Interfaces.Services.Customer;
using TicketsForHelp.Domain.Interfaces.Ticket;
using TicketsForHelp.Infra.Data.Context;
using TicketsForHelp.Infra.Data.Repositories.Customer;
using TicketsForHelp.Infra.Data.Repositories.Ticket;
using TicketsForHelp.Service.Services.Customer;
using TicketsForHelp.Service.Services.Ticket;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        corsBuilder => corsBuilder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddDbContext<TicketsForHelpContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<TicketsForHelpContext>();
    context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TicketsForHelp API V1");
        c.RoutePrefix = string.Empty; // Swagger abrirá em https://localhost:7219/
    });
}

app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();