﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Item.State
{
    public class StarMoveState : ItemStates
    {

        Vector2 Origion;

        public StarMoveState(ItemEntity item)
            : base(item)
        {
        }
        public int ySpeed = -20;
        public int xSpeed = 0;
        public override void Enter(IItemState previousState)
        {
            
            CurrentState = this;
            this.previousState = previousState;

            Origion = Item.Position;

            Item.Speed = new Vector2(xSpeed, ySpeed);
        }

        public override void Update(GameTime gameTime)
        {
            if (Math.Abs(Item.Position.Y - Origion.Y) > 10 )
            {
                ySpeed = -ySpeed;
                Item.Speed = new Vector2(xSpeed, ySpeed);
            }
            if ((Item.Position.X - EntityStorage.Instance.Mario.Position.X)> 0)
            {
                xSpeed = 40;
            }
            else if ((Item.Position.X - EntityStorage.Instance.Mario.Position.X) < 0)
            {
                xSpeed = -40;
            }
            
        }
    }
}
