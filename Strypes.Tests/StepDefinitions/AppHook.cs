using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Strypes.Tests.Support;
using TechTalk.SpecFlow;

namespace Strypes.Tests.StepDefinitions;

using ContextsStack = List<IBrowserContext>;

[Binding]
public class AppHooks
{
    private readonly ContextsStack contexts = new();
    private readonly StrypesBrowserContext strypesBrowserContext;
    private readonly ScenarioContext scenarioContext;

    public AppHooks(ScenarioContext scenarioContext, StrypesBrowserContext jiminnyBrowserContext)
    {
        this.scenarioContext = scenarioContext;
        this.strypesBrowserContext = jiminnyBrowserContext;
        this.scenarioContext.Set(this.contexts);
    }

    [BeforeScenario(Order = 0)]
    public async Task InitBrowserContext() => await this.NewContext();

    [AfterScenario(Order = int.MaxValue)]
    public async Task DisposeBrowserContext()
    {
        while (this.contexts.Count > 0)
        {
            var context = this.contexts[0];
            await context.DisposeAsync();
            this.contexts.Remove(context);
        }
    }

    private async Task NewContext()
    {
        var context = await this.strypesBrowserContext.NewContext();
        this.contexts.Insert(0, context);
    }
}
