using Cysharp.Threading.Tasks.Linq;

public class QuestionPresenter : PresenterBase<QuestionView, QuestionModel>
{
    public QuestionPresenter(QuestionView view, QuestionModel model) : base(view, model)
    {
        model.Question.Subscribe(x => view.SetQuestion(x));
    }

    public override void Dispose()
    {
    }
}
