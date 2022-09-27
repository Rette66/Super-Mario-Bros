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
        public int speed = 10;
        public bool isJump = false;
        Texture2D marioRight;

        public MarioSprite(Texture2D texture, int rows, int columns, Vector2 vector2, Texture2D marioRightMain)
        {
            mario = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            position = vector2;
            Next = false;
            TimeSinceLastFrame = 0;
            MillisecondsPerFrame = 150;

            marioRight = marioRightMain;
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
            string direction = "";
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);

            spriteBatch.Draw(mario, destinationRectangle, sourceRectangle, Color.White);

            if (pressed)
            {
                if (movementDir.IsKeyDown(Keys.D))
                {
                    MoveRight();
                    direction = "right";
                }
                else if (movementDir.IsKeyDown(Keys.A))
                {
                    MoveLeft();
                    direction = "left";
                }
                sourceRectangle = new Rectangle(width * column, height * row, width, height);
                destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
                if(direction.Equals("right"))
                {
                    spriteBatch.Draw(marioRight, destinationRectangle, sourceRectangle, Color.White);
                }
                else
                {
                    spriteBatch.Draw(mario, destinationRectangle, sourceRectangle, Color.White);
                }
            }
            if (isJump)
            {
                spriteBatch.Draw(mario, destinationRectangle, sourceRectangle, Color.White);
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



    }
}
