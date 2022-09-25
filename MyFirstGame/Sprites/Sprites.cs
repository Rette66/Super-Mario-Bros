using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sprint0.Sprites
{
     class MarioSprite :Sprite
    {
        public MarioSprite(Game1 game, Vector2 position)
            : base (game.Content.Load<Texture2D>("small-standing-mario"), position,new Vector2(0,0), true,  false,0,new Point(1,1 ), new Point(18,24))
        {

        }
    }

    class CoinSprite : Sprite
    {
        public CoinSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("Coin"), position, new Vector2(0, 0), true, true,50, new Point(6,1), new(200,600))
        {

        }
    }

}
