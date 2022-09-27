using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.interfaces;


namespace Sprint0.Sprites
{

    public class KoopaTroopaSprite : ISprite
    {
        private bool Next;

        private int MillisecondsPerFrame { get; set; }
        private int TimeSinceLastFrame { get; set; }
        public Texture2D kt { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        public Boolean isVisible = false;
        public Vector2 position;


        public KoopaTroopaSprite(Texture2D texture, int rows, int columns, Vector2 vector2)
        {
            kt = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            position = vector2;
            Next = false;
            TimeSinceLastFrame = 0;
            MillisecondsPerFrame = 200;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
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
            int width = kt.Width / Columns;
            int height = kt.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            spriteBatch.Draw(kt, destinationRectangle, sourceRectangle, Color.White);
            
        }

        public int Width()
        {
            return kt.Width;
        }

        public int Height()
        {
            return kt.Height;
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
    }
}
