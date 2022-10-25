﻿using Microsoft.Xna.Framework;
using Sprint0.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Enemy.EnemyState
{
    public class KoopaTroopaDeathState : EnemyState
    {
        private static readonly TimeSpan intervalBetweenAlive = TimeSpan.FromMilliseconds(4000);
        private TimeSpan lastTimeAlive;
        public KoopaTroopaDeathState(EnemyEntity enemy)
             : base(enemy)
        {
        }
        public override void NormalTransition()
        {
            CurrentState.Exit();
            CurrentState = new KoopaTroopaNormalState(Enemy);
            CurrentState.Enter(this);
        }
        public override void Enter(IEnemyState previousState)
        {
            CurrentState = this;
            this.previousState = previousState;
            Enemy.Sprite = Enemy.EnemyFactory.CreateEnemy(Enemy.game, Enemy.Position, 4);
        }
        public override void ShellBump(string dir)
        {
            CurrentState.Exit();
            CurrentState = new KoopaTroopaMovingShellState(Enemy, dir);
            CurrentState.Enter(this);
        }
        public override void Update(GameTime gameTime)
        {
            Enemy.Speed = new Vector2(0, 0); 
            if (lastTimeAlive + intervalBetweenAlive < gameTime.TotalGameTime)
            {
                //Alive();
                lastTimeAlive = gameTime.TotalGameTime;
            }
        }
        void Alive()
        {
            CurrentState.Exit();
            CurrentState = new KoopaTroopaNormalState(Enemy);
            CurrentState.Enter(this);
        }
    }
}
