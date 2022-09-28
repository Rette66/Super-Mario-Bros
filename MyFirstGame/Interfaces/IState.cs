using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using Sprint0.Sprites;

namespace Sprint0.interfaces
{
    public interface IState
    {
        void Update(GameTime gameTime, bool isLeft, bool isRight, bool isjump, bool isCrouch);

        void Draw(SpriteBatch batch);
        void DrawCrouch(SpriteBatch batch);
        void DrawAnimation(SpriteBatch batch);


    }
}
