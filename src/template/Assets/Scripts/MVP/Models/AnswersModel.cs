public class AnswersModel : ModelBase
{
    private readonly ReactiveProperty<AnswerDTO[]> answers = new();
    public IReactiveProperty<AnswerDTO[]> Answers => answers;

    private readonly WaitingOperation<int> playerInput = new();
    public WaitingOperation<int> PlayerInput => playerInput;
}