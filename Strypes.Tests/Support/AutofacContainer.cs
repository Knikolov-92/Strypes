using System;
using Autofac;
using Autofac.Features.ResolveAnything;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Playwright;
using SpecFlow.Actions.Configuration;
using SpecFlow.Actions.Playwright;
using SpecFlow.Autofac;
using TechTalk.SpecFlow;

namespace Strypes.Tests.Support;

public static class AutofacContainer
{
    [ScenarioDependencies]
    public static void CreateContainerBuilder(ContainerBuilder containerBuilder)
    {
        containerBuilder
            .RegisterAssemblyTypes(typeof(AutofacContainer).Assembly)
            .Where(t => Attribute.IsDefined(t, typeof(BindingAttribute)))
            .SingleInstance();

        containerBuilder.RegisterType<SpecFlowActionJsonLoader>().As<ISpecFlowActionJsonLoader>();
        containerBuilder.RegisterType<SpecFlowActionJsonLocator>().As<ISpecFlowActionJsonLocator>();
        containerBuilder.RegisterType<TargetIdentifier>().As<ITargetIdentifier>();

        containerBuilder.RegisterType<PlaywrightConfiguration>().As<IPlaywrightConfiguration>();
        containerBuilder.RegisterType<DriverInitialiser>().As<IDriverInitialiser>();
        containerBuilder.RegisterType<BrowserDriver>().SingleInstance();

        containerBuilder.Register<IBrowser>(c => c.Resolve<BrowserDriver>().Current.GetAwaiter().GetResult()).SingleInstance();

        containerBuilder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        containerBuilder.RegisterInstance(config).SingleInstance();
        containerBuilder.Register(c => Options.Create(config.GetSection("browserContextOptions").Get<BrowserNewContextOptions>()));
    }
}
