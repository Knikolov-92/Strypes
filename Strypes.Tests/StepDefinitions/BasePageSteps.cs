using System;
using System.Collections.Generic;
using Microsoft.Playwright;
using Strypes.Core.Pages;
using TechTalk.SpecFlow;

namespace Strypes.Tests.StepDefinitions;

using ContextsStack = List<IBrowserContext>;

public class BasePageSteps
{
    public BasePageSteps(ScenarioContext scenarioContext)
    {
        this.ScenarioContext = scenarioContext;
    }

    protected ScenarioContext ScenarioContext { get; private set; }
    protected IPage CurrentPage => this.Contexts[0].Pages[0];
    protected ContextsStack Contexts => this.ScenarioContext.Get<ContextsStack>();
    protected StrypesApp App => new(this.CurrentPage);
}

public class BasePageSteps<T> : BasePageSteps where T : BasePage
{
    private readonly Func<IPage, T> pageFactory;

    public BasePageSteps(ScenarioContext scenarioContext, Func<IPage, T> pageFactory) : base(scenarioContext)
    {
        this.pageFactory = pageFactory;
    }

    protected T Page => this.pageFactory(this.CurrentPage);
}
