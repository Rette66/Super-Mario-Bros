using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Block
{
    public class StairBlock
    {
        public Game1 game;
        public Vector2 position;

        private ISprite currentBlock;




        public StairBlock(Game1 game, Vector2 position)
        {
            this.game = game;
            this.position = position;

            currentBlock = StairBlockFactory.Instance.CreateBlock(game, position);

        }


        public void Update(GameTime gameTime)
        {

            currentBlock.Update(gameTime);

        }

        public void Draw(SpriteBatch batch)
        {
            currentBlock.Draw(batch);
        }
    }
}
