using Cysharp.Threading.Tasks.Linq;
using System;
using System.Collections.Generic;

public class AnswersPresenter : PresenterBase<AnswersView, AnswersModel>
{
    private List<IDisposable> subscribes = new();

    public AnswersPresenter(AnswersView view, AnswersModel model) : base(view, model)
    {
        subscribes.Add(model.Answer1.Subscribe(x => view.SetAnswer1(x)));
        subscribes.Add(model.Answer2.Subscribe(x => view.SetAnswer2(x)));
        subscribes.Add(model.Answer3.Subscribe(x => view.SetAnswer3(x)));
        subscribes.Add(model.Answer4.Subscribe(x => view.SetAnswer4(x)));
    }

    public override void Dispose()
    {
        foreach (IDisposable disposable in subscribes)
        {
            disposable.Dispose();
        }
    }
}
