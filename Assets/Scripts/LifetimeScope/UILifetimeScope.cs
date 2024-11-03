using UnityEngine;
using VContainer;
using VContainer.Unity;

public sealed class UILifetimeScope : LifetimeScope
{
    [SerializeField] private UIView uiView;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<UIPresenter>(Lifetime.Singleton);
        builder.Register<UIModel>(Lifetime.Singleton);
        
        builder.RegisterComponent(uiView);
    }
}