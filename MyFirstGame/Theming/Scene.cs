using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Sprint0.interfaces;
using Sprint0.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Theming
{
    public class Scene : IDisposable
    {
        private SpriteBatch spriteBatch;
        private Stage stage;
        private Script script;
        private List<ISprite> listSprites;

        private Texture2D background;

        public Stage Stage
        {
            get { return stage; }
        }
        public Scene(Stage stage)
        {
            this.stage = stage;
            script = new Script(this);
            listSprites = new List<ISprite>();
        }

        public void Add(ISprite sprite)
        {
            listSprites.Add(sprite);
        }
        public void Initialize()
        {
            stage.Initialize();
            script.Initialize();
        }

        public void LoadContent()
        {
            spriteBatch = new SpriteBatch(stage.Game.GraphicsDevice);
            background = Stage.Game.Content.Load<Texture2D>("sky");
            stage.LoadContent();
        }
        public void Update(GameTime gameTime)
        {
            stage.Update(gameTime);

            foreach (Sprite sprite in listSprites)
                sprite.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            stage.Draw(gameTime);

            stage.GraphicsDevice.GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);
            
            spriteBatch.End();


        }

        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                spriteBatch.Dispose();
            }
            // free native resources
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

