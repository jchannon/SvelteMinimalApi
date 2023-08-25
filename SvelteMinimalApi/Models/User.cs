using JetBrains.Annotations;

namespace SvelteMinimalApi.Models;

[UsedImplicitly]
public class User
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}