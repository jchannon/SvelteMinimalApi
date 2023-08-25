# SvelteMinimalApi

This repo uses:

[.NET 8 (New MinimalAPI `[FromForm]`  model binding)](https://devblogs.microsoft.com/dotnet/asp-net-core-updates-in-dotnet-8-preview-6/#complex-form-binding-support-in-minimal-apis)

[Svelte](https://svelte.dev/)

[RazorSlices](https://github.com/DamianEdwards/RazorSlices) from Damian Edwards

## Usage

This app uses .NET 8 Minimal API to return a Razor View which then uses Svelte components that are built via call to`npm build` target in the `*.csproj`.

A Svelte component renders a form and POSTs data to a route defined on the server via `MapPost`. 

The form rendering and submit feature takes advantage of .NET CSRF functionality.