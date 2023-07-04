namespace ReportPortal.Core.Utils
{
    public static class UiColors
    {
        public static string ConvertToColorName(string rgbaColor)
        {
            return rgbaColor switch
            {
                "rgba(188, 213, 254, 1)" => "Light Blue",
                "rgba(0, 0, 255, 1)" => "Blue",
                "rgba(230, 250, 255, 1)" => "Turquoise",
                "rgba(255, 255, 255, 1)" => "White",
                "rgb(128, 128, 128)" => "Grey",
                "rgba(255, 249, 219, 1)" => "Light Yellow",
                "rgb(255, 0, 0)" => "Red",
                "rgba(255, 165, 0, 1)" => "Orange",
                "rgba(0, 0, 0, 0)" => "None",
                "rgba(0, 0, 0, 1)" => "Black",

                _ => throw new ArgumentException(
                    $"Could not convert rgba value - color for '{rgbaColor}' doesn't exist")
            };
        }
    }
}
