using Cysharp.Threading.Tasks;

public class QuestionModel : ModelBase
{
    protected readonly AsyncReactiveProperty<string> question = new(null);
    public IAsyncReactiveProperty<string> Question => question;

}
