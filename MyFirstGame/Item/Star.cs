﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Item
{
    public class StarEntity : ItemEntity
    {
        public StarEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            ItemType = eItemType.Star;
            Sprite = ItemFactory.CreateItem(game, position, (int)ItemType);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }


    }
}
