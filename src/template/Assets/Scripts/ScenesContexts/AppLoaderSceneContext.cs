using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class AppLoaderSceneContext : SceneContextBase
{
    private ILoggerService loggerService;
    private ISceneLoaderService sceneLoaderService;

    protected override void ResolveServices(IServiceResolver serviceResolver)
    {
    }

    protected override void RegisterServices(IServiceRegistrar serviceRegistrar)
    {
        loggerService = new LoggerService();
        serviceRegistrar.Register(loggerService);

        sceneLoaderService = new SceneLoaderService();
        serviceRegistrar.Register(sceneLoaderService);
    }

    protected override async UniTask InitializeAsync(CancellationToken ct)
    {
        Application.targetFrameRate = 60;

        // Load location.
        await sceneLoaderService.LoadGameSceneAsync(ct);
    }

    protected override void DeInitialize()
    {

    }
}