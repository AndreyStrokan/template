
public class QuestionModel : ModelBase
{
    private readonly ReactiveProperty<string> question = new();
    public IReactiveProperty<string> Question => question;

}
