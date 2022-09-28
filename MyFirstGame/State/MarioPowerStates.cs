using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.interfaces;
using Sprint0.Mario;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.State
{
    public class NormalMario : IState
    {
        private MarioContext mario;

        public NormalMario(MarioContext mario)
        {
            this.mario = mario;
        }
        public void Update(GameTime gameTime, ISprite currentSprite)
        {
            currentSprite.Update(gameTime);
        }


    }

    public class FireMario : IState
    {
        private MarioContext marioContext;

        public FireMario(MarioContext mario)
        {
            this.marioContext = mario;
        }

        public void Update(GameTime gameTime, ISprite currentSprite)
        {

            currentSprite.Update(gameTime);
        }

 

    }

    public class SuperMario : IState
    {
        private MarioContext marioContext;

        public SuperMario(MarioContext mario)
        {
            this.marioContext = mario;
        }

        public void Update(GameTime gameTime, ISprite currentSprite)
        {

            currentSprite.Update(gameTime);
        }


    }


    public class DeadMario : IState
    {
        private MarioContext marioContext;

        public DeadMario(MarioContext mario)
        {
            this.marioContext = mario;
        }

        public void Update(GameTime gameTime, ISprite currentSprite)
        {

            currentSprite.Update(gameTime);
        }

    }
}
