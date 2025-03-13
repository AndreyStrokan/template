using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine.SceneManagement;

public class SceneLoaderService : ISceneLoaderService
{
    public const string GameSceneName = "Game";

    public async UniTask LoadGameSceneAsync(CancellationToken ct)
    {
        await SceneManager.LoadSceneAsync(GameSceneName, LoadSceneMode.Additive).ToUniTask(cancellationToken: ct);
    }

    public void Dispose()
    {
    }
}
