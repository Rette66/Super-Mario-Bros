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
            : base(game.Content.Load<Texture2D>("Coin"), position, new Vector2(0, 0), true, true,50, new Point(6,1), new(33,28))
        {

        }
    }


    /*need to change */
    class StarSprite : Sprite
    {
        public StarSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("StarA"), position, new Vector2(0, 0), true, true, 100, new Point(4, 1), new(21, 16))
        {

        }
    }

    /*need to change */
    class FireFlowerSprite : Sprite
    {
        public FireFlowerSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("FireFlowerA"), position, new Vector2(0, 0), true, true, 100, new Point(2, 1), new(58/2, 30))
        {

        }
    }

    
    class SuperMushroomSprite : Sprite
    {
        public SuperMushroomSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("SuperMushroom"), position, new Vector2(0, 0), true, false, 100, new Point(1, 1), new(30, 30))
        {

        }
    }

   
    class OneUpMushroomSprite : Sprite
    {
        public OneUpMushroomSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("1UpMushroom"), position, new Vector2(0, 0), true, false, 100, new Point(1, 1), new(30, 30))
        {

        }
    }
}
