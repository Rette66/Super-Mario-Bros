﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;
using Sprint0.Mario;
using Sprint0.Sprites;
using Sprint0.Sprites.factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.CollisionDetection;


namespace Sprint0.Enemy
{
    public class EnemyEntity : Entity//, IMovableEntity
    {
        public IEnemyState currentState { get; set; }

        public virtual EnemyFactory EnemyFactory => game.EnemyFactory;
        public eEnemyType EnemyType { get; set; }


        public EnemyEntity(Game1 game, Vector2 position) : base(game, position)
        {
        }

        public enum eEnemyType
        {
            Goomba = 1,
            KoopaTroopa = 2,
            DeadGooma = 3,
            IdleDeadKoopaTroopa = 4,
            MovingDeadKoopaTroopa = 5,
        }
        public override void Update(GameTime gameTime, List<Entity> blockEntities)
        {
            //if (Math.Abs(Position.X - EntityStorage.Instance.Mario.Position.X) < 350)
            //{
            //    EntityStorage.Instance.movableAdd(this);
            //}
            //else
            //{
            //    EntityStorage.Instance.movableRemove(this);
            //}

            base.Update(gameTime, blockEntities);
            currentState?.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public void NormalTransition(string dir)
        {
            currentState?.NormalTransition(dir);
        }
        public void KillTransition()
        {
            currentState?.KillTransition();
        }
        public void ShellTransition()
        {
            currentState?.ShellTransition();
        }
        public void ShellBump(string dir)
        {
            currentState?.ShellBump(dir);
        }
    }
}
