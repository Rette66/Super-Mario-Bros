using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.interfaces;
using Sprint0.Sprites;

namespace Sprint0.Enemy
{

    public class KoopaTroopa
    {

        public Game1 game;
        public Vector2 position;
        private ISprite koopaTroopa;

        private bool Next;
        private int MillisecondsPerFrame { get; set; }
        private int TimeSinceLastFrame { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;

        public Boolean isVisible = false;


        public KoopaTroopa(Game1 game, int rows, int columns, Vector2 vector2)
        {
            this.game = game;
            this.position = vector2;
            koopaTroopa = KoopaTroopaFactory.Instance.CreateEnemy(game, position);
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
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
            koopaTroopa.DrawAnimation(spriteBatch, 2, currentFrame);
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

