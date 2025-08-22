﻿namespace TestsPlaywright.TestsQuery;

public class PlaywrightTestHelperQueryTests
{
    [Fact]
    public async Task CreatePageAsync_ReturnsValidPage()
    {
        var page = await PlaywrightTestHelper.CreatePageAsync();

        Assert.NotNull(page);
        Assert.NotNull(page.Context);
        Assert.NotNull(page.Context.Browser);

        await page.GotoAsync("about:blank");
        var url = page.Url;
        Assert.Equal("about:blank", url);

        await PlaywrightTestHelper.DisposeBrowserAndContext(page);
    }
}