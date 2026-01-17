using UrlShortener.Application.Services;
using UrlShortener.Application.Services.Interfaces;
using UrlShortener.Infra.Database;
using UrlShortener.Infra.Repositories;
using UrlShortener.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using UrlShortener.Application.DTO;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services
    .AddScoped<IUrlRepository, UrlRepository>()
    .AddScoped<IUrlService, UrlService>()
    .AddDbContext<DatabaseContext>(Options => Options.UseInMemoryDatabase("UrlShortenerDB"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Doc"));
}

app.UseHttpsRedirection();

//GET
app.MapGet("/{shortUrl}", async (string shortUrl, IUrlService urlService) =>
{
    var urlResponse = await urlService.GetUrl(shortUrl);

    if (urlResponse == null)
        return Results.NotFound("URL not found");

    var urlRedirect = urlResponse.OriginalUrl;

    if(!urlRedirect.StartsWith("http://") && !urlRedirect.StartsWith("https://"))
        urlRedirect = "https://" + urlRedirect;

    return Results.Redirect(urlRedirect);
});

app.MapGet("/api/urls", async (IUrlService urlService) =>
{
    var urls = await urlService.GetAll();
    return Results.Ok(urls);
});

//POST
app.MapPost("/api/create", async (CreateUrlDto url, IUrlService urlService) =>
{
    var urlResponse = await urlService.CreateUrl(url);

    if (urlResponse == null)
        return Results.BadRequest("Error creating short URL");

    return Results.Created("",urlResponse);
});

//DELETE
app.MapDelete("/api/delete/{shortUrl}", async (string shortUrl, IUrlService urlService) =>
{
    await urlService.DeleteUrl(shortUrl);

    return Results.Ok();
});


//app.UseAuthorization();

//app.MapControllers();

app.Run();
