using System.Collections.Generic;
using UnityEngine;

namespace Model.InGame
{
    [CreateAssetMenu(fileName = "GameSetting", menuName = "GameSetting", order = 0)]
    public class GameSetting : ScriptableObject
    {
        [SerializeField] private List<string> wordList;
        [SerializeField] private float gameTime;
    }
}