﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalSokoban
{
    public abstract class BoardObject
    {
        protected Vector2 drawPos;
        protected int xPos;
        protected int yPos;
        protected Texture2D sprite;
        protected Board board;

        public BoardObject(int xPos, int yPos, Board board)
        {
            this.yPos = yPos;
            this.xPos = xPos;
            this.board = board;
            drawPos = new Vector2(xPos * Board.CELL_WIDTH, yPos * Board.CELL_HEIGHT);
        }

        protected void DoMove(int xMove, int yMove)
        {
            xPos += xMove;
            yPos += yMove;
        }
        public abstract bool AttemptMove(int xMove, int yMove);
        public abstract void Draw(SpriteBatch batch, Vector2 camOffset);
    }
}
