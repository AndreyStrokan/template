using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Models.
    private QuestionModel questionModel;
    private AnswersModel answersModel;

    public void Initialize(QuestionModel questionModel, AnswersModel answersModel)
    {
        this.questionModel = questionModel;
        this.answersModel = answersModel;
    }

    public async UniTask StartAsync(CancellationToken ct)
    {
        int i = 0;
        while (!ct.IsCancellationRequested)
        {
            questionModel.Question.Value = i.ToString();

            answersModel.Answer1.Value = (i+1).ToString();
            answersModel.Answer2.Value = (i+2).ToString();
            answersModel.Answer3.Value = (i+3).ToString();
            answersModel.Answer4.Value = (i+4).ToString();

            await UniTask.Delay(1000);
            i++;
        }
    }
}
