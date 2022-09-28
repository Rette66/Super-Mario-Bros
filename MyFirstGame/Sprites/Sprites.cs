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
     class NormalMarioStandingSprite :Sprite
    {
        public NormalMarioStandingSprite(Game1 game, Vector2 position)
            : base (game.Content.Load<Texture2D>("mario-standing-right"), position,new Vector2(0,0), true,false,0,Point.Zero, new Point(18,24) )
        {

        }
    }

    class NormalMarioWalkingLeftSprite : Sprite
    {
        public NormalMarioWalkingLeftSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("mario-left"), vector2, new Vector2(0, 0), true, true, 0, Point.Zero, new Point(30, 17))
        {

        }
    }
    class NormalMarioWalkingRightSprite : Sprite
    {
        public NormalMarioWalkingRightSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("mario-right"), vector2, new Vector2(0, 0), true, true, 0, Point.Zero, new Point(30, 17))
        {

        }
    }
    class NormalMarioJumpingSprite : Sprite
    {
        public NormalMarioJumpingSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("mario-jumping-right"), vector2, new Vector2(0, 0), true, true, 0, Point.Zero, new Point(30, 17))
        {

        }
    }
    class NormalMarioCrouchingSprite : Sprite
    {
        public NormalMarioCrouchingSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("mario-crouching"), vector2, new Vector2(0, 0), true, false, 0, Point.Zero, new Point(15, 18))
        {

        }
    }


    class GoombaSprite : Sprite
    {
        public GoombaSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("goomba"), position, new Vector2(0, 0), true, true, 100, Point.Zero, new Point(16, 21))
            {

            }
    }

    class KoopaTroopaSprite : Sprite
    {
        public KoopaTroopaSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("koopaTroopa"), position, new Vector2(0, 0), true, true, 100, Point.Zero, new Point(29, 25))
        {

        }
    }


    class FireMarioStandingSprite : Sprite
    {
        public FireMarioStandingSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("fire-standing-mario"), vector2, new Vector2(0, 0), true, false, 0, Point.Zero, new Point(22,48))
        {

        }
    }


    class FireMarioWalkingLeftSprite : Sprite
    {
        //151,37
        public FireMarioWalkingLeftSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("FireMarioWalkingLeft"), vector2, new Vector2(0, 0), true, true, 0, Point.Zero, new Point(25, 33))
        {

        }
    }
    class FireMarioWalkingRightSprite : Sprite
    {
        //152,33
        public FireMarioWalkingRightSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("FireMarioWalkingRight"), vector2, new Vector2(0, 0), true, true, 0, Point.Zero, new Point(25, 33))
        {

        }
    }
    class FireMarioJumpingSprite : Sprite
    {
        public FireMarioJumpingSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("FireMarioJumping"), vector2, new Vector2(0, 0), true, true, 0, Point.Zero, new Point(25, 30))
        {

        }
    }
    class FireMarioCrouchingSprite : Sprite
    {
        public FireMarioCrouchingSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("FireMarioCrouching"), vector2, new Vector2(0, 0), true, false, 0, Point.Zero, new Point(16, 24))
        {

        }
    }



    class SuperMarioStandingSprite : Sprite
    {
        public SuperMarioStandingSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("super-standing-mario"), vector2, new Vector2(0, 0), true, false, 0, Point.Zero, new Point(22, 48))
        {

        }
    }

    class SuperMarioWalkingLeftSprite : Sprite
    {
        //151,37
        public SuperMarioWalkingLeftSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("SuperMarioWalkingLeft"), vector2, new Vector2(0, 0), true, true, 0, Point.Zero, new Point(30, 33))
        {

        }
    }
    class SuperMarioWalkingRightSprite : Sprite
    {
        //152,33
        public SuperMarioWalkingRightSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("SuperMarioWalkingRight"), vector2, new Vector2(0, 0), true, true, 0, Point.Zero, new Point(30, 33))
        {

        }
    }
    class SuperMarioJumpingSprite : Sprite
    {
        public SuperMarioJumpingSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("SuperMarioJumping"), vector2, new Vector2(0, 0), true, true, 0, Point.Zero, new Point(25, 34))
        {

        }
    }
    class SuperMarioCrouchingSprite : Sprite
    {
        public SuperMarioCrouchingSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("SuperMarioCrouching"), vector2, new Vector2(0, 0), true, false, 0, Point.Zero, new Point(16, 24))
        {

        }
    }


    class QuestionBlockSprite : Sprite
    {
        public QuestionBlockSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("questionBlock"), vector2, new Vector2(0, 0), true, true, 300, new Point(3,1), new Point(33, 30))
        { 
        }
 
    }
    class BrickBlockSprite : Sprite
    {
        public BrickBlockSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("brickblock"), vector2, new Vector2(0, 0), true, false, 0, Point.Zero, new Point(30, 30))
        {

        }

    }
    class UsedBlockSprite : Sprite
    {
        public UsedBlockSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("usedBlock"), vector2, new Vector2(0, 0), true, false, 0, new Point(1,1), new Point(30, 30))
        {
        }

    }
    class FloorBlockSprite : Sprite
    {
        public FloorBlockSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("floorBlock"), vector2, new Vector2(0, 0), true, false, 0, Point.Zero, new Point(30, 30))
        {
        }

    }
    class StairBlockSprite : Sprite
    {
        public StairBlockSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("stairBlock"), vector2, new Vector2(0, 0), true, false, 0, Point.Zero, new Point(31, 30))
        {
        }

    }
    class BrickBlockPieceSprite : Sprite
    {
        public BrickBlockPieceSprite(Game1 game1, Vector2 vector2)
            : base(game1.Content.Load<Texture2D>("smallBrickBlock"), vector2, new Vector2(0, 0), false, false, 0, Point.Zero, new Point(15, 15))
        {
        }

    }

    class CoinSprite : Sprite
    {
        public CoinSprite(Game1 game, Vector2 position)
            : base(game.Content.Load<Texture2D>("Coin"), position, new Vector2(0, 0), true, true, 50, new Point(6, 1), new(33, 28))
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
            : base(game.Content.Load<Texture2D>("FireFlowerA"), position, new Vector2(0, 0), true, true, 100, new Point(2, 1), new(58 / 2, 30))
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
