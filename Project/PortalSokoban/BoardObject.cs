using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSokoban
{
    public class BoardObject
    {
        Vector2 drawPos;
        int xPos;
        int YPos;
        Texture2D sprite;

        BoardObject(int xPos, int yPos)
        {
            this.YPos = yPos;
            this.xPos = xPos;
            drawPos = new Vector2(xPos * Board.CELL_WIDTH, yPos * Board.CELL_HEIGHT);
        }
    }
}
