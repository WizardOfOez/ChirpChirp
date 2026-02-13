namespace Chirp.Tools
{
    public static class PeepExtractor
    {
        public static List<string> ExtractPeeps(string? text)
        {
            var peeps = new List<string>();
            if (string.IsNullOrEmpty(text))
                return peeps;

            var pattern = @"<([^>]+)>";
            var matches = System.Text.RegularExpressions.Regex.Matches(text, pattern);

            foreach (System.Text.RegularExpressions.Match match in matches)
            {
                var peepName = match.Groups[1].Value.Trim();
                if (!string.IsNullOrEmpty(peepName) && !peeps.Contains(peepName))
                {
                    peeps.Add(peepName);
                }
            }

            return peeps;
        }
    }
}
