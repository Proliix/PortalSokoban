using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSokoban
{
    public class Box : BoardObject
    {
        public Box(int xPos, int yPos, Board board, ContentManager c) : base(xPos, yPos, board, c)
        {
            sprite = c.Load<Texture2D>("sprite/portal_cube_1");
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
                        if (box.AttemptMove(xMove, yMove))
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
    }
}
