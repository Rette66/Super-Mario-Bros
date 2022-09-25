using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Sprites
{
    //Abstract sprite factory class
    // to use, create a new facotry class inherient this class an add implement in create method
    abstract class SpriteFactory 
    {
        protected Random random;

        protected SpriteFactory()
        {
            random = new Random(DateTime.Now.Millisecond);
        }
        public abstract Sprite Create(Game1 game, Vector2 postion);
    }


    // player one factory or mario factory
    // generate a new mario sprite
    class PlayerOneAvatarFactory : SpriteFactory
    {
        private static SpriteFactory instance;

        public static SpriteFactory Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new PlayerOneAvatarFactory();
                }
                return instance;
            }
        }

        public override Sprite Create(Game1 game, Vector2 pos)
        {
            return new MarioSprite(game,pos );
        }
    }


    /*Coin sprite*/
    class CoinFactory : SpriteFactory
    {
        private static SpriteFactory instance;

        public static SpriteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CoinFactory();
                }
                return instance;
            }
        }

        public override Sprite Create(Game1 game, Vector2 pos)
        {
            return new CoinSprite(game, pos);
        }
    }

    /*Star sprite*/
    class StarFactory : SpriteFactory
    {
        private static SpriteFactory instance;

        public static SpriteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StarFactory();
                }
                return instance;
            }
        }

        public override Sprite Create(Game1 game, Vector2 pos)
        {
            return new StarSprite(game, pos);
        }
    }


    /*FireFlower sprite*/
    class FireFlowerFactory : SpriteFactory
    {
        private static SpriteFactory instance;

        public static SpriteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FireFlowerFactory();
                }
                return instance;
            }
        }

        public override Sprite Create(Game1 game, Vector2 pos)
        {
            return new FireFlowerSprite(game, pos);
        }
    }

    /*Coin sprite*/
    class SuperMushroomFactory : SpriteFactory
    {
        private static SpriteFactory instance;

        public static SpriteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SuperMushroomFactory();
                }
                return instance;
            }
        }

        public override Sprite Create(Game1 game, Vector2 pos)
        {
            return new SuperMushroomSprite(game, pos);
        }
    }

    /*Coin sprite*/
    class OneUpMushroomFactory : SpriteFactory
    {
        private static SpriteFactory instance;

        public static SpriteFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OneUpMushroomFactory();
                }
                return instance;
            }
        }

        public override Sprite Create(Game1 game, Vector2 pos)
        {
            return new OneUpMushroomSprite(game, pos);
        }
    }
}
