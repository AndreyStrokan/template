using TMPro;
using UnityEngine;

public class QuestionView : ViewBase
{
    [SerializeField]
    private TMP_Text txt_Question;

    [SerializeField]
    private TMP_Text txt_CharacterName;

    public void SetQuestion(string question)
    {
        txt_Question.text = question;
    }

    public void SetCharacterName(string characterName)
    {
        txt_CharacterName.text = characterName;
    }
}
