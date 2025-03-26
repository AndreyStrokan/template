using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AnswersView : ViewBase
{
    [Header("Prefabs")]
    [SerializeField]
    private AnswerControl answerPrefabDescriptor;

    [Header("Scene")]
    [SerializeField]
    private Transform grp_Container;

    private List<AnswerControl> instantiatedAnswers = new();

    private CancellationTokenSource internalWaitingCts;

    public async UniTask<int> WaitPlayerInputAsync(CancellationToken ct)
    {
        internalWaitingCts?.Cancel();
        internalWaitingCts = new();

        var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(ct, internalWaitingCts.Token);

        var tasks = new List<UniTask>();
        foreach (var answer in instantiatedAnswers)
        {
            tasks.Add(answer.OnClickAsync(linkedCts.Token));
        }

        var index = await UniTask.WhenAny(tasks).AttachExternalCancellation(linkedCts.Token);
        return index;
    }

    public void CreateAnswer(AnswerDTO answer)
    {
        var answerControl = Instantiate(answerPrefabDescriptor, grp_Container.transform);
        answerControl.Answer = answer.Text;
        answerControl.Interabtable = true;
        instantiatedAnswers.Add(answerControl);
    }

    public void Clear()
    {
        foreach (var answer in instantiatedAnswers)
        {
            Destroy(answer.gameObject);
        }

        instantiatedAnswers.Clear();
    }

    private void OnDestroy()
    {
        Clear();
    }
}
