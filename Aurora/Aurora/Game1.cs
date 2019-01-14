using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Aurora.Core;
using Aurora.Core.Scenes;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Aurora.Core.Collision;

namespace Aurora
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1400;
            graphics.PreferredBackBufferHeight = 800;
            //graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Core.Overseer.Instance.GDM = graphics;
            Core.Overseer.Instance.GD = GraphicsDevice;

            // Initializes all managers once params are set:
            Core.Overseer.Instance.Init();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Loads all textures:
            Core.Loader.LoadTextures(this.Content, new string[] {
                "bg",
                "down_stand",
                "down_walk1",
                "down_walk2",
                "left_walk1",
                "left_walk2",
                "right_walk1",
                "right_walk2",
                "up_walk1",
                "up_walk2",
                "Raptor",
                "phoenix",
                "DKnight",
                "flame"
            });

            // Loads all maps:
            Core.Loader.LoadMaps(this.Content, new string[] {
                "BattleMap"
            });

            SoundEffect SE = Content.Load<SoundEffect>("musicloop");
            //SE.Play();

            // Add and activate a test scene.
            Overseer.Instance.SceneManager.AddScene("TestScene", new Test.TestScene1.TestScene(), true);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Scenemanager updates the current active scene:
            Overseer.Instance.SceneManager.Update(gameTime);
            Core.Collision.CollisionManager.Instance.Update();
            Overseer.Instance.Renderers.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Overseer.Instance.SceneManager.ActiveScene.ActiveCamera.Transform);
            
            // SceneManager draws the current active scene.
            Overseer.Instance.SceneManager.Draw(spriteBatch);

            CollisionManager.Instance.Draw(spriteBatch);


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
