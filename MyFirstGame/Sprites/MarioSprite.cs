using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.interfaces;


namespace Sprint0.Sprites
{
    public class MarioSprite : ISprite
    {
        private bool Next;

        private int MillisecondsPerFrame { get; set; }
        private int TimeSinceLastFrame { get; set; }
        public Texture2D mario { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        public Boolean isVisible = false;
        public Vector2 position;
        
        public bool pressed = false;
        public KeyboardState movementDir;
        public string direction;

        public int speed;
        public bool isJump = false;
        private Texture2D marioRight;
        private int marioRightRow;
        private int marioRightColumn;
        private Texture2D marioStandingLeft;
        private Texture2D marioStandingRight;

        private Texture2D marioJumpingRight;
        private int marioJumpingRightRows;
        private int marioJumpingRightColumns;
        private Texture2D marioJumpingLeft;
        private int marioJumpingLeftRows;
        private int marioJumpingLeftColumns;

        private Texture2D marioCrouching;
        private bool isCrouch;

        public MarioSprite(Texture2D texture, int rows, int columns, Vector2 vector2, Texture2D marioRightMain, int rows2, int columns2, 
            Texture2D marioStandingLeftMain, Texture2D marioStandingRightMain, Texture2D marioJumpingLeftMain, int rows3, int columns3,
            Texture2D marioJumpingRightMain, int rows4, int columns4, Texture2D marioCrouchingMain)
        {
            mario = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            position = vector2;
            Next = false;
            speed = 15;
            TimeSinceLastFrame = 0;
            MillisecondsPerFrame = 250;
            direction = "";

            marioRight = marioRightMain;
            marioRightRow = rows2;
            marioRightColumn = columns2;
            marioStandingLeft = marioStandingLeftMain;
            marioStandingRight = marioStandingRightMain;

            marioJumpingLeft = marioJumpingLeftMain;
            marioJumpingLeftRows = rows3;
            marioJumpingLeftColumns = columns3;

            marioJumpingRight = marioJumpingRightMain;
            marioJumpingRightRows = rows4;
            marioJumpingRightColumns = columns4;

            marioCrouching = marioCrouchingMain;
            isCrouch = false;
        }

        public void Update()
        {

            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
            if (isJump)
            {
                Debug.WriteLine(this.Height());
                position.Y -= speed;
                Debug.WriteLine(position.Y);
                if (position.Y <= 60 || position.Y > (116 - this.Height()))
                {
                    speed = -speed;
                    Debug.WriteLine(position.Y);
                    if (position.Y == 100)
                    {
                        isJump = false;
                    }
                }
            }
        }

        public void UpdateFrame(GameTime gametime)
        {
            NextFrame(gametime, ref Next);
            if (Next)
            {
                Update();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int i = 0;
            int width = mario.Width / Columns;
            int height = mario.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            Rectangle sourceRectangle;
            Rectangle destinationRectangle;


            Debug.WriteLine(direction);
            if (pressed)
            {
                if (direction.Equals("left"))
                {
                    MoveLeft();
                    sourceRectangle = new Rectangle(width * column, height * row, width, height);
                    destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
                    spriteBatch.Draw(mario, destinationRectangle, sourceRectangle, Color.White);

                }
                else if (direction.Equals("right"))
                {
                    MoveRight();
                    width = mario.Width / marioRightColumn;
                    height = mario.Height / marioRightRow;
                    row = currentFrame / marioRightColumn;
                    column = currentFrame % marioRightColumn;

                    sourceRectangle = new Rectangle(width * column, height * row, width, height);
                    destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
                    spriteBatch.Draw(marioRight, destinationRectangle, sourceRectangle, Color.White);
                }
            }
            else if (isJump)
            {
                if (direction.Equals("left"))
                {

                    width = mario.Width / marioJumpingLeftColumns;
                    height = mario.Height / marioJumpingLeftRows;
                    row = currentFrame / marioJumpingLeftColumns;
                    column = currentFrame % marioJumpingLeftColumns;

                    sourceRectangle = new Rectangle(width * column, height * row, width, height);
                    destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
                    Debug.WriteLine("Left Jump");
                    spriteBatch.Draw(marioJumpingLeft, destinationRectangle, sourceRectangle, Color.White);
                }
                else if (direction.Equals("right"))
                {
                    width = mario.Width / marioJumpingRightColumns;
                    height = mario.Height / marioJumpingRightRows;
                    row = currentFrame / marioJumpingRightColumns;
                    column = currentFrame % marioJumpingRightColumns;

                    sourceRectangle = new Rectangle(width * column, height * row, width, height);
                    destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
                    spriteBatch.Draw(marioJumpingRight, destinationRectangle, sourceRectangle, Color.White);
                }
                else
                {
                    sourceRectangle = new Rectangle(width * column, height * row, width, height);
                    destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
                    Debug.WriteLine("else Jump");
                    spriteBatch.Draw(mario, destinationRectangle, sourceRectangle, Color.White);
                }
                
            }

            else if (isCrouch)
            {
                spriteBatch.Draw(marioCrouching, position, Color.White);
            }
            else if(direction.Equals("left"))
            {
                spriteBatch.Draw(marioStandingLeft,position, Color.White);
            }
            else if (direction.Equals("right"))
            {
                spriteBatch.Draw(marioStandingRight, position, Color.White);
            }
            else
            {
                spriteBatch.Draw(marioStandingLeft, position, Color.White);
            }
        }

        public int Width()
        {
            return mario.Width;
        }

        public int Height()
        {
            return mario.Height;
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

        public void MoveRight()
        {
            if(position.X < 400)
            {
                position.X += 1;
            }
        }

        public void MoveLeft()
        {
            if (position.X > 50)
            {
                position.X -= 1;
            }
        }

        public void Jump()
        {
            if(position.Y == 100)
            {
                isJump = true;
            }
        }

        public void Crouch()
        {
            isCrouch = !isCrouch;
        }

    }
}
