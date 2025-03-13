using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswersView : ViewBase
{
    [Header("Answer 1")]
    [SerializeField]
    private Button btn_Answer1;

    [SerializeField]
    private TMP_Text txt_Answer1;

    [Header("Answer 2")]
    [SerializeField]
    private Button btn_Answer2;

    [SerializeField]
    private TMP_Text txt_Answer2;

    [Header("Answer 3")]
    [SerializeField]
    private Button btn_Answer3;

    [SerializeField]
    private TMP_Text txt_Answer3;

    [Header("Answer 4")]
    [SerializeField]
    private Button btn_Answer4;

    [SerializeField]
    private TMP_Text txt_Answer4;

    public void SetAnswer1(string text)
    {
        txt_Answer1.text = text;
    }

    public void SetAnswer2(string text)
    {
        txt_Answer2.text = text;
    }

    public void SetAnswer3(string text)
    {
        txt_Answer3.text = text;
    }

    public void SetAnswer4(string text)
    {
        txt_Answer4.text = text;
    }
}
