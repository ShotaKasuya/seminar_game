using System;
using Domain.IView.InGame;
using Module.Installer;
using Module.KeyMap;
using UnityEngine;

namespace View.InGame
{
    public class InputView: ITickable, IPlayerTypeView
    {
        public Action<char> TypeEvent { get; set; }
        public void Tick(float deltaTime)
        {
            foreach (var key in InputCharMapper.KeyToCharMap.Keys)
            {
                if (Input.GetKeyDown(key))
                {
                    if (InputCharMapper.TryGetChar(key, out char character))
                    {
                        TypeEvent?.Invoke(character);
                    }
                }
            }
        }
    }
}