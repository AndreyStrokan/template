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

    [SerializeField]
    private EnvironmentView environmentView;

    [Header("Mock")]
    [SerializeField]
    private Sprite characterSprite;

    [SerializeField]
    private Sprite backgroundSprite;

    // Resolved Services.
    private ILoggerService loggerService;
    private ISceneLoaderService sceneLoaderService;

    // Presenters.
    private QuestionPresenter questionPresenter;
    private AnswersPresenter answersPresenter;
    private EnvironmentPresenter environmentPresenter;

    // Models
    private QuestionModel questionModel;
    private AnswersModel answersModel;
    private EnvironmentModel environmentModel;

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

        // Initialize Environment.
        environmentModel = new();
        environmentPresenter = new(environmentView, environmentModel);

        // Move to Game.cs in the future.
        environmentModel.CharacterSprite.Value = characterSprite;
        environmentModel.CharacterScale.Value = Vector3.one * 1.8f;
        environmentModel.BackgroundSprite.Value = backgroundSprite;
        environmentModel.BackgroundScale.Value = Vector3.one * 1.6f;

        game.Initialize(questionModel, answersModel, environmentModel);
        await game.StartAsync(new(), ct);
    }


    protected override void DeInitialize()
    {
        questionPresenter.Dispose();
        answersPresenter.Dispose();
        environmentPresenter.Dispose();
    }
}
