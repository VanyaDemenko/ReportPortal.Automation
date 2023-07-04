namespace ReportPortal.Core.Utils
{
    public static class UiFontWeights
    {
        public static string ConvertToFontWeightName(string fontWeight)
        {
            return fontWeight switch
            {
                "100" => "Thin",
                "200" => "Extra Light",
                "300" => "Light",
                "400" => "Normal",
                "500" => "Medium",
                "600" => "Semi Bold",
                "700" => "Bold",
                "800" => "Extra Bold",
                "900" => "Heavy",
                _ => throw new ArgumentException(
                    $"Could not convert font weight value - name for '{fontWeight}' doesn't exist")
            };
        }
    }
}
