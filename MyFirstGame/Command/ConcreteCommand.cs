using Sprint0;
using Sprint0.Sprites;
using Sprint0.Theming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Command
{
    class ExitCommand : ScriptCommand
    {
        public ExitCommand(Script receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.ExitCommand();
        }

    }
    class CreateState1Command : ScriptCommand
    {
        public CreateState1Command(Script receiver)
            : base(receiver)
        {

        }
        public override void Execute()
        {
            receiver.CreateState1Command();
        }
    }
}
