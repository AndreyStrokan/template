public class EnvironmentPresenter : PresenterBase<EnvironmentView, EnvironmentModel>
{
    public EnvironmentPresenter(EnvironmentView view, EnvironmentModel model) : base(view, model)
    {
        // Background.
        Model.BackgroundSprite.PropertyChanged += OnBackgroundSpriteUpdated;
        Model.BackgroundScale.PropertyChanged += OnBackgroundScaleUpdated;

        // Character.
        Model.CharacterSprite.PropertyChanged += OnCharacterSpriteUpdated;
        Model.CharacterScale.PropertyChanged += OnCharacterScaleUpdated;
    }

    // Background.
    private void OnBackgroundSpriteUpdated()
    {
        View.SetBackgroundSprite(Model.BackgroundSprite.Value);
    }

    private void OnBackgroundScaleUpdated()
    {
        View.SetBackgroundScale(Model.BackgroundScale.Value);
    }

    // Character.
    private void OnCharacterSpriteUpdated()
    {
        View.SetCharacterSprite(Model.CharacterSprite.Value);
    }

    private void OnCharacterScaleUpdated()
    {
        View.SetCharacterScale(Model.CharacterScale.Value);
    }

    public override void Dispose()
    {
        Model.BackgroundSprite.PropertyChanged += OnBackgroundSpriteUpdated;
        Model.CharacterSprite.PropertyChanged += OnCharacterSpriteUpdated;
    }
}
