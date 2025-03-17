public class QuestionPresenter : PresenterBase<QuestionView, QuestionModel>
{
    public QuestionPresenter(QuestionView view, QuestionModel model) : base(view, model)
    {
        Model.Question.PropertyChanged += OnQuestionUpdated;
    }

    private void OnQuestionUpdated()
    {
        View.SetQuestion(Model.Question.Value);
    }

    public override void Dispose()
    {
        Model.Question.PropertyChanged -= OnQuestionUpdated;
    }
}
