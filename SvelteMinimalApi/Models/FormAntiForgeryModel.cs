using JetBrains.Annotations;

namespace SvelteMinimalApi.Models;

[UsedImplicitly]
public class FormAntiForgeryModel
{
    public string TokenFieldName { get; init; } = null!;
    public string TokenValue { get; init; } = null!;

    public string UserJson { get; init; } = "";
}