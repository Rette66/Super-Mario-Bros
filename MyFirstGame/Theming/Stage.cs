using Microsoft.Xna.Framework;
using Sprint0.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Theming
{
    public class Stage
    {
        public Game1 Game { get; set; }

        List<Controllers> controllers;

        public List<Controllers> Controllers
        {
            get { return this.controllers; }
        }

        public GraphicsDeviceManager GraphicsDevice
        {
            get { return Game.Graphics; }
        }

        public Stage(Game1 game)
        {
            Game = game;
            controllers = new List<Controllers>();
        }

        public void Initialize()
        {
            controllers.Add(new KeyboardController(Game));
        }

        public void LoadContent()
        {
        }

        public void Update(GameTime gameTime)
        {
            foreach (Controllers controller in controllers)
                controller.Update();
        }

        public void Draw(GameTime gameTime)
        {
        }
    }
}
