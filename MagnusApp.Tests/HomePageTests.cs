using Bunit;
using MagnusApp.Client.Pages;
using Syncfusion.Blazor;
using Xunit;
namespace MagnusApp.Tests;

public class HomePageTests : TestContext
{
    public HomePageTests()
    {
        // Register Syncfusion services
        Services.AddSyncfusionBlazor(); 
    }

    [Fact]
    public void HomePageRendersHeaderCorrectly()
    {
        // Act - Render the component
        var cut = RenderComponent<Home>();

        // Assert - Check the header section
        cut.Find("h2").MarkupMatches("<h2 class=\"text-start\">Hi. I'm Magnus 👋</h2>");
    }

    [Fact]
    public void HomePageRendrsSkillIcons()
    {
        // Act - Render the component
        var cut = RenderComponent<Home>();

        // Assert - Check if the blazor skill icon is rendered
        var blazorSkill = cut.Find("img[alt='blazor icon']");
        Assert.NotNull(blazorSkill);

        // Assert - Check if the .NET/C# skill icon is rendered
        var dotnetSkill = cut.Find("img[alt='dotnet icon']");
        Assert.NotNull(dotnetSkill);
    }

    [Fact]
    public void HomePageRendersProjectTitleCorrectly()
    {
        // Act - Render the component
        var cut = RenderComponent<Home>();

        //Assert - Check the Project section

        cut.Find("h4.non-heroh").MarkupMatches("<h4 class=\"non-heroh\">PROJECTS</h4>");

    }
}