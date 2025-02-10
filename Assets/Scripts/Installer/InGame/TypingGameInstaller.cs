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
            var port = GlobalLocator.Instance.Resolve<IPortWritable>();
            // View
            var inputView = new InputView();
            RegisterEntryPoints(inputView);
            
            // Model
            var questionResultEventModel = new QuestionResultEventModel();
            var questionModel = new QuestionModel();
            var timerModel = new TimerModel();
            var scoreModel = new ScoreModel();
            
            // UseCase
            var calculationCase = new CalculationCase(questionResultEventModel, scoreModel);
            var missTypeCase = new MissTypeCase(questionResultEventModel, port, gameSetting);
            var judgeTypeCase = new JudgeTypeCase(questionModel, questionModel, questionResultEventModel, inputView);
            var setQuestionCase = new SetQuestionCase(gameSetting, questionModel, uiElementView, questionResultEventModel);
            var timeUpdateCase = new TimeUpdateCase(timerModel, uiElementView);
            var uiUpdateCase = new UiUpdateCase(scoreModel, uiElementView, questionModel, uiElementView, gameSetting);
            RegisterEntryPoints(timeUpdateCase);
        }
    }
}