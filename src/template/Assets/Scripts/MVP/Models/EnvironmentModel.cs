using UnityEngine;

public class EnvironmentModel : ModelBase
{
    // Character.
    private readonly ReactiveProperty<Sprite> characterSprite = new();
    public IReactiveProperty<Sprite> CharacterSprite => characterSprite;

    private readonly ReactiveProperty<Vector3> characterScale = new();
    public IReactiveProperty<Vector3> CharacterScale => characterScale;

    // Background.
    private readonly ReactiveProperty<Sprite> backgroundSprite = new();
    public IReactiveProperty<Sprite> BackgroundSprite => backgroundSprite;

    private readonly ReactiveProperty<Vector3> backgroundScale = new();
    public IReactiveProperty<Vector3> BackgroundScale => backgroundScale;
}
