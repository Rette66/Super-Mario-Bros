using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controller;
using Sprint0.interfaces;
using Sprint0.Sprites;
using Sprint0.State;
using Sprint0.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Sprint0.Block;
using System.Diagnostics;

namespace Sprint0.Mario
{
    public class MarioContext
    {

        private IState currentPowerState;
        private IState currentMovementState;
        private ISprite currentSprite;

        private MarioFactory marioFactory;

        public bool isSuperMario;

        public int lifecount;


        public Game1 game;
        public Vector2 position;


        public MarioContext(Game1 game, Vector2 position)
        {
            this.game = game;
            this.position = position;

            currentPowerState = new NormalMario(this);
            currentMovementState = new IdleMario(this);
            lifecount = 1;
            marioFactory = new NormalMarioFactory();
        }


        public void ChangeToRight()
        {
            currentSprite.FaceRight();
        }
        public void ChangeToLeft()
        {
            currentSprite.FaceLeft();
        }

        public void ChangeToJump()
        {
            switch (currentMovementState)
            {
                case CrouchingMario:
                    currentMovementState = new IdleMario(this);
                    break;
                default:
                    currentMovementState = new JumpingMario(this);
                    break;
            }
            Debug.WriteLine(currentMovementState);
        }
        public void ChangeToCrouch()
        {
            switch (currentMovementState)
            {
                case JumpingMario:
                    currentMovementState = new IdleMario(this);
                    break;
                default:
                    currentMovementState = new CrouchingMario(this);
                    break;
            }
        }
        public void ChangeToWalking()
        {
            currentMovementState = new RunningMario(this);
        }



        public void ChangeToNormal()
        {
            isSuperMario = false;
            lifecount = 1;
            currentPowerState = new NormalMario(this);
        }
        public void ChangeToFire()
        {
            isSuperMario = true;
            lifecount = 3;
            currentPowerState = new FireMario(this);
        }
        public void ChangeToSuper()
        {
            isSuperMario = true;
            lifecount = 2;
            currentPowerState = new SuperMario(this);

        }
        public void TakeDamage()
        {
            lifecount--;
            isSuperMario = false;
            switch (lifecount)
            {
                case 0:
                    currentPowerState = new DeadMario(this);
                    break;
                case 1:
                    currentPowerState = new NormalMario(this);
                    break;
                case 2:
                    currentPowerState = new SuperMario(this);
                    break;
            }
        }



        private void SetUpFactory()
        {
            switch (currentPowerState)
            {
                case NormalMario:
                    marioFactory = new NormalMarioFactory();
                    break;

                case SuperMario:
                    marioFactory = new SuperMarioFactory();
                    break;

                case FireMario:
                    marioFactory = new FireMarioFactory();  
                    break;

                case DeadMario:
                    marioFactory = new DeadMarioFactory();
                    break;
            }
        }

        private void CreateMarioSprite()
        {
            switch (currentMovementState)
            {
                case IdleMario:
                    currentSprite = marioFactory.IdleMario(game, position);
                    break;
                case JumpingMario:
                    currentSprite = marioFactory.JumpingMario(game, position);
                    break;
                case CrouchingMario:
                    currentSprite = marioFactory.CrouchingMario(game, position);
                    break;
                case RunningMario:
                    currentSprite = marioFactory.RunningMario(game, position);
                    break;
            }
        }


        public void Update(GameTime gameTime)
        {
            SetUpFactory();
            CreateMarioSprite();
            currentPowerState.Update(gameTime,currentSprite);
            currentMovementState.Update(gameTime,currentSprite);
        }

        public void Draw(SpriteBatch batch)
        {
            currentSprite.Draw(batch);
        }
    }
}
