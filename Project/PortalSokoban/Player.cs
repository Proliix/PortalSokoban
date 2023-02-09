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

public class Player
{
	private const int up = 0;
	private const int right = 1;
	private const int down = 2;
	private const int left = 3;

	private bool isAlive;
	private int direction;
    private readonly Texture2D[] playerSprites;
	private Texture2D currentSprite;

	public Player(ContentManager c)
	{
		playerSprites = new Texture2D[4];
		isAlive = true;
		direction = 2;

        #region
        // Load all textures
        playerSprites[0] = c.Load<Texture2D>("sprite/portal_player_idle_down");
        playerSprites[1] = c.Load<Texture2D>("sprite/portal_player_idle_down");
        playerSprites[2] = c.Load<Texture2D>("sprite/portal_player_idle_down");
        playerSprites[3] = c.Load<Texture2D>("sprite/portal_player_idle_down");

        #endregion
    }
}
