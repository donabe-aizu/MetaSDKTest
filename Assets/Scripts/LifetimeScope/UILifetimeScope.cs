using MessagePipe;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public sealed class UILifetimeScope : LifetimeScope
{
    [SerializeField] private UIView uiView;
    
    protected override void Configure(IContainerBuilder builder)
    { 
        builder.RegisterMessagePipe();

        builder.Register<UIPresenter>(Lifetime.Singleton);
        builder.Register<UIModel>(Lifetime.Singleton);
        builder.RegisterEntryPoint<UIPresenter>(Lifetime.Singleton);
        builder.RegisterEntryPoint<UIModel>(Lifetime.Singleton);

        builder.RegisterComponent(uiView);
    }
}