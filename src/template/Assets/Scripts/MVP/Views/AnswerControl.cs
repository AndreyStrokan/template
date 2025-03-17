using Cysharp.Threading.Tasks;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AnswerControl : MonoBehaviour
{
    [SerializeField]
    private Button btn_Answer;

    [SerializeField]
    private TMP_Text txt_Answer;

    public async UniTask OnClickAsync(CancellationToken ct)
    {
        await btn_Answer.OnClickAsync(ct);
    }

    public bool Interabtable
    {
        get => btn_Answer.interactable;
        set
        {
            btn_Answer.interactable = value;
        }
    }

    public string Answer
    {
        get => txt_Answer.text;
        set
        {
            txt_Answer.text = value;
        }
    }
}