using Cysharp.Threading.Tasks;

public class AnswersModel : ModelBase
{
    protected readonly AsyncReactiveProperty<string> answer1 = new(null);
    public IAsyncReactiveProperty<string> Answer1 => answer1;

    protected readonly AsyncReactiveProperty<string> answer2 = new(null);
    public IAsyncReactiveProperty<string> Answer2 => answer2;

    protected readonly AsyncReactiveProperty<string> answer3 = new(null);
    public IAsyncReactiveProperty<string> Answer3 => answer3;

    protected readonly AsyncReactiveProperty<string> answer4 = new(null);
    public IAsyncReactiveProperty<string> Answer4 => answer4;
}
