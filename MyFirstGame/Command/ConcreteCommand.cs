using Sprint0;
using Sprint0.Block;
using Sprint0.Mario;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ChangeToFireMario(MarioContext receiver)
            :base(receiver) { }

        public override void Execute()
        {
            receiver.ChangeToFire();
        }
    }

    public class ChangeToSuperMario : MarioCommand
    {
        public ChangeToSuperMario(MarioContext receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.ChangeToSuper();
        }
    }

    public class ChangeToNormalMario : MarioCommand
    {
        public ChangeToNormalMario(MarioContext receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.ChangeToNormal();
        }
    }

    public class MarioTakeDamege : MarioCommand
    {
        public MarioTakeDamege(MarioContext receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.TakeDamage();
        }
    }
    public class MarioWalkingLeft : MarioCommand
    {
        public MarioWalkingLeft(MarioContext receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.walkingLeft();
        }
    }
    public class MarioWalkingRight : MarioCommand
    {
        public MarioWalkingRight(MarioContext receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.walkingRight();
        }
    }
    public class MarioJumping : MarioCommand
    {
        public MarioJumping(MarioContext receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.jumping();
        }
    }
    public class MarioCrouching : MarioCommand
    {
        public MarioCrouching(MarioContext receiver)
            : base(receiver) { }

        public override void Execute()
        {
            receiver.crouching();
        }
    }

    public class QuestionBlockBump : QuestionBlockCommand
    {
        public QuestionBlockBump(QuestionBlock receiver)
            : base(receiver) { }
        public override void Execute()
        {
            receiver.ChangeToUsedBlock();
            receiver.ContainItem();
        }
    }

    public class BrickBlockBump : BrickBlockCommand
    {
        public BrickBlockBump(BrickBlock receiver)
            : base(receiver) { }
        public override void Execute()
        {
            receiver.Bump();
            receiver.Explode();
        }
    }

    public class BrickBlockChangeVisible : BrickBlockCommand
    {
        public BrickBlockChangeVisible(BrickBlock receiver)
            : base(receiver) { }
        public override void Execute()
        {
            receiver.ChangeVisble();
            receiver.Bump();
        }
    }



}
