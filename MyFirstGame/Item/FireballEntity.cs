﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Sprites;
using Sprint0.Item.State;

namespace Sprint0.Item
{
    public class FireballEntity : ItemEntity
    {
        public FireballEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            ItemType = eItemType.Fireball;
            Sprite = ItemFactory.CreateItem(game, position, (int)ItemType);
            CurrentState = new FireballMovingState(this);
            CurrentState.Enter(null);
        }

        public override void Update(GameTime gameTime, List<Entity> entities)
        {
            base.Update(gameTime, entities);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }


    }
}
