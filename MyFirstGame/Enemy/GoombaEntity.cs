﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Enemy.EnemyState;
using Sprint0.Mario;
using Sprint0.Sprites;
using Sprint0.Sprites.factory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.CollisionDetection;

namespace Sprint0.Enemy
{
    public class GoombaEntity : EnemyEntity
    {
        public GoombaEntity(Game1 game, Vector2 position)
            : base(game, position) 
        {
            //currentState = new IdleState(this);
            Sprite = EnemyFactory.CreateEnemy(game, position,(int)eEnemyType.Goomba);
            EnemyType = eEnemyType.Goomba;

        }

        public void goombaCollisionDetection(MarioEntity mario)
        {
            List<Entity> entities = new List<Entity>();
            entities.Add(mario);
            Tuple<Collision.Touching, float, float, Entity> detected = collisionDetection.detectCollsion(entities);
            if (detected.Item1 == Collision.Touching.top)
            {
                currentState = new GoombaDeathState(this);
                currentState?.Enter();
            }
        }

        public override void Update(GameTime gameTime,MarioEntity mario, List<Entity> blockEntities)
        {
            Mario = mario;
            goombaCollisionDetection(mario);
            base.Update(gameTime,mario, blockEntities);
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }

    }
}
