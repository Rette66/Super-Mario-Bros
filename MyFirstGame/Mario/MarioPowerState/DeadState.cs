﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Block.State.GameState;
using Sprint0.Item;
using Sprint0.Mario.MarioMotionState;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Mario.MarioPowerState
{
    public class DeadState : MarioPowerState
    {
        private Texture2D background;
        Vector2 anchor;
        public DeadState(MarioEntity mario)
            : base(mario)
        {
        }

        public override void Enter(IMarioPowerState powerState)
        {
            SoundStorage.Instance.PlayDie();
            SoundStorage.Instance.StopBGM();
            CurrentState = this;
            this.previousState = powerState;
            anchor.X += Mario.Sprite.FrameSize.X;

            EntityStorage.Instance.MovableEntities.Remove(Mario);
            anchor = Mario.Position;
            Mario.onGround = false;
            //Mario.Speed = new Vector2(0, -200);


            int type = Mario.generateType(CurrentMotionState, CurrentState);
            Mario.Sprite = Mario.MarioFactory.CreateMario(Mario.game, Mario.Position, type);
            Mario.marioType = type;
            //background = Game1.Instance.Content.Load<Texture2D>("gameover");
        }

        public override void NormalTransion()
        {
            CurrentState.Exit();
            CurrentState = new NormalState(Mario);
            CurrentState.Enter(this);
        }
        public override void FireTransion()
        {
            CurrentState.Exit();
            CurrentState = new FireState(Mario);
            CurrentState.Enter(this);
        }
        public override void SuperTransion()
        {
            CurrentState.Exit();
            CurrentState = new SuperState(Mario);
            CurrentState.Enter(this);
        }

        public override void Exit()
        {
            EntityStorage.Instance.MovableEntities.Add(Mario);
            base.Exit();
        }

        public override void Update(GameTime gameTime)
        {
            //if((anchor.X - Mario.Position.X) > 50)
            //{
            //    Mario.Speed = -Mario.Speed;
            //}
        }
    }
}
