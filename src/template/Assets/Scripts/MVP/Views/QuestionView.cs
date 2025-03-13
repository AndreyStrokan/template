using TMPro;
using UnityEngine;

public class QuestionView : ViewBase
{
    [SerializeField]
    private TMP_Text txt_Question;

    public void SetQuestion(string question)
    {
        txt_Question.text = question;
    }
}
