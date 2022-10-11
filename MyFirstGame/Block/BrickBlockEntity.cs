﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block.State;
using Sprint0.Mario;
using Sprint0.Mario.MarioPowerState;
using Sprint0.Sprites;
using Sprint0.State;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Block
{
    public class BrickBlockEntity : BlockEntity
    {


        public BrickBlockEntity(Game1 game, Vector2 position, bool isVisible)
            : base(game, position)
        {
            Sprite = BlockFactory.CreateBlock(game,position, (int)eBlockType.BrickBlock);
            BlockType = eBlockType.BrickBlock;
            CurrentState = new BrickBlockNormalState(this);
            CurrentState.Enter(null);
            IsVisible = isVisible;
        }

        public override void Update(GameTime gameTime, List<Entity> entities, MarioEntity mario)
        {
            Mario = mario;
            base.Update(gameTime,entities, mario);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisible)
            {
                base.Draw(spriteBatch);
            }
        }
        public void changeToVisible()
        {
            IsVisible = true;
        }

        public void BumpOrBreakTransition()
        {
            switch (Mario.currentPowerState)
            {
                case SuperState:
                    CurrentState?.BreakTransition();
                    break;
                case FireState:
                    CurrentState?.BreakTransition();
                    break;
                default:
                    BumpTransition();
                    break;
            }
        }
    }
}
