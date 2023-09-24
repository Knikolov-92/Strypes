using System.IO;
using SpecFlow.Actions.Configuration;
using TechTalk.SpecFlow;

namespace Strypes.Tests.Support;
public class SpecFlowActionJsonLoader : ISpecFlowActionJsonLoader
{
    private readonly ScenarioContext scenarioContext;
    private readonly ISpecFlowActionJsonLocator specFlowActionJsonLocator;

    public SpecFlowActionJsonLoader(ISpecFlowActionJsonLocator specFlowActionJsonLocator, ScenarioContext scenarioContext)
    {
        this.specFlowActionJsonLocator = specFlowActionJsonLocator;
        this.scenarioContext = scenarioContext;
    }

    public string CurrentTargetName => this.scenarioContext is not null && this.scenarioContext.ContainsKey("__SpecFlowActionsConfigurationTarget")
                                        ? (string)this.scenarioContext["__SpecFlowActionsConfigurationTarget"]
                                        : null;

    public string Load()
    {
        var specFlowJsonFilePath = this.specFlowActionJsonLocator.GetFilePath();

        if (specFlowJsonFilePath != null)
        {
            var content = File.ReadAllText(specFlowJsonFilePath);

            return content;
        }

        return "{}";
    }

    public string LoadTarget()
    {
        if (this.CurrentTargetName != null)
        {
            var specFlowJsonFilePath = this.specFlowActionJsonLocator.GetTargetFilePath(this.CurrentTargetName);

            if (specFlowJsonFilePath != null)
            {
                var content = File.ReadAllText(specFlowJsonFilePath);

                return content;
            }
        }

        return "{}";
    }
}
