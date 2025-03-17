public class AnswersModel : ModelBase
{
    private readonly ReactiveProperty<Answer[]> answers = new();
    public IReactiveProperty<Answer[]> Answers => answers;

    private readonly WaitingOperation<int> playerInput = new();
    public WaitingOperation<int> PlayerInput => playerInput;
}