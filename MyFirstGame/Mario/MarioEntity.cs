﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Controller;
using Sprint0.interfaces;
using Sprint0.Sprites;
using Sprint0.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using Sprint0.Mario.MarioMotionState;
using Sprint0.Mario.MarioPowerState;
using Sprint0.Sprites.factory;
using Sprint0.Block;
using Sprint0.State;
using Sprint0.Enemy;
using Microsoft.VisualBasic;
using Sprint0.CollisionDetection;
using Sprint0.Item;
using Sprint0.Interfaces;
using System.Security.Cryptography;
using System.ComponentModel.Design.Serialization;
using Sprint0.Enemy.EnemyState;

namespace Sprint0.Mario
{
    public class MarioEntity   : Entity, IMovableEntity
    {

        public IMarioPowerState currentPowerState { get; set; }
        public IMarioMotionState currentMotionState { get; set; }




        public  MarioFactory MarioFactory = MarioFactory.Instance;



        public enum eMarioType
        {
            DeadMario = 0,

            NormalIdleMario = 1,
            NormalWalkMario = 2,
            NormalJumpMario = 3,
            NormalCrouchMario = 4,

            FireIdleMario = 11,
            FireWalkMario = 12,
            FireJumpMario = 13,
            FireCrouchMario = 14,

            SuperIdleMario = 21,
            SuperWalkMario = 22,
            SuperJumpMario = 23,
            SuperCrouchMario = 24,
        }

        public int marioType { get; set; }

        public int generateType(IMarioMotionState motionState, IMarioPowerState powerState)
        {
            int type = 0;
            switch (motionState)
            {
                case IdleState:
                    type = 1;
                    break;
                case WalkState:
                    type = 2;
                    break;
                case JumpState:
                    type = 3;
                    break;
                case CrouchState:
                    type = 4;
                    break;
            }
            switch (powerState)
            {
                case NormalState: 
                    type +=0;
                    break;
                case FireState:
                    type +=10;
                    break;
                case SuperState:
                    type +=20;
                    break;
                case DeadState:
                    type = 0;
                    break;
            }
            return type;
        }



        public MarioEntity(Game1 game, Vector2 position)
            : base(game, position)
        {
            currentMotionState = new IdleState(this);
            currentPowerState = new NormalState(this);
            Sprite = MarioFactory.CreateMario(game, position, generateType(currentMotionState, currentPowerState));
            onGround = false;
        }

        public override void CollisionResponse(Entity entity, Vector2 position, CollisionDetector.Touching touching)
        {
            //Debug.WriteLine("mario position top left: " + (Position.Y - Sprite.FrameSize.Y));
            //Debug.WriteLine("before update position: " + this.Position);

            this.Position = position;
            //Debug.WriteLine("after update position: " + this.Position);
            switch (entity)
            {
                case BlockEntity block:
                    if (block.IsVisible)
                    {
                        if (touching is CollisionDetector.Touching.bottom)
                        {
                            onGround = true;
                            Fall();
                        }
                        else if(touching is CollisionDetector.Touching.top)
                        {
                            Speed = new Vector2(Speed.X, -Speed.Y);
                        }
                        else
                        {
                            Idle();
                        }

                    }
                    break;
                case ItemEntity:
                    switch (entity)
                    {
                        case FireFlowerEntity:
                            if (currentPowerState.GetType() == typeof(SuperState))
                            {
                                Fire();
                            }
                            if (currentPowerState.GetType() == typeof(NormalState))
                            {
                                Super();
                            }
                            break;
                        case OneUpMushroomEntity:

                            break;
                        case CoinEntity:

                            break;
                        case SuperMushroomEntity:
                            if (currentPowerState.GetType() == typeof(NormalState))
                                Super();
                            break;
                        case StarEntity:
                            //turn to star mario 
                            break;
                        case PipeEntity:
                            if (touching is CollisionDetector.Touching.bottom)
                            {
                                onGround = true;
                                Fall();
                            }
                            break;

                    }
                    break;
                case EnemyEntity:
                    switch (entity)
                    {
                        case GoombaEntity:
                            if (touching == CollisionDetector.Touching.right || touching == CollisionDetector.Touching.left)
                            {
                                Position = position;
                                Idle();
                                TakeDamage();
                            }
                            else
                            {
                                Fall();
                            }
                            break;
                        case KoopaTroopaEntity:
                            KoopaTroopaEntity koopa = (KoopaTroopaEntity)entity;
                            Debug.WriteLine(koopa.currentState.ToString());

                            if (koopa.currentState is KoopaTroopaDeathState )
                            {
                                if (touching != CollisionDetector.Touching.none && touching != CollisionDetector.Touching.bottom)
                                {
                                    Debug.WriteLine("DEBUG");
                                    Position = position;
                                    Idle();
                                }
                                else
                                {
                                    Fall();
                                }
                            }
                            else
                            {
                                if (touching != CollisionDetector.Touching.bottom && touching != CollisionDetector.Touching.none && touching != CollisionDetector.Touching.top)
                                {
                                    Debug.WriteLine("DEBUG - 2");
                                    Position = position;
                                    Idle();
                                    TakeDamage();
                                }
                                else
                                {
                                    Fall();
                                }
                            }
                            
                            break;
                    }
                    break;
            }
        }


        public override void Update(GameTime gameTime, List<Entity> entities)
        {

            base.Update(gameTime, entities);

            currentMotionState?.Update(gameTime);       
            currentPowerState?.Update(gameTime);

            if(Position.Y> 480)
            {
                TakeDamage();
                Speed = Vector2.Zero;
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }




 //----------------------------------------Motion Command Method-----------------------------------
        public void Jump()
        {
            if( !(currentPowerState is DeadState))
            {
                switch (currentMotionState)
                {
                    case CrouchState:
                        currentMotionState?.IdleTransion();
                        break;
                    default:
                        currentMotionState?.JumpTransion();
                        break;
                }
            }
        }

        public void Idle()
        {
            currentMotionState?.IdleTransion();
        }

        public void Fall()
        {
            currentMotionState?.FallTransion();
        }
        //the vertical and horizontal speed after state change will turn to zero
        //need to fix this problem later
        public void WalkRight()
        {
            if(!(currentPowerState is DeadState))
            {
                switch (currentMotionState)
                {
                    case IdleState:
                        if (Sprite.Orientation == SpriteEffects.None)
                        {
                            currentMotionState?.WalkTransion();
                        }
                        else
                        {
                            Sprite.Orientation = SpriteEffects.None;
                        }
                        break;
                    case WalkState:
                        if (Sprite.Orientation == SpriteEffects.FlipHorizontally)
                        {
                            currentMotionState?.IdleTransion();
                        }
                        break;
                    case JumpState:
                        if (Sprite.Orientation == SpriteEffects.None)
                        {
                            Speed += new Vector2(40, 0);
                        }
                        else
                        {
                            Sprite.Orientation = SpriteEffects.None;
                            currentMotionState?.IdleTransion();
                        }
                        break;
                    case CrouchState:
                        if (Sprite.Orientation == SpriteEffects.None)
                        {
                            currentMotionState?.IdleTransion();
                        }
                        else
                        {
                            Sprite.Orientation = SpriteEffects.None;
                            currentMotionState?.IdleTransion();
                        }
                        break;
                }
            }
            

        }
        public void WalkLeft()
        {
            if(!(currentPowerState is DeadState))
            {
                switch (currentMotionState)
                {
                    case IdleState:
                        if (Sprite.Orientation == SpriteEffects.FlipHorizontally)
                        {
                            currentMotionState?.WalkTransion();
                        }
                        else
                        {
                            Sprite.Orientation = SpriteEffects.FlipHorizontally;
                        }
                        break;
                    case WalkState:
                        if (Sprite.Orientation == SpriteEffects.None)
                        {
                            currentMotionState?.IdleTransion();
                        }
                        break;
                    case JumpState:
                        if (Sprite.Orientation == SpriteEffects.FlipHorizontally)
                        {
                            Speed += new Vector2(-40, 0);
                        }
                        else
                        {
                            Sprite.Orientation = SpriteEffects.FlipHorizontally;
                            currentMotionState?.IdleTransion();
                        }
                        break;
                    case CrouchState:
                        if (Sprite.Orientation == SpriteEffects.FlipHorizontally)
                        {
                            currentMotionState?.IdleTransion();
                        }
                        else
                        {
                            Sprite.Orientation = SpriteEffects.FlipHorizontally;
                            currentMotionState?.IdleTransion();
                        }
                        break;
                }
            }
        }
        public void Crouch()
        {
            if(!(currentPowerState is DeadState))
            {
                switch (currentMotionState)
                {
                    case JumpState:
                        currentMotionState?.IdleTransion();
                        break;
                    case WalkState:
                        currentMotionState?.IdleTransion();
                        break;
                    default:
                        // if(currentPowerState.GetType() != typeof(NormalState))
                        currentMotionState?.CrouchTransion();
                        break;
                }
            }

        }
        public void ShootingFireball()
        {
            if (currentPowerState is FireState) { 
            FireballEntity fireball = new FireballEntity(game, Position, Entities);
            EntityStorage.Instance.movableAdd(fireball);
            }
        }

        //-------------------------------------------Power Command Method--------------------------------

        public void Fire()
        {
            
            currentPowerState?.FireTransion();
        }
        public void Normal()
        {
            
            currentPowerState?.NormalTransion();
        }
        public void Super()
        {
            
            currentPowerState?.SuperTransion();
        }
        public void TakeDamage()
        {
            switch (currentPowerState)
            {
                case NormalState:
                    currentPowerState?.DeadTransion();
                    break;
                case SuperState:
                    currentPowerState?.NormalTransion();
                    break;
                case FireState:
                    currentPowerState?.SuperTransion();
                    break;
            }
        }
    }
}
