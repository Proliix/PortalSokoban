﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PortalSokoban
{
    public class Board
    {
        //                                                                              Constants
        // BoardObject list:
        // 0 = Ground
        // 1 = Wall
        // 2 = Box
        // 3 = Button
        // 4 = Door
        // 5 = Player
        // 6 = P1Up             // P1 = Portal 1
        // 7 = P1Right
        // 8 = P1Down
        // 9 = P1Left
        // A = P2Up             // P2 = Portal 2
        // B = P2Right
        // C = P2Down
        // D = P2Left
        private const int MAX_LVL = 1;
        //                                                                              Instance variables
        public const int CELL_WIDTH = 60;
        public const int CELL_HEIGHT = 60;
        private char[,] GRID;

//                                                                                      Constructor
        public Board(int cell_width, int cell_height, int gridX, int gridY)
        {
            CELL_HEIGHT = cell_height;
            CELL_WIDTH = cell_width;
            GRID = new char[gridY,gridX];
        }

        public void createLvl(int x)
        {
            if (x > MAX_LVL) return;

            switch (x) {


            } 
                
            
        }



    }
}
