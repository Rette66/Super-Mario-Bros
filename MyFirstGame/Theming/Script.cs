using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Sprint0.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Sprites;
using Sprint0.Command;

namespace Sprint0.Theming
{
    public class Script
    {
        Scene scene;

        public Script(Scene scene)
        {
            this.scene = scene;
        }

        private Stage Stage
        {
            get { return scene.Stage; }
        }

        private Game1 Game
        {
            get { return Stage.Game; }
        }


        public void Initialize()
        {

            foreach (Controllers controller in Stage.Controllers)
            {
                if (controller is KeyboardController)
                {
                    controller.Command((int)Keys.Q, new ExitCommand(this));
                    controller.Command((int)Keys.W, new VisibleCommand(QuestionBlockFactory.Instance.Create(Game, new Vector2(100, 200))));
                }
            }
        }

        public void ExitCommand()
        {
            Game.Exit();
        }
        public void CreateState1Command()
        {

            scene.Add(QuestionBlockFactory.Instance.Create(Game, new Vector2(100,200)));
        }
       
    }
}
