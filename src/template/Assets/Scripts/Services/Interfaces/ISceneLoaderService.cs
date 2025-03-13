using Cysharp.Threading.Tasks;
using System.Threading;

public interface ISceneLoaderService : IService 
{
    UniTask LoadGameSceneAsync(CancellationToken ct);
}
