using Microsoft.Xna.Framework;
using Sprint0.interfaces;
using Sprint0.Mario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.State
{

    public abstract class MarioMovementState : IState
    {
        public abstract void Update(GameTime gameTime, ISprite currentSprite);
    }

    public class IdleMario : MarioMovementState
    {
        private MarioContext mario;
        public IdleMario(MarioContext mario)
        {
            this.mario = mario;
        }
        public override void Update(GameTime gameTime, ISprite currentSprite)
        {
            currentSprite.Update(gameTime);
        }
    }

    public class RunningMario : MarioMovementState
    {
        private MarioContext mario;
        public RunningMario(MarioContext mario)
        {
            this.mario = mario;
        }
        public override void Update(GameTime gameTime, ISprite currentSprite)
        {
            currentSprite.Update(gameTime);
        }
    }

    public class JumpingMario : MarioMovementState
    {
        private MarioContext mario;
        public JumpingMario(MarioContext mario)
        {
            this.mario = mario;
        }
        public override void Update(GameTime gameTime, ISprite currentSprite)
        {
            currentSprite.Update(gameTime);
        }
    }

    public class CrouchingMario : MarioMovementState
    {
        private MarioContext mario;
        public CrouchingMario(MarioContext mario)
        {
            this.mario = mario;
        }
        public override void Update(GameTime gameTime, ISprite currentSprite)
        {
            currentSprite.Update(gameTime);
        }
    }
}
