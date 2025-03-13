using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

public class GameSceneContext : SceneContextBase
{
    [Header("Game")]
    [SerializeField]
    private Game game;

    [Header("Views")]
    [SerializeField]
    private QuestionView questionView;

    [SerializeField]
    private AnswersView answersView;

    // Resolved Services.
    private ILoggerService loggerService;
    private ISceneLoaderService sceneLoaderService;

    // Presenters.
    private QuestionPresenter questionPresenter;
    private AnswersPresenter answersPresenter;

    // Models
    private QuestionModel questionModel;
    private AnswersModel answersModel;

    protected override void ResolveServices(IServiceResolver serviceResolver)
    {
        loggerService = serviceResolver.Resolve<ILoggerService>();
        sceneLoaderService = serviceResolver.Resolve<ISceneLoaderService>();
    }

    protected override void RegisterServices(IServiceRegistrar serviceRegistrar)
    {
    }

    protected override async UniTask InitializeAsync(CancellationToken ct)
    {
        // Initialize Question.
        questionModel = new();
        questionPresenter = new(questionView, questionModel);

        // Initialize Answers.
        answersModel = new();
        answersPresenter = new(answersView, answersModel);

        game.Initialize(questionModel, answersModel);
        await game.StartAsync(ct);
    }


    protected override void DeInitialize()
    {
        questionPresenter.Dispose();
        answersPresenter.Dispose();
    }
}
