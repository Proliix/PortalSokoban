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
using PortalSokoban;
using Microsoft.VisualBasic.ApplicationServices;
using System.Reflection.Metadata;

public class Player : BoardObject
{
    private const int up = 0;
    private const int right = 1;
    private const int down = 2;
    private const int left = 3;

    private bool isAlive;
    private int direction;
    private readonly Texture2D[] playerSprites;

    public Player(int x, int y, Board board, ContentManager c) : base(x, y, board)
    {
        playerSprites = new Texture2D[4];
        isAlive = true;
        direction = 2;

        #region
        // Load all textures
        //playerSprites[0] = c.Load<Texture2D>("sprite/portal_player_idle_up"); 
        playerSprites[1] = c.Load<Texture2D>("sprite/portal_player_idle_right");
        playerSprites[2] = c.Load<Texture2D>("sprite/portal_player_idle_down");
        playerSprites[3] = c.Load<Texture2D>("sprite/portal_player_idle_left");
        sprite = playerSprites[direction];
        #endregion
    }

    public override bool AttemptMove(int xMove, int yMove)
    {
        throw new NotImplementedException();
    }

    public override void Draw(SpriteBatch batch, Vector2 camOffset)
    {
        Vector2 position = new Vector2(xPos * Board.CELL_WIDTH, yPos * Board.CELL_HEIGHT);
        batch.Draw(sprite, position, Color.White);
    }
}
