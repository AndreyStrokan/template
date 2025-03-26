using UnityEngine;

public class EnvironmentModel : ModelBase
{
    private readonly ReactiveProperty<Sprite> characterSprite = new();
    public IReactiveProperty<Sprite> CharacterSprite => characterSprite;

    private readonly ReactiveProperty<Sprite> backgroundSprite = new();
    public IReactiveProperty<Sprite> BackgroundSprite => backgroundSprite;

}
