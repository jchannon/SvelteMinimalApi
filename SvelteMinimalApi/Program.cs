using System.Text.Json;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using SvelteMinimalApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAntiforgery();

var app = builder.Build();
app.UseStaticFiles();

app.MapGet("/", (HttpContext context, IAntiforgery antiforgery) =>
{
    var token = antiforgery.GetAndStoreTokens(context);
    return Slice("/Slices/Index.cshtml",
        new FormAntiForgeryModel
        {
            TokenValue = token.RequestToken,
            TokenFieldName = token.FormFieldName
        });
});

app.MapPost("/", async ([FromForm] User user, HttpContext context, IAntiforgery antiforgery) =>
{
    try
    {
        await antiforgery.ValidateRequestAsync(context);
        
        var token = antiforgery.GetAndStoreTokens(context);

        return Slice("/Slices/Index.cshtml",
            new FormAntiForgeryModel
            {
                TokenValue = token.RequestToken,
                TokenFieldName = token.FormFieldName,
                UserJson = JsonSerializer.Serialize(user)
            });
    }
    catch (AntiforgeryValidationException e)
    {
        return TypedResults.BadRequest("Invalid anti-forgery token");
    }
});

app.Run();

IResult Slice<T>([AspMvcView]string viewPath, T model)
{
    return Results.Extensions.RazorSlice(viewPath, model);
}