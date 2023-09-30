using Boilerplate_GenericRepository_RavenDB.DAL;
using Boilerplate_GenericRepository_RavenDB.DAL.Contracts;
using Boilerplate_GenericRepository_RavenDB.Model.Entity;
using Raven.Client.Documents;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//custom services
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IDocumentStore>(sp =>
{
    // Use a factory function to create and configure the IDocumentStore
    var documentStore = RavenDbConfig.Initialize();

    // Optionally, add any additional configuration or setup here

    return documentStore;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/customers", (ICustomerRepository customerRepository) =>
{
    return customerRepository.GetAll();   
})
.WithName("GetCustomers")
.WithOpenApi();

app.MapGet("/customer/{id}", (ICustomerRepository customerRepository, string id) =>
{
    return customerRepository.GetById(id);
})
.WithName("GetCustomer")
.WithOpenApi();

app.MapPost("/customers", (ICustomerRepository customerRepository, Customer customer) =>
{
    customerRepository.Add(customer);
})
.WithName("CreateCustomer")
.WithOpenApi();

app.MapPut("/customer/{id}", (ICustomerRepository customerRepository, Customer customer, string id) =>
{
    //set the customerid from the id in the url, in case no id is present
    customer.Id = id;
    customerRepository.Add(customer);
})
.WithName("UpdateCustomer")
.WithOpenApi();

app.MapDelete("/customer/{id}", (ICustomerRepository customerRepository, string id) =>
{
    //set the customerid from the id in the url, in case no id is present
    customerRepository.Delete(id);
})
.WithName("DeleteCustomer")
.WithOpenApi();

app.Run();

