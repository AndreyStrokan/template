public class EnvironmentPresenter : PresenterBase<EnvironmentView, EnvironmentModel>
{
    public EnvironmentPresenter(EnvironmentView view, EnvironmentModel model) : base(view, model)
    {
        Model.BackgroundSprite.PropertyChanged += OnBackgroundSpriteUpdated;
        Model.CharacterSprite.PropertyChanged += OnCharacterSpriteUpdated;
    }

    private void OnCharacterSpriteUpdated()
    {
        View.SetCharacterSprite(Model.CharacterSprite.Value);
    }

    private void OnBackgroundSpriteUpdated()
    {
        View.SetBackgroundSprite(Model.BackgroundSprite.Value);
    }

    public override void Dispose()
    {
        Model.BackgroundSprite.PropertyChanged += OnBackgroundSpriteUpdated;
        Model.CharacterSprite.PropertyChanged += OnCharacterSpriteUpdated;
    }
}
