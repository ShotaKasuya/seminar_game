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
            ICurrentTypeModel currentTypeModel,
            IQuestionModel questionModel,
            IQuestionResultModel questionResultModel,
            IInputView inputView
        )
        {
            CurrentTypeModel = currentTypeModel;
            QuestionModel = questionModel;
            QuestionResultModel = questionResultModel;
            InputView = inputView;

            inputView.ValueChangedEvent += OnChange;
        }

        private void OnChange(string input)
        {
            var nextCursor = CurrentTypeModel.NextCursor;
            // todo! : 文字の削除が行われた場合、文字列のロールバック及び警告文の表示を行う
            if (input.Length - 1 != nextCursor)
            {
                Debug.LogError("don't use backspace");
                return;
            }

            var currentInput = input[^1];

            var result = Judge(currentInput, nextCursor);
            switch (result)
            {
                case JudgeResultType.Correct:
                {
                    CurrentTypeModel.Success();
                    break;
                }
                case JudgeResultType.Incorrect:
                {
                    QuestionResultModel.OnFail(currentInput);
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

        private ICurrentTypeModel CurrentTypeModel { get; }
        private IQuestionModel QuestionModel { get; }
        private IQuestionResultModel QuestionResultModel { get; }
        private IInputView InputView { get; }

        public void Dispose()
        {
            InputView.ValueChangedEvent -= OnChange;
        }
    }
}