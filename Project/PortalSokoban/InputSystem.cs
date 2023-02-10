using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;

namespace PortalSokoban
{
    public class InputSystem
    {
        public static InputSystem INSTANCE;
        private const int NOKEY = -1;
        public const int UP = 0;
        public const int DOWN = 1;
        public const int LEFT = 2;
        public const int RIGHT = 3;

        int currentInput = NOKEY;
        int lastInput = NOKEY;
        List<IReciveInput> recivers;

        float cooldown = 0.125f;
        float timer;

        public InputSystem()
        {
            INSTANCE = this;
            recivers = new List<IReciveInput>();
        }

        public void Add(IReciveInput reciver)
        {
            recivers.Add(reciver);
        }

        int GetInput()
        {
            bool hasLastInput = currentInput == lastInput && currentInput != NOKEY;
            if (Keyboard.GetState().IsKeyDown(Keys.Up) && (lastInput != UP || currentInput != UP))
                return UP;
            if (Keyboard.GetState().IsKeyDown(Keys.Down) && (lastInput != DOWN || currentInput != DOWN))
                return DOWN;
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && (lastInput != LEFT || currentInput != LEFT))
                return LEFT;
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && (lastInput != RIGHT || currentInput != RIGHT))
                return RIGHT;

            if (hasLastInput && Keyboard.GetState().GetPressedKeyCount() > 0) return lastInput;
            return NOKEY;
        }

        public void Update(float dt)
        {
            timer += dt;

            if (timer >= cooldown)
            {

                currentInput = GetInput();

                if (currentInput != NOKEY)
                {
                    foreach (var item in recivers)
                    {
                        if (item != null)
                            item.ReciveInput(currentInput);
                        else
                            recivers.Remove(item);
                    }
                }

                if (currentInput >= 0)
                {
                    timer = 0;
                    lastInput = currentInput;
                }
            }
        }

    }
}
