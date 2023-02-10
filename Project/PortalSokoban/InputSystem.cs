using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Input;

namespace PortalSokoban
{
    public class InputSystem
    {
        public static InputSystem INSTANCE;
        public const int UP = 0;
        public const int DOWN = 1;
        public const int LEFT = 2;
        public const int RIGHT = 3;

        int currentInput = -1;
        List<IReciveInput> recivers;

        public InputSystem()
        {
            INSTANCE = this;
            recivers = new List<IReciveInput>();
        }

        public void Add(IReciveInput reciver)
        {
            recivers.Add(reciver);
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                currentInput = UP;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                currentInput = DOWN;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                currentInput = LEFT;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                currentInput = RIGHT;


            foreach (var item in recivers)
            {
                if (item != null)
                    item.ReciveInput(currentInput);
                else
                    recivers.Remove(item);
            }

            currentInput = -1;
        }

    }
}
