using Microsoft.Xna.Framework.Graphics;
using Sprint0.interfaces;
using Sprint0.Sprites;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Theming;

namespace Sprint0.Command
{
    public abstract class ScriptCommand : ICommand
    {
        protected Script receiver;

        public ScriptCommand(Script receiver)
        {
            this.receiver = receiver;
        }
        public abstract void Execute();
    }

    public abstract class SpriteCommand : ICommand
    {
        protected Sprite receiver;

        public SpriteCommand(Sprite receiver)
        {
            this.receiver = receiver;
        }
        public abstract void Execute();
    }

}







