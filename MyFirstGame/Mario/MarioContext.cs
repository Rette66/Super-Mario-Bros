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

        private IState currentState;

        public bool isSuperMario;

        public int lifecount;

        public Game1 game;
        public Vector2 position;

        public ISprite walkingMario;
        public bool isLeft;
        public bool isRight;
        public bool isJump;
        public bool isCrouch;
        public bool pressed;


        public MarioContext(Game1 game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            isLeft = false;
            isRight = false;
            isJump = false;
            isCrouch = false;
            pressed = false;

            currentState = new NormalMario(this);
            lifecount = 1;
        }


        public void setState(IState state)
        {
            currentState = state;
        }


        public void walkingLeft()
        {
            Debug.WriteLine(isLeft.ToString());
            isLeft = true;
            isRight = false;
            isCrouch = false;
            isJump = false;

        }
        public void walkingRight()
        {
            isRight = true;
            isLeft = false;
            isCrouch = false;
            isJump = false;
        }
        public void jumping()
        {
            isJump = true;
            isLeft = false;
            isRight = false;
            isCrouch = false;
        }
        public void crouching()
        {
            isCrouch = true;
            isJump = false;
            isLeft = false;
            isRight = false;
        }


        public void ChangeToNormal()
        {
            lifecount = 1;
            isSuperMario = false;
            currentState = new NormalMario(this);
        }
        public void ChangeToSuper()
        {
            isSuperMario = true;
            lifecount = 2;
            currentState = new SuperMario(this);
        }
        public void ChangeToFire()
        {
            isSuperMario = false;
            lifecount = 3;
            currentState = new FireMario(this);
        }
        public void TakeDamage()
        {
            isSuperMario = false;
            lifecount--;
            switch (lifecount)
            {
                case 0:
                    currentState = new DeadMario(this);
                    break;
                case 1:
                    currentState = new NormalMario(this);
                    break;
                case 2:
                    currentState = new SuperMario(this);
                    break;
            }
        }



        public void PowerChanges(GameTime gameTime)
        {
            currentState.Update(gameTime, isLeft, isRight, isJump, isCrouch);
        }


        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime, isLeft, isRight, isJump, isCrouch);
        }

        public void Draw(SpriteBatch batch, Texture2D standingMario)
        {
            if (!pressed)
            {
                //currentState = new FireMario(this);
                currentState.Draw(batch);
            }
            else if(pressed && isCrouch)
            {
                currentState.DrawCrouch(batch);
            }
            else
            {
                currentState.DrawAnimation(batch);
            }
        }
    }
}
