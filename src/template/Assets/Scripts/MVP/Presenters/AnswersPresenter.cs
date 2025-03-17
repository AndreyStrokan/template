public class AnswersPresenter : PresenterBase<AnswersView, AnswersModel>
{
    public AnswersPresenter(AnswersView view, AnswersModel model) : base(view, model)
    {
        Model.Answers.PropertyChanged += OnAnswersUpdated;

        Model.PlayerInput.Subscribe(View.WaitPlayerInputAsync);
    }

    private void OnAnswersUpdated()
    {
        View.Clear();

        foreach (var answer in Model.Answers.Value)
        {
            View.CreateAnswer(answer);
        }
    }

    public override void Dispose()
    {
        Model.Answers.PropertyChanged -= OnAnswersUpdated;
    }
}
