using PlumsailTest.Library.ALMW.Models;

namespace PlumsailTest.Library.ALMW;

public static class TemplateMapper
{
    /// <exception cref="ArgumentNullException"><paramref name="oldValue" /> is <see langword="null" />.</exception>
    /// <exception cref="ArgumentException"><paramref name="oldValue" /> is the empty string ("").</exception>
    public static string Map(string templateItem, ProductModel product)
    {
        return templateItem
            .Replace("{{product.name}}", product.Name)
            .Replace("{{product.price | price }}", product.Price.ToString())
            .Replace("{{product.price}}", product.Price.ToString())
            .Replace("{{price}}", product.Price.ToString())
            .Replace("{{product.description | paragraph }}", product.Description)
            .Replace("{{product.description}}", product.Description)
            .Replace("{{paragraph}}", product.Description);
    }
}