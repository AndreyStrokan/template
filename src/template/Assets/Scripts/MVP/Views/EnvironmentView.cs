using UnityEngine;

public class EnvironmentView : ViewBase
{
    [SerializeField]
    private SpriteRenderer background;

    [SerializeField]
    private SpriteRenderer character;

    public void SetBackgroundSprite(Sprite backgroundSprite)
    {
        background.sprite = backgroundSprite;
    }

    public void SetCharacterSprite(Sprite characterSprite)
    {
        character.sprite = characterSprite;
    }
}
