using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
//using NUnit.Framework;
using System;
/*
 *                                                                                                  ████████████████████████████████████
 *                                                                                                  ██                                ██
 *                                                                                                  ██      TO FIX !!!!!!!            ██
 *                                                                                                  ████████████████████████████████████
 *                                                                                                  - NUnit.Framework cant find?!
 *                                                                                                  - 
 */
namespace PortalSokoban
{
    public class Board
    {
        //                                                                              Constants
        //                                              B O A R D - O B J E C T S
        // BoardObject list:
        #region
        public const char GROUND = 'G';
        public const char WALL = 'W';
        public const char BOX = 'B';
        public const char KNAPP = 'K';
        public const char DOOR = 'D';
        public const char PLAYER = 'P';
        #endregion
        //-------------------------------------------------------------------------------------------------------------
        // BoardTexture list:
        #region
        private const int TotalGroundTiles = 5;

        private const int GroundTile0 = 0;
        public readonly Texture2D TGroundTile0;

        private const int GroundTile1 = 1;
        public readonly Texture2D TGroundTile1;

        private const int GroundTile2 = 2;
        public readonly Texture2D TGroundTile2;

        private const int GroundTile3 = 3;
        public readonly Texture2D TGroundTile3;

        private const int GroundTile4 = 4;
        public readonly Texture2D TGroundTile4;
        #endregion
        //-------------------------------------------------------------------------------------------------------------
        // WallTexture list:
        #region
        private const int TotalWallTiles = 5;

        private const int WallTile0 = 5;
        public readonly Texture2D TWallTile0;

        private const int WallTile1 = 6;
        public readonly Texture2D TWallTile1;

        private const int WallTile2 = 7;
        public readonly Texture2D TWallTile2;

        private const int WallTile3 = 8;
        public readonly Texture2D TWallTile3;

        private const int WallTile4 = 9;
        public readonly Texture2D TWallTile4;

        #endregion
        
        
        private const int MAX_LVL = 1;
        //                                                                              Instance variables
        public const int CELL_WIDTH = 60;
        public const int CELL_HEIGHT = 60;
        private char[,] GRID;

//                                                                                      Constructor
        public Board(int gridX, int gridY)
        {
            createLvl(1);
        }

        public void createLvl(int x)
        {
            if (x > MAX_LVL) return;
            switch (x) {
                                                        // LOAD LVL1
                case 1:
                    createLvl1();
                    GRID = createLvl1();
                    break;
                
            } 
                
            
        }
        public char[,] createLvlW()
        {
            char[,] _Wrid;


            _Wrid = new char[18, 32] {
                    { 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W'},
                    { 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W'},
                    { 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W'},
                    { 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W'},
                    { 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W'},
                    { 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'P', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W'},
                    { 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W'},
                    { 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W'},
                    { 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W'},
                    { 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W'},
                    { 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W'},
                    { 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W'},
                    { 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W'},
                    { 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W'},
                    { 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W'},
                    { 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W'},
                    { 'W', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'G', 'W'},
                    { 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W', 'W'} };

            return _Wrid;
        }
        

    }
}
