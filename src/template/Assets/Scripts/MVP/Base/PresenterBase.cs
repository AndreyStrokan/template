using System;

public abstract class PresenterBase<TView, TModel> : IDisposable where TView : ViewBase where TModel : ModelBase
{
    private readonly TView view;

    protected TView View => view;

    private readonly TModel model;

    protected TModel Model => model;

    public PresenterBase(TView view, TModel model)
    {
        this.view = view;
        this.model = model;
    }

    public abstract void Dispose();
}
