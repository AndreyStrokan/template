using UnityEngine;

public class EnvironmentView : ViewBase
{
    [Header("Background")]
    [SerializeField]
    private SpriteRenderer sr_background;

    [SerializeField]
    private Transform tr_background;

    [Header("Character")]
    [SerializeField]
    private SpriteRenderer sr_character;

    [SerializeField]
    private Transform tr_character;

    public void SetBackgroundSprite(Sprite backgroundSprite)
    {
        sr_background.sprite = backgroundSprite;
    }

    public void SetBackgroundScale(Vector3 scale)
    {
        tr_background.localScale = scale;
    }

    public void SetCharacterSprite(Sprite characterSprite)
    {
        sr_character.sprite = characterSprite;
    }

    public void SetCharacterScale(Vector3 scale)
    {
        tr_character.localScale = scale;
    }
}
