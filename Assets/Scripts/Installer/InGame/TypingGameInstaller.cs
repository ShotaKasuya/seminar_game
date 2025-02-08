using Domain.UseCase.InGame;
using Model.InGame;
using Module.Installer;
using Module.Serial;
using UnityEngine;

namespace Installer.InGame
{
        public class TypingGameInstaller:InstallerBase
    {
        [SerializeField] GameSettingModel gameSetting;
        protected override void CustomConfigure()
        {
            var questionResultEventModel = new QuestionResultEventModel();
            var port = GlobalLocator.Instance.Resolve<IPortWritable>();
            var missTypeCase = new MissTypeCase(questionResultEventModel, port, gameSetting);
        }
    }
}