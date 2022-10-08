﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block.State;
using Sprint0.Mario;
using Sprint0.Mario.MarioMotionState;
using Sprint0.Mario.MarioPowerState;
using Sprint0.Sprites;
using Sprint0.Sprites.factory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Sprint0.State
{
    public class BlockEntity : Entity
    {

        public IBlockState CurrentState { get; set; }
        public eBlockType BlockType { get; set; }
        public MarioEntity Mario { get; set; }

        public virtual BlockFactory BlockFactory => game.BlockFactory;

        public bool isVisible = true;

        public enum eBlockType
        {
            QuestionBlock = 1,
            BrickBlock = 2,
            FloorBlock = 3,
            StairBlock = 4,
            UsedBlock = 5,
            SmallBrickBlock = 6,
        }

        public BlockEntity(Game1 game, Vector2 position,MarioEntity mario) : base(game, position)
        {
            Mario = mario;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Speed += Accelation * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            CurrentState?.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
            base.Draw(spriteBatch);
            
        }

        public void hideBrickBlock()
        {
            isVisible = false;
        }

        public void changeToVisible()
        {
            isVisible = true;
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
                    CurrentState?.BumpTransition();
                    break;
            }
        }

    }
}
