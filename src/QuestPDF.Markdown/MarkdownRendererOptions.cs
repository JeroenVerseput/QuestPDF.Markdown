using System.Runtime.InteropServices;
using QuestPDF.Helpers;

namespace QuestPDF.Markdown;

public class MarkdownRendererOptions
{
    /// <summary>
    /// Render DebugAreas in the output
    /// </summary>
    public bool Debug { get; set; }

    public string LinkTextColor { get; set; } = Colors.Blue.Medium;
    public string MarkedTextBackgroundColor { get; set; } = Colors.Yellow.Lighten2;

    public string BlockQuoteBorderColor { get; set; } = Colors.Grey.Lighten2;
    public string BlockQuoteTextColor { get; set; } = Colors.Grey.Darken1;
    public int BlockQuoteBorderThickness { get; set; } = 2;
    
    public string CodeFont { get; set; } = Fonts.CourierNew;
    public string CodeBlockBackground { get; set; } = Colors.Grey.Lighten4;
    public string CodeInlineBackground { get; set; } = Colors.Grey.Lighten3;

    public string TaskListCheckedGlyph { get; set; } = "☑";
    public string TaskListUncheckedGlyph { get; set; } = "☐";
    public string UnicodeGlyphFont { get; set; } = RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "Arial Unicode MS" : Fonts.Arial;

    public string TableBorderColor { get; set; } = Colors.Grey.Lighten2;
    public string TableEvenRowBackgroundColor { get; set; } = Colors.Grey.Lighten4;
    public string TableOddRowBackgroundColor { get; set; } = Colors.White;
    public int TableHeaderBorderThickness { get; set; } = 3;
    public int TableBorderThickness { get; set; } = 1;
    
    public string HorizontalRuleColor { get; set; } = Colors.Grey.Lighten2;
    public int HorizontalRuleThickness { get; set; } = 2;

    /// <summary>
    /// The conversion factor used to scale images from pixel size to point size
    /// </summary>
    public float ImageScalingFactor { get; set; } = 0.5f;

    public float ParagraphSpacing { get; set; } = 10;
    public float ListItemSpacing { get; set; } = 5;
    public string UnorderedListGlyph { get; set; } = "•";
    
    /// <summary>
    /// The formula used to calculate heading sizes based on their level.
    /// </summary>
    /// <remarks>
    /// Level is non zero-indexed and starts at 1 for the largest heading
    /// </remarks>
    public Func<int, int> CalculateHeadingSize { get; set; } = level => 28 - 2 * (level - 1);
}