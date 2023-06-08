using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PizzaManagement.API.Infrastructure.Extensions;
using PizzaManagement.API.Infrastructure.Mappings;
using PizzaManagement.API.Infrastructure.Middlewares;
using PizzaManagement.Persistence;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
/*
 
 
* CreatedOn და UpdatedOn ველები ივსება ავტომატურად saveChangesAsync გადატვირთვის დახმარებით
* 
* "When one pizza is selected, I should see the average ranking of it" ამაზე ვიფიქრე მეორე პიცის Response მოდელის შექმნა 
რომ მხოლოდ GetById ფუნქციამ დააბრუნოს პიცა რომელსაც აქვს დამატებით ველი რანკი.

*PizzaController-ში Examples რომ მინდოდა ამემუშავებინა GetAll ფუნქციის თავზე SwaggerResponseExample ატრიბუტი დაკომენტარებულია
რადგან swagger აღარ იტვირთება მაგის გამო და ისვრის ექსეფშენს, დროებით ვერ ვასწორებ თუმცა GetById-ზე და Create-ზე Example მაინც მაქვს, ასევე User-ზეც.

*ყველა middleware დავალებაში მოცემული მუშაობს ჩემთან, requestResponse logger ცალკე middleware არის, globalExceptionHandling-ში ცალკე ლოგირებაც მაქვს 
რაც ცუდი პრაქტიკაა მაგრამ უკეთესი ვერ მოვასწარი.

*address-ის დამატებაზე მაქვს პრობლემა ერორს მიგდებს სავარაუდოდ EF core-ის მიგრაციებში ამერია realtionship და გასწორებას ვერ ვასწრებ. ადრესის დამატება ამიტომ არ მუშაობს,
აიდით ბაზითან მოთხოვნა ინფორმაციის კი.

*რანკის გამოთვლა მიწერია Pizza Repository-ში, მაგრამ თვითონ rankHistory კონტროლერის დაწერა ვერ მოვასწარი

 */
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Pizza Management Api",
        Version = "v1",
        Description = "Api for pizza restaurants"
    });

    var xmlFile =$"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine($"{AppContext.BaseDirectory}", xmlFile);
    option.IncludeXmlComments(xmlPath);
    option.ExampleFilters();
});
builder.Services.AddServices();
builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<PizzaManagerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
        , b => b.MigrationsAssembly("PizzaManagement.Persistence"));
});
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.RegisterMaps();
var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRequestCulture();
app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
