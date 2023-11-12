using NUnit.Framework;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

namespace QuestPDF.Markdown.Tests;

public class RenderTests
{
    private string _markdown = string.Empty;
    
    [SetUp]
    public void Setup()
    {
        Settings.License = LicenseType.Community;
        _markdown = File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "test.md"));
    }

    [Test]
    public async Task Render()
    {
        var document = GenerateDocument((item) => item.Markdown(_markdown));
        await document.ShowInPreviewerAsync();
    }
    
    [Test]
    public async Task RenderDebug()
    {
        var document = GenerateDocument((item) => item.Markdown(_markdown, true));
        await document.ShowInPreviewerAsync();
    }
    
    private Document GenerateDocument(Action<IContainer> body)
    {
        return Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(1, Unit.Centimetre);
                page.DefaultTextStyle(text =>
                {
                    text.FontFamily(Fonts.Arial);
                    text.LineHeight(1.5f);
                    return text;
                });

                page.Content()
                    .PaddingVertical(20)
                    .Column(main =>
                    {
                        main.Spacing(20);
                        body(main.Item());
                    });
            });
        });
    }
}