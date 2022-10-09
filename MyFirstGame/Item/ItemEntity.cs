﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Sprites;
using Sprint0.Sprites.factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Sprint0.Item
{
    public class ItemEntity : Entity
    {

        public virtual ItemFactory ItemFactory => game.ItemFactory;
        public enum eItemType
        {
            Coin = 0,
            SuperMushroom = 1,
            FireFlower = 2,
            OneUpMushroom = 3,
            Star = 4,
        }
        public eItemType ItemType { get; set; }

        public ItemEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
        }

        public override void Update(GameTime gameTime, List<Entity> entities)
        {
            base.Update(gameTime,entities);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
