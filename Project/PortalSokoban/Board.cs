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
using SharpDX.Direct3D9;
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
        public const int CELL_WIDTH = 60;
        public const int CELL_HEIGHT = 60;

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
        private readonly Texture2D TGroundTile0;

        private const int GroundTile1 = 1;
        private readonly Texture2D TGroundTile1;

        private const int GroundTile2 = 2;
        private readonly Texture2D TGroundTile2;

        private const int GroundTile3 = 3;
        private readonly Texture2D TGroundTile3;

        private const int GroundTile4 = 4;
        private readonly Texture2D TGroundTile4;
        #endregion
        //-------------------------------------------------------------------------------------------------------------
        // WallTexture list:
        #region
        private const int TotalWallTiles = 5;

        private const int WallTile0 = 5;
        private readonly Texture2D TWallTile0;

        private const int WallTile1 = 6;
        private readonly Texture2D TWallTile1;

        private const int WallTile2 = 7;
        private readonly Texture2D TWallTile2;

        private const int WallTile3 = 8;
        private readonly Texture2D TWallTile3;

        private const int WallTile4 = 9;
        private readonly Texture2D TWallTile4;

        #endregion

        //-------------------------------------------------------------------------------------------------------------
        // OtherTexture list:
        #region
        private const int TBOX = 10;
        private const int TKNAPP = 11;
        private const int TDOORCLOSE = 12;
        private const int TDOOROPEN = 13;
        private const int TPLAYER = 14;
        private const int TPORTAL1 = 15;
        private const int TPORTAL2 = 16;
        #endregion


        //                                                             O T H E R        
        //_____________________________________________________________________________________________________________
        private const int MAX_LVL = 1;


        //                                                                              Instance variables

        private int gridWidthX;
        private int gridHeightY;
        private char[,] GRID;
        
        private Int32 seed;

        //                                                                                      Constructor
        public Board(ContentManager c, int gridX, int gridY)
        {
            GRID = new char[gridX, gridY];
            gridWidthX = gridX;
            gridHeightY = gridY;
            createLvl(1);
            // GULP... load all textures.....
            #region
            TGroundTile0 = c.Load<Texture2D>("sprite/portal_floor_tile_1");
            TGroundTile1 = c.Load<Texture2D>("sprite/portal_floor_tile_1");
            TGroundTile2 = c.Load<Texture2D>("sprite/portal_floor_tile_1");
            TGroundTile3 = c.Load<Texture2D>("sprite/portal_floor_tile_1");
            TGroundTile4 = c.Load<Texture2D>("sprite/portal_floor_tile_1");

            TWallTile0 = c.Load<Texture2D>("sprite/portal_wall_tile_0");
            TWallTile1 = c.Load<Texture2D>("sprite/portal_wall_tile_0");
            TWallTile2 = c.Load<Texture2D>("sprite/portal_wall_tile_0");
            TWallTile3 = c.Load<Texture2D>("sprite/portal_wall_tile_0");
            TWallTile4 = c.Load<Texture2D>("sprite/portal_wall_tile_0");
            #endregion
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
        public void Draw(SpriteBatch batch, Vector2 camOffset)
        {
            //batch.Draw(TWallTile0, new Vector2(30, 30), Color.White);
            ///*
            int y = -1;
            for (int i = 0; i < gridWidthX * gridHeightY; i++)
            {
                int x = i % gridWidthX;
                if (x == 0) y += 1;

                Vector2 position = new Vector2(x * CELL_WIDTH, y * CELL_HEIGHT);
                //position += camOffset;

                batch.Draw(TWallTile0, position, Color.White);

                if ((x + y) % 2 == 0)
                {
                    batch.Draw(TWallTile0, position, new Color(0, 0, 0, alpha: 0.15f));
                }
            }
            //*/
        }
        private char[,] createLvl1()
        {
            char[,] _grid;

            _grid = new char[18, 32] {
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

            return _grid;
        }
        

    }
}
