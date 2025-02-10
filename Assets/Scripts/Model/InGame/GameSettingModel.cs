using System.Collections.Generic;
using Domain.IModel.InGame;
using UnityEngine;

namespace Model.InGame
{
    [CreateAssetMenu(fileName = "GameSetting", menuName = "GameSetting", order = 0)]
    public class GameSettingModel : ScriptableObject,IElectricTimeModel,IQuestionWordModel
    {
        [SerializeField] private List<string> wordList;
        [SerializeField] private float gameTime;
        [SerializeField] private float attackTime;

        public string GetQuestion()
        {
            return wordList[Random.Range(0, wordList.Count)];
        }

        public float AttackTime => attackTime;
    }
}