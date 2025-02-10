using Module.RichText;

namespace Domain.IView.InGame
{
    public interface IQuestionView
    {
        public void ShowText(string text);
    }

    public static class WordDisplayExtension
    {
        public static void ShowInputAndQuestion(
            this IQuestionView questionView, int inputCursor, TextColorType inputColor, string question,
            TextColorType questionColor
        )
        {
            var resultText = question;
            if (inputCursor > 0)
            {
                var inputText = question[..inputCursor];
                var notInputText = question[inputCursor..];

                resultText =
                    $"{RichTextColor.ApplyColor(inputText, inputColor)}{RichTextColor.ApplyColor(notInputText, questionColor)}";
            }

            questionView.ShowText(resultText);
        }
    }
}