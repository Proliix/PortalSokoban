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

public class Player : BoardObject, IReciveInput
{
    private const int up = 0;
    private const int right = 1;
    private const int down = 2;
    private const int left = 3;

    private bool isAlive;
    private int direction;
    private readonly Texture2D[] playerSprites;

    public Player(int x, int y, Board board, ContentManager c) : base(x, y, board,c)
    {
        playerSprites = new Texture2D[4];
        isAlive = true;
        direction = 2;
        InputSystem.INSTANCE.Add(this);
        #region
        // Load all textures
        playerSprites[0] = c.Load<Texture2D>("sprite/portal_player_idle_up");
        playerSprites[1] = c.Load<Texture2D>("sprite/portal_player_idle_right");
        playerSprites[2] = c.Load<Texture2D>("sprite/portal_player_idle_down");
        playerSprites[3] = c.Load<Texture2D>("sprite/portal_player_idle_left");
        sprite = playerSprites[direction];
        #endregion
    }

    public override bool AttemptMove(int xMove, int yMove)
    {
        int newXPos = xPos + xMove;
        int newYPos = yPos + yMove;
        char objAtPos = board.GetObjOnPoint(newXPos, newYPos);

        switch (objAtPos)
        {
            case Board.BOX:
                BoardObject box = board.GetBoardObjAtPos(newXPos, newYPos);
                if (box != null)
                {
                    if (box.AttemptMove(xMove,yMove))
                    {
                        DoMove(xMove, yMove);
                        return true;
                    }
                }
                return false;
            case Board.GROUND:
            case Board.KNAPP:
                DoMove(xMove, yMove);
                return true;

            default:
                return false;
        }

    }

    public override void Draw(SpriteBatch batch, Vector2 camOffset)
    {
        Vector2 position = new Vector2(xPos * Board.CELL_WIDTH, yPos * Board.CELL_HEIGHT);
        batch.Draw(sprite, position, Color.White);
    }

    public void ReciveInput(int inputNum)
    {
        Console.WriteLine(inputNum);
        switch (inputNum)
        {
            case InputSystem.UP:
                AttemptMove(0, -1);
                sprite = playerSprites[up];
                break;
            case InputSystem.DOWN:
                AttemptMove(0, 1);
                sprite = playerSprites[down];
                break;
            case InputSystem.LEFT:
                AttemptMove(-1, 0);
                sprite = playerSprites[left];
                break;
            case InputSystem.RIGHT:
                AttemptMove(1, 0);
                sprite = playerSprites[right];
                break;
            default:
                break;
        }
    }
}
