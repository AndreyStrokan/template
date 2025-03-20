using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ActorDTO
{
    public string Name { get; set; }
    public byte[] PNGImage { get; set; }
}

public class EnvironmentDTO
{
    public byte[] PNGImage { get; set; }
}

public class QuestionDTO
{
    public string Text { get; set; }
    public AnswerDTO[] Answers { get; set; }
}

public class ScenarioNodeDTO
{
    public int ActorId { get; set; }
    public int EnvironmentId { get; set; }

    // QuestionId IF CharacteristicId matches Condition
    public Dictionary<int, Dictionary<int, ConditionDTO>> QuestionSelectionCondition;
}

public class ScenarioDTO
{
    public ActorDTO[] Actors =
    {
        new()
        {
            Name = "Trump",
            PNGImage = new byte[0]
        },
        new()
        {
            Name = "Elon",
            PNGImage = new byte[0]
        }
    };

    public string[] Characteristics =
    {
        "EmotionsAndLogics",
        "SelfishnessAndAltruism",
        "ProgressivityAndConservatism",
        "DiplomacyAndAggression"
    };

    public EnvironmentDTO[] Environments =
    {
        new()
        {
            PNGImage = new byte[0]
        }
    };

    public QuestionDTO[] Questions =
    {
        new()
        {
            Text = "Question 1",
            Answers = new AnswerDTO[]
            {
                new AnswerDTO()
                {
                    Text = "Answer 1",
                    ImpactOnCharacteristics = new()
                    {
                        [2] = 10
                    },
                    AvailabilityCondition =
                    {
                        [2] = new()
                        {
                            Type = ConditionType.MoreThan,
                            Value = 10
                        }
                    }
                },
                new AnswerDTO()
                {
                    Text = "Answer 2",
                    ImpactOnCharacteristics = new()
                    {
                        [0] = 8
                    },
                },
                new AnswerDTO()
                {
                    Text = "Answer 3",
                    ImpactOnCharacteristics = new()
                    {
                        [1] = -5,
                    },
                },
                new AnswerDTO()
                {
                    Text = "Answer 4",
                    ImpactOnCharacteristics = new()
                    {
                        [0] = -10
                    },
                }
            }
        },
        new()
        {
            Text = "Question 2",
            Answers = new AnswerDTO[]
            {
                new AnswerDTO()
                {
                    Text = "Answer 1",
                    ImpactOnCharacteristics = new()
                    {
                        [2] = 10
                    },
                },
                new AnswerDTO()
                {
                    Text = "Answer 2",
                    ImpactOnCharacteristics = new()
                    {
                        [0] = 8
                    },
                },
                new AnswerDTO()
                {
                    Text = "Answer 3",
                    ImpactOnCharacteristics = new()
                    {
                        [1] = -5,
                    },
                },
                new AnswerDTO()
                {
                    Text = "Answer 4",
                    ImpactOnCharacteristics = new()
                    {
                        [0] = -10
                    },
                }
            }
        }
    };

    public ScenarioNodeDTO[] Nodes =
    {
        new()
        {
            ActorId = 0,
            EnvironmentId = 0,
            QuestionSelectionCondition = new()
            {
                [0] = new(), // Default
                [1] = new()
                {
                    [1] = new()
                    {
                        Type = ConditionType.MoreThan,
                        Value = 10
                    }
                },
                [2] = new()
                {
                    [1] = new()
                    {
                        Type = ConditionType.LessThan,
                        Value = 10
                    }
                },
                [3] = new()
                {
                    [0] = new()
                    {
                        Type = ConditionType.LessThan,
                        Value = 3
                    },
                    [1] = new()
                    {
                        Type = ConditionType.MoreThan,
                        Value = 5
                    }
                },
            }
        }
    };
}


public class Game : MonoBehaviour
{
    // Models.
    private QuestionModel questionModel;
    private AnswersModel answersModel;

    public void Initialize(QuestionModel questionModel, AnswersModel answersModel)
    {
        this.questionModel = questionModel;
        this.answersModel = answersModel;
    }

    public async UniTask StartAsync(ScenarioDTO scenario, CancellationToken ct)
    {
        var state = new Dictionary<Characteristic, int>();
        var questionIndex = 0;
        while (!ct.IsCancellationRequested)
        {
            questionModel.Question.Value = scenario.Questions[questionIndex].Text;
            answersModel.Answers.Value = scenario.Questions[questionIndex].Answers;

            var selectedAnswerIndex = await answersModel.PlayerInput.WaitAsync(ct);
            var selectedAnswer = scenario.Questions[questionIndex].Answers[selectedAnswerIndex];

            foreach (var selectedAnswerCharacteristic in selectedAnswer.ImpactOnCharacteristics)
            {
                //if (!state.ContainsKey(selectedAnswerCharacteristic.Key))
                //{
                //    state.Add(selectedAnswerCharacteristic.Key, 0);
                //}
                //
                //state[selectedAnswerCharacteristic.Key] += selectedAnswerCharacteristic.Value;
            }
        }
    }
}
