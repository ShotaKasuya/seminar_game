using Domain.UseCase.InGame;
using Model.InGame;
using Module.Installer;
using Module.Serial;
using UnityEngine;
using View.InGame;

namespace Installer.InGame
{
        public class TypingGameInstaller:InstallerBase
    {
        [SerializeField] GameSettingModel gameSetting;
        [SerializeField] UiElementView uiElementView;
        protected override void CustomConfigure()
        {
            var questionResultEventModel = new QuestionResultEventModel();
            var port = GlobalLocator.Instance.Resolve<IPortWritable>();
            var missTypeCase = new MissTypeCase(questionResultEventModel, port, gameSetting);
            var questionModel = new QuestionModel();
            var judgeTypeCase = new JudgeTypeCase(questionModel, questionModel, questionResultEventModel, uiElementView);
            var completeTypeCase = new CompleteTypeCase(questionResultEventModel, gameSetting, questionModel);
            var timerModel = new TimerModel();
            var timeUpdateCase = new TimeUpdateCase(timerModel, uiElementView);
            
        }
    }
}