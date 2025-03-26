public class QuestionPresenter : PresenterBase<QuestionView, QuestionModel>
{
    public QuestionPresenter(QuestionView view, QuestionModel model) : base(view, model)
    {
        Model.Question.PropertyChanged += OnQuestionUpdated;
        Model.CharacterName.PropertyChanged += OnCharacterNameUpdated;
    }

    private void OnQuestionUpdated()
    {
        View.SetQuestion(Model.Question.Value);
    }

    private void OnCharacterNameUpdated()
    {
        View.SetCharacterName(Model.CharacterName.Value);
    }

    public override void Dispose()
    {
        Model.Question.PropertyChanged -= OnQuestionUpdated;
        Model.CharacterName.PropertyChanged -= OnCharacterNameUpdated;
    }
}
