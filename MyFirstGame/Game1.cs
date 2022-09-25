using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Sprites;
using Sprint0.Command;
using Sprint0.Controller;
using Sprint0.interfaces;
using Sprint0.Theming;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sprint0
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        static private Game1 game;
        SpriteBatch spriteBatch;
        Stage stage;
        List<Scene> scenes;
        int scene;

        public static Game1 Game
        {
            get
            {
                return game;
            }
        }
        public Stage Stage
        {
            get
            {
                return stage;
            }
        }

        public Scene Scene
        {
            get
            {
                return scenes[scene - 1];
            }
        }
        public GraphicsDeviceManager Graphics
        {
            get
            {
                return graphics;
            }

            private set
            {
                graphics = value;
            }
        }

        //private Sprite mario;
        //private Sprite coin;
        //private Sprite star;
        //private Sprite fireFlower;
        //private Sprite superMushroom;
        //private Sprite oneUpMushroom;



        public Game1()
        {
            game = this;
            stage = new Stage(this);
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            scenes = new List<Scene>();
            scenes.Add(new Scene(stage));
            scene = 1;
        }

        protected override void Initialize()
        {

            scenes[scene - 1].Initialize();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            scenes[scene - 1].LoadContent();

            //mario = PlayerOneAvatarFactory.Instance.Create(this, new Vector2(100,100));
            //coin = CoinFactory.Instance.Create(this, new Vector2(150, 100));
            //star = StarFactory.Instance.Create(this, new Vector2(200, 100));
            //fireFlower = FireFlowerFactory.Instance.Create(this, new Vector2(250, 100));
            //superMushroom = SuperMushroomFactory.Instance.Create(this, new Vector2(300, 100));
            //oneUpMushroom = OneUpMushroomFactory.Instance.Create(this, new Vector2(350, 100));

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            scenes[scene - 1].Update(gameTime);

            //coin.Update(gameTime);
            //star.Update(gameTime);
            //fireFlower.Update(gameTime);
            //superMushroom.Update(gameTime);
            //oneUpMushroom.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            scenes[scene - 1].Draw(gameTime);


            //mario.Draw(_spriteBatch);
            //coin.Draw(_spriteBatch);
            //star.Draw(_spriteBatch);
            //fireFlower.Draw(_spriteBatch);
            //superMushroom.Draw(_spriteBatch);
            //oneUpMushroom.Draw(_spriteBatch);


            base.Draw(gameTime);
        }

    }
}