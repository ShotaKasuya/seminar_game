using System.Collections.Generic;
using Domain.IModel.InGame;
using Module.RichText;
using UnityEngine;

namespace Model.InGame
{
    [CreateAssetMenu(fileName = "GameSetting", menuName = "GameSetting", order = 0)]
    public class GameSettingModel : ScriptableObject,IElectricTimeModel,IQuestionWordModel, ITextColorModel
    {
        [SerializeField] private List<string> wordList;
        [SerializeField] private float gameTime;
        [SerializeField] private float attackTime;
        [SerializeField] private TextColorType inputColor;
        [SerializeField] private TextColorType questionColor;

        public string GetQuestion()
        {
            return wordList[Random.Range(0, wordList.Count)];
        }

        public float AttackTime => attackTime;
        public TextColorType InputColorType => inputColor;
        public TextColorType QuestionColorType => questionColor;
    }
}