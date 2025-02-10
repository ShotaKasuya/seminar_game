using System;
using Domain.IModel.InGame;
using Domain.IView.InGame;
using UnityEngine;

namespace Domain.UseCase.InGame
{
    /// <summary>
    /// 入力された文字が正しいかを判定する
    /// </summary>
    public class JudgeTypeCase : IDisposable
    {
        public JudgeTypeCase
        (
            IPlayerAnswerModel playerAnswerModel,
            IQuestionModel questionModel,
            IQuestionResultModel questionResultModel,
            IPlayerTypeView playerTypeView
            // IGameStateModel gameStateModel
        )
        {
            PlayerAnswerModel = playerAnswerModel;
            QuestionModel = questionModel;
            QuestionResultModel = questionResultModel;
            PlayerTypeView = playerTypeView;
            // GameStateModel = gameStateModel;

            playerTypeView.TypeEvent += OnType;
        }

        private void OnType(char input)
        {
            // if (!GameStateModel.IsPlaying())
            // {
            //    return; 
            // }

            var cursor = PlayerAnswerModel.NextCursor;
            var result = Judge(input, cursor);
            switch (result)
            {
                case JudgeResultType.Correct:
                {
                    PlayerAnswerModel.Success();
                    break;
                }
                case JudgeResultType.Incorrect:
                {
                    QuestionResultModel.OnFail(input);
                    break;
                }
                case JudgeResultType.Complete:
                {
                    QuestionResultModel.OnSuccess();
                    break;
                }
            }
        }

        private enum JudgeResultType
        {
            Correct,
            Incorrect,
            Complete,
        }

        private JudgeResultType Judge(char currentInput, int nextCursor)
        {
            var question = QuestionModel.Question;

            var next = question[nextCursor];
            var isEqual = currentInput == next;

            if (!isEqual)
            {
                return JudgeResultType.Incorrect;
            }

            if (nextCursor == question.Length - 1)
            {
                return JudgeResultType.Complete;
            }

            return JudgeResultType.Correct;
        }

        private IPlayerAnswerModel PlayerAnswerModel { get; }
        private IQuestionModel QuestionModel { get; }
        private IQuestionResultModel QuestionResultModel { get; }
        private IPlayerTypeView PlayerTypeView { get; }
        // private IGameStateModel GameStateModel { get; }

        public void Dispose()
        {
            PlayerTypeView.TypeEvent += OnType;
        }
    }
}