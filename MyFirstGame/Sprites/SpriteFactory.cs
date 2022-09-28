using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Sprites;
using Sprint0.interfaces;
using System.Diagnostics;

namespace Sprint0.Sprites
{
    //Abstract sprite factory class
    // to use, create a new facotry class inherient this class an add implement in create method
    abstract class MarioFactory 
    {
        protected Random random;

        protected MarioFactory()
        {
            random = new Random(DateTime.Now.Millisecond);
        }
        public abstract ISprite IdleMario(Game1 game, Vector2 postion);
        public abstract ISprite RunningMario(Game1 game, Vector2 position, string dir);
        public abstract ISprite JumpingMario(Game1 game, Vector2 position);
        public abstract ISprite CrouchingMario(Game1 game, Vector2 position);

    }

    abstract class BlockFactory
    {
        protected Random random;

        protected BlockFactory()
        {
            random = new Random(DateTime.Now.Millisecond);
        }
        public abstract ISprite CreateBlock(Game1 game, Vector2 postion);
    }

    abstract class EnemyFactory
    {
        protected Random random;

        protected EnemyFactory()
        {
            random = new Random(DateTime.Now.Millisecond);
        }
        public abstract ISprite CreateEnemy(Game1 game, Vector2 postion);
    }


    // player one factory or mario factory
    // generate a new mario sprite
    class NormalMarioFactory : MarioFactory
    {
        private static MarioFactory instance;

        public static MarioFactory Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new NormalMarioFactory();
                }
                return instance;
            }
        }

        public override ISprite IdleMario(Game1 game, Vector2 pos)
        {
            return new NormalMarioStandingSprite(game,pos );
        }

        public override ISprite RunningMario(Game1 game, Vector2 position, string dir)
        {
            if (dir.Equals("right"))
            {
                Debug.WriteLine("right animation");
                return new NormalMarioWalkingRightSprite(game, position);
            }
            else
            {
                return new NormalMarioWalkingLeftSprite(game, position);
            }

        }

        public override ISprite JumpingMario(Game1 game, Vector2 position)
        {
            return new NormalMarioJumpingSprite(game, position);
        }
        public override ISprite CrouchingMario(Game1 game, Vector2 position)
        {
            return new NormalMarioCrouchingSprite(game, position);
        }
    }



    // player one factory or mario factory
    // generate a new mario sprite
    class FireMarioFactory : MarioFactory
    {
        private static MarioFactory instance;

        public static MarioFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FireMarioFactory();
                }
                return instance;
            }
        }

        public override ISprite IdleMario(Game1 game, Vector2 pos)
        {
            return new FireMarioStandingSprite(game, pos);
        }

        public override ISprite RunningMario(Game1 game, Vector2 position, string dir)
        {
            if (dir.Equals("right"))
            {
                Debug.WriteLine("right animation");
                return new FireMarioWalkingRightSprite(game, position);
            }
            else
            {
                return new FireMarioWalkingLeftSprite(game, position);
            }
        }

        public override ISprite JumpingMario(Game1 game, Vector2 position)
        {
            return new FireMarioJumpingSprite(game, position);//need changes
        }
        public override ISprite CrouchingMario(Game1 game, Vector2 position)
        {
            return new FireMarioCrouchingSprite(game, position);//need changes
        }
    }



    // player one factory or mario factory
    // generate a new mario sprite
    class SuperMarioFactory : MarioFactory
    {
        private static MarioFactory instance;

        public static MarioFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SuperMarioFactory();
                }
                return instance;
            }
        }

        public override ISprite IdleMario(Game1 game, Vector2 pos)
        {
            return new SuperMarioStandingSprite(game, pos);
        }

        public override ISprite RunningMario(Game1 game, Vector2 position, string dir)
        {
            if (dir.Equals("right"))
            {
                return new SuperMarioWalkingRightSprite(game, position);
            }
            else
            {
                return new SuperMarioWalkingLeftSprite(game, position);
            }
        }

        public override ISprite JumpingMario(Game1 game, Vector2 position)
        {
            return new SuperMarioJumpingSprite(game, position);//need changes
        }
        public override ISprite CrouchingMario(Game1 game, Vector2 position)
        {
            return new SuperMarioCrouchingSprite(game, position);//need changes
        }
    }

    abstract class DMarioFactory
    {
        protected Random random;

        protected DMarioFactory()
        {
            random = new Random(DateTime.Now.Millisecond);
        }
        public abstract ISprite DeadMario(Game1 game, Vector2 postion);

    }

    class DeadMarioFactory : DMarioFactory
    {
        private static DeadMarioFactory instance;

        public static DeadMarioFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DeadMarioFactory();
                }
                return instance;
            }
        }

        public override ISprite DeadMario(Game1 game, Vector2 pos)
        {
            return new SuperMarioStandingSprite(game, pos);
        }
    }

    class QuestionBlockFactory : BlockFactory
    {
        private static BlockFactory instance;

        public static BlockFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new QuestionBlockFactory();
                }
                return instance;
            }
        }

        public override ISprite CreateBlock(Game1 game, Vector2 pos)
        {
            return new QuestionBlockSprite(game, pos);
        }
    }
    class FloorBlockFactory : BlockFactory
    {
        private static BlockFactory instance;

        public static BlockFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FloorBlockFactory();
                }
                return instance;
            }
        }

        public override ISprite CreateBlock(Game1 game, Vector2 pos)
        {
            return new FloorBlockSprite(game, pos);
        }
    }

    class BrickBlockFactory : BlockFactory
    {
        private static BlockFactory instance;

        public static BlockFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BrickBlockFactory();
                }
                return instance;
            }
        }

        public override ISprite CreateBlock(Game1 game, Vector2 pos)
        {
            return new BrickBlockSprite(game, pos);
        }
    }
    class UsedBlockFactory : BlockFactory
    {
        private static BlockFactory instance;

        public static BlockFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UsedBlockFactory();
                }
                return instance;
            }
        }

        public override ISprite CreateBlock(Game1 game, Vector2 pos)
        {
            return new UsedBlockSprite(game, pos);
        }
    }
    class StairBlockFactory : BlockFactory
    {
        private static BlockFactory instance;

        public static BlockFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StairBlockFactory();
                }
                return instance;
            }
        }

        public override ISprite CreateBlock(Game1 game, Vector2 pos)
        {
            return new StairBlockSprite(game, pos);
        }
    }

    class BrickBlockPieceFactory : BlockFactory
    {
        private static BlockFactory instance;

        public static BlockFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BrickBlockPieceFactory();
                }
                return instance;
            }
        }

        public override ISprite CreateBlock(Game1 game, Vector2 pos)
        {
            return new BrickBlockPieceSprite(game, pos);
        }
    }

    class GoombaFactory : EnemyFactory
    {
        private static GoombaFactory instance;

        public static GoombaFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GoombaFactory();
                }
                return instance;
            }
        }

        public override ISprite CreateEnemy(Game1 game, Vector2 pos)
        {
            return new GoombaSprite(game, pos);
        }
    }

    class KoopaTroopaFactory : EnemyFactory
    {
        private static KoopaTroopaFactory instance;

        public static KoopaTroopaFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KoopaTroopaFactory();
                }
                return instance;
            }
        }

        public override ISprite CreateEnemy(Game1 game, Vector2 pos)
        {
            return new KoopaTroopaSprite(game, pos);
        }
    }

}
