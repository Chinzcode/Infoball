namespace Infoball.Shared.Helpers
{
    public static class SlugHelper
    {

        public static string ToSlug(string input)
        {
            return input
                .ToLowerInvariant()
                .Replace(" ", "-")
                .Replace(".", "")
                .Replace(",", "")
                .Replace("'", "")
                .Trim();
        }
    }
}
