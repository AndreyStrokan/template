using Cysharp.Threading.Tasks;
using System;
using System.Threading;

public class WaitingOperation<T>
{
    private Func<CancellationToken, UniTask<T>> task;
    private CancellationTokenSource internalCts;

    public void Subscribe(Func<CancellationToken, UniTask<T>> task)
    {
        this.task = task;
    }

    public async UniTask<T> WaitAsync(CancellationToken ct)
    {
        internalCts?.Cancel();
        internalCts = new();

        var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(ct, internalCts.Token);

        return await task(linkedCts.Token);
    }
}

public class WaitingOperation
{
    private Func<CancellationToken, UniTask> task;
    private CancellationTokenSource internalCts;

    public void Subscribe(Func<CancellationToken, UniTask> task)
    {
        this.task = task;
    }

    public async UniTask WaitAsync(CancellationToken ct)
    {
        internalCts?.Cancel();
        internalCts = new();

        var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(ct, internalCts.Token);

        await task(linkedCts.Token);
    }
}