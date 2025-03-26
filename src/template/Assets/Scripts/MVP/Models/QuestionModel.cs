
public class QuestionModel : ModelBase
{
    private readonly ReactiveProperty<string> question = new();
    public IReactiveProperty<string> Question => question;

    private readonly ReactiveProperty<string> characterName = new();
    public IReactiveProperty<string> CharacterName => characterName;
}
