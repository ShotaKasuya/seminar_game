using Module.RichText;

namespace Domain.IModel.InGame
{
    public interface ITextColorModel
    {
        public TextColorType InputColorType { get; }
        public TextColorType QuestionColorType { get; }
    }
}