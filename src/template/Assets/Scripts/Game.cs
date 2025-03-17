using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Scenario
{
    public Question[] Questions =
    {
        new()
        {
            Text = "Question 1",
            Answers = new Answer[]
            {
                new Answer()
                {
                    Text = "Answer 1",
                    Characteristics = new()
                    {
                        [Characteristic.Progressivity] = 10
                    },
                    NextQuestionIndex = 1
                },
                new Answer()
                {
                    Text = "Answer 2",
                    Characteristics = new()
                    {
                        [Characteristic.Emotions] = 8
                    },
                    NextQuestionIndex = 1
                },
                new Answer()
                {
                    Text = "Answer 3",
                    Characteristics = new()
                    {
                        [Characteristic.Selfishness] = 4,
                        [Characteristic.Altruism] = -5,
                    },
                    NextQuestionIndex = 1
                },
                new Answer()
                {
                    Text = "Answer 4",
                    Characteristics = new()
                    {
                        [Characteristic.Logics] = -10
                    },
                    NextQuestionIndex = 1
                }
            }
        },
        new()
        {
            Text = "Question 2",
            Answers = new Answer[]
            {
                new Answer()
                {
                    Text = "Answer 1",
                    Characteristics = new()
                    {
                        [Characteristic.Progressivity] = 10
                    },
                    NextQuestionIndex = 0
                },
                new Answer()
                {
                    Text = "Answer 2",
                    Characteristics = new()
                    {
                        [Characteristic.Emotions] = 8
                    },
                    NextQuestionIndex = 0
                },
                new Answer()
                {
                    Text = "Answer 3",
                    Characteristics = new()
                    {
                        [Characteristic.Selfishness] = 4,
                        [Characteristic.Altruism] = -5,
                    },
                    NextQuestionIndex = 0
                },
                new Answer()
                {
                    Text = "Answer 4",
                    Characteristics = new()
                    {
                        [Characteristic.Logics] = -10
                    },
                    NextQuestionIndex = 0
                }
            }
        }
    };


}

public class Question
{
    public string Text { get; set; }
    public Answer[] Answers { get; set; }
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

    public async UniTask StartAsync(Scenario scenario, CancellationToken ct)
    {
        var state = new Dictionary<Characteristic, int>();
        var questionIndex = 0;
        while (!ct.IsCancellationRequested)
        {
            questionModel.Question.Value = scenario.Questions[questionIndex].Text;
            answersModel.Answers.Value = scenario.Questions[questionIndex].Answers;

            var selectedAnswerIndex = await answersModel.PlayerInput.WaitAsync(ct);
            var selectedAnswer = scenario.Questions[questionIndex].Answers[selectedAnswerIndex];

            foreach (var selectedAnswerCharacteristic in selectedAnswer.Characteristics)
            {
                if (!state.ContainsKey(selectedAnswerCharacteristic.Key))
                {
                    state.Add(selectedAnswerCharacteristic.Key, 0);
                }

                state[selectedAnswerCharacteristic.Key] += selectedAnswerCharacteristic.Value;
            }

            questionIndex = selectedAnswer.NextQuestionIndex;
        }
    }
}
