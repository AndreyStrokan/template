using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public abstract class SceneContextBase : MonoBehaviour
{
    private static ServiceContainer serviceContainer;
    private static int contextsCount = 0;

    private CancellationTokenSource contextCts = new();

    private async void Awake()
    {
        if (serviceContainer == null)
        {
            serviceContainer = new ServiceContainer();
        }

        ResolveServices(serviceContainer);

        RegisterServices(serviceContainer);

        await InitializeAsync(contextCts.Token);

        contextsCount++;
    }

    private void OnDestroy()
    {
        contextCts?.Cancel();
        contextCts = null;

        DeInitialize();

        contextsCount--;

        if (contextsCount == 0)
        {
            serviceContainer.Dispose();
        }
    }

    protected abstract void RegisterServices(IServiceRegistrar serviceRegistrar);

    protected abstract void ResolveServices(IServiceResolver serviceResolver);

    protected abstract UniTask InitializeAsync(CancellationToken ct);

    protected abstract void DeInitialize();
}
