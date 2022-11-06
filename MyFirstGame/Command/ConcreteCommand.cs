﻿using Sprint0;
using Sprint0.Block;
using Sprint0.Mario;
using Sprint0.Sprites;
using Sprint0.State;
using Sprint0.Block.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Block.State.GameState;

namespace Sprint0.Command
{
    public class ExitCommand : GameCommand
    {
        public ExitCommand(Game1 receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.ExitCommnad();
        }
    }


    public class ChangeToFireMario : MarioCommand
    {
        public ChangeToFireMario(Entity receiver)
            :base((MarioEntity)receiver) { }

        public override void Execute()
        {
           receiver.Fire();
           receiver.initalizeFireballPool();
        }
    }

    public class ChangeToSuperMario : MarioCommand
    {
        public ChangeToSuperMario(Entity receiver)
            : base((MarioEntity)receiver) { }

        public override void Execute()
        {
            receiver.Super();
        }
    }

    public class ChangeToNormalMario : MarioCommand
    {
        public ChangeToNormalMario(Entity receiver)
            : base((MarioEntity)receiver) { }

        public override void Execute()
        {
            receiver.Normal();
        }
    }

    public class MarioTakeDamege : MarioCommand
    {
        public MarioTakeDamege(Entity receiver)
            : base((MarioEntity)receiver) { }

        public override void Execute()
        {
            receiver.TakeDamage();
        }
    }

    public class MarioJump : MarioCommand
    {
        public MarioJump(Entity receiver)
            : base((MarioEntity)receiver) { }

        public override void Execute()
        {
            receiver.Jump();
        }
    }

    public class MarioCrouch : MarioCommand
    {
        public MarioCrouch(Entity receiver)
            : base((MarioEntity)receiver) { }

        public override void Execute()
        {
            receiver.Crouch();
        }
    }

    public class MarioWalkRight : MarioCommand
    {
        public MarioWalkRight(Entity receiver)
            : base((MarioEntity)receiver) { }

        public override void Execute()
        {
            receiver.WalkRight();
        }
    }
    public class MarioWalkLeft : MarioCommand
    {
        public MarioWalkLeft(Entity receiver)
            : base((MarioEntity)receiver) { }

        public override void Execute()
        {
            receiver.WalkLeft();
        }
    }

 

    public class BlockBump : BlockCommand
    {
        public BlockBump(BlockEntity receiver)
            : base(receiver) { }
        public override void Execute()
        {
            receiver.BumpTransition();
        }

    }



    public class ShowBoundBox : EntityCommand
    {
        public ShowBoundBox(List<Entity> receiver)
            :base(receiver) { }

        public override void Execute()
        {
            foreach (Entity entity in receiver)
            {
                entity?.ShowBoundBox();
            }
        }

    }

    public class ResetCommand : GameCommand
    {
        public ResetCommand(Game1 receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.ResetCommand();
        }
    }
    public class PauseCommand : EntityStorageCommand
    {
        public PauseCommand(EntityStorage receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.PauseCommand();
 
        }
    }
    public class ShootingFireballCommand : MarioCommand
    {
        public ShootingFireballCommand(Entity receiver)
            : base((MarioEntity)receiver) { }

        public override void Execute()
        {
            receiver.ShootingFireball();
        }
    }

}
