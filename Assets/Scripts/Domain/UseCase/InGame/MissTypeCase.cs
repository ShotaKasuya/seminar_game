using Domain.IModel.InGame;

namespace Domain.UseCase.InGame
{
    public class MissTypeCase
    {
        public MissTypeCase
        (
            IFailEventModel onFailEvent
        )
        {
            FailEventModel = onFailEvent;
        }

        private void OnFailEvent()
        {
            
        }
        
        private IFailEventModel FailEventModel { get; }
    }
}