using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.interfaces;
using Sprint0.Mario;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Sprint0.State
{
    public class NormalMario : IState
    {
        private int currentFrame;
        private int totalFrames;
        private int rows;
        private int columns;
        private string direction;
        private bool next;
        private int MillisecondsPerFrame { get; set; }
        private int TimeSinceLastFrame { get; set; }

        private ISprite currentSprite;
        private MarioContext mario;

        public NormalMario(MarioContext mario)
        {
            next = false;
            currentFrame = 0;
            rows = 1;
            columns = 6;
            totalFrames = rows * columns;
            TimeSinceLastFrame = 0;
            MillisecondsPerFrame = 250;
            direction = "left";
            this.currentSprite = NormalMarioFactory.Instance.IdleMario(mario.game, mario.position);
            this.mario = mario;

        }
        public void Update(GameTime gameTime, bool isLeft, bool isRight, bool isJump, bool isCrouch)
        {
            if (isLeft)
            {
                direction = "left";
                this.currentSprite = NormalMarioFactory.Instance.RunningMario(mario.game, mario.position, direction);
            }
            else if (isRight)
            {
                direction = "right";
                this.currentSprite = NormalMarioFactory.Instance.RunningMario(mario.game, mario.position, direction);
            }
            else if (isJump)
            {
                this.currentSprite = NormalMarioFactory.Instance.JumpingMario(mario.game, mario.position);
            }
            else if (isCrouch)
            {
                this.currentSprite = NormalMarioFactory.Instance.CrouchingMario(mario.game, mario.position);
            }
            else
            {
                this.currentSprite = NormalMarioFactory.Instance.IdleMario(mario.game, mario.position);
            }

            NextFrame(gameTime, ref next);
            if (next)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
            }
            currentSprite.Update(gameTime);
        }
        private void NextFrame(GameTime gameTime, ref bool next)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;
                next = true;
            }
            else
            {
                next = false;
            }

        }
        public void DrawCrouch(SpriteBatch batch)
        {
            currentSprite.Draw(batch);
        }
        public void Draw(SpriteBatch batch)
        {
            this.currentSprite = NormalMarioFactory.Instance.IdleMario(mario.game, mario.position);
            currentSprite.Draw(batch);
        }
        public void DrawAnimation(SpriteBatch batch)
        {
            currentSprite.DrawAnimation(batch, 6, currentFrame);
        }
    }


    public class FireMario : IState
    {
        private int currentFrame;
        private int totalFrames;
        private int rows;
        private int columns;
        private string direction;
        private bool next;
        private int MillisecondsPerFrame { get; set; }
        private int TimeSinceLastFrame { get; set; }

        private ISprite currentSprite;
        private MarioContext marioContext;

        public FireMario(MarioContext mario)
        {
            next = false;
            currentFrame = 0;
            rows = 1;
            columns = 6;
            totalFrames = rows * columns;
            TimeSinceLastFrame = 0;
            MillisecondsPerFrame = 250;
            direction = "left";

            this.currentSprite = FireMarioFactory.Instance.IdleMario(mario.game, mario.position);
            this.marioContext = mario;
        }

        public void Update(GameTime gameTime, bool isLeft, bool isRight, bool isJump, bool isCrouch)
        {
            if (isLeft)
            {
                direction = "left";
                this.currentSprite = FireMarioFactory.Instance.RunningMario(marioContext.game, marioContext.position, direction);
            }
            else if (isRight)
            {
                direction = "right";
                this.currentSprite = FireMarioFactory.Instance.RunningMario(marioContext.game, marioContext.position, direction);
            }
            else if (isJump)
            {
                this.currentSprite = FireMarioFactory.Instance.JumpingMario(marioContext.game, marioContext.position);
            }
            else if (isCrouch)
            {
                this.currentSprite = FireMarioFactory.Instance.CrouchingMario(marioContext.game, marioContext.position);
            }
            else
            {
                this.currentSprite = FireMarioFactory.Instance.IdleMario(marioContext.game, marioContext.position);
            }

            NextFrame(gameTime, ref next);
            if (next)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
            }
            currentSprite.Update(gameTime);
        }
        private void NextFrame(GameTime gameTime, ref bool next)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;
                next = true;
            }
            else
            {
                next = false;
            }

        }

        public void Draw(SpriteBatch batch)
        {
            this.currentSprite = FireMarioFactory.Instance.IdleMario(marioContext.game, marioContext.position);
            currentSprite.Draw(batch);
        }

        public void DrawCrouch(SpriteBatch batch)
        {
            currentSprite.Draw(batch);
        }

        public void DrawAnimation(SpriteBatch batch)
        {
            currentSprite.DrawAnimation(batch, 6, currentFrame);
        }
    }

    public class SuperMario : IState
    {
        private int currentFrame;
        private int totalFrames;
        private int rows;
        private int columns;
        private string direction;
        private bool next;
        private int MillisecondsPerFrame { get; set; }
        private int TimeSinceLastFrame { get; set; }

        private ISprite currentSprite;
        private MarioContext marioContext;

        public SuperMario(MarioContext mario)
        {
            next = false;
            currentFrame = 0;
            rows = 1;
            columns = 6;
            totalFrames = rows * columns;
            TimeSinceLastFrame = 0;
            MillisecondsPerFrame = 250;
            direction = "left";

            this.currentSprite = SuperMarioFactory.Instance.IdleMario(mario.game, mario.position);
            this.marioContext = mario;
        }

        public void Update(GameTime gameTime, bool isLeft, bool isRight, bool isJump, bool isCrouch)
        {
            if (isLeft)
            {
                direction = "left";
                this.currentSprite = SuperMarioFactory.Instance.RunningMario(marioContext.game, marioContext.position, direction);
            }
            else if (isRight)
            {
                direction = "right";
                this.currentSprite = SuperMarioFactory.Instance.RunningMario(marioContext.game, marioContext.position, direction);
            }
            else if (isJump)
            {
                this.currentSprite = SuperMarioFactory.Instance.JumpingMario(marioContext.game, marioContext.position);
            }
            else if (isCrouch)
            {
                this.currentSprite = SuperMarioFactory.Instance.CrouchingMario(marioContext.game, marioContext.position);
            }
            else
            {
                this.currentSprite = SuperMarioFactory.Instance.IdleMario(marioContext.game, marioContext.position);
            }

            NextFrame(gameTime, ref next);
            if (next)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
            }
            currentSprite.Update(gameTime);
        }
        private void NextFrame(GameTime gameTime, ref bool next)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;
                next = true;
            }
            else
            {
                next = false;
            }

        }
        public void Draw(SpriteBatch batch)
        {
            this.currentSprite = SuperMarioFactory.Instance.IdleMario(marioContext.game, marioContext.position);
            currentSprite.Draw(batch);
        }
        public void DrawAnimation(SpriteBatch batch)
        {
            currentSprite.DrawAnimation(batch, 6, currentFrame);
        }

        public void DrawCrouch(SpriteBatch batch)
        {
            currentSprite.Draw(batch);
        }
    }


    public class DeadMario : IState
    {
        private ISprite currentSprite;
        private MarioContext marioContext;

        public DeadMario(MarioContext mario)
        {
            this.currentSprite = DeadMarioFactory.Instance.DeadMario(mario.game, mario.position);
            this.marioContext = mario;
        }

        public void Update(GameTime gameTime, bool isLeft, bool isRight, bool isJump, bool isCrouch)
        {

            currentSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch batch)
        {
            currentSprite.Draw(batch);
        }
        public void DrawAnimation(SpriteBatch batch)
        {
            throw new NotImplementedException();
        }
        public void DrawCrouch(SpriteBatch batch)
        {
            throw new NotImplementedException();
        }
    }


}
