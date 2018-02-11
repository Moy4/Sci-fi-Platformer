using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace TestGame
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite ballSprite = new Sprite(1, 2, 64, 64, 0);
        Sprite groundSprite = new Sprite(1, 500, 700, 100, 0);
        Texture2D myImage;
        Texture2D rect;
        Movement playerMovement;
        Collisions coliderChecker = new Collisions();

        public Game1(){
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            playerMovement = new Movement();

        }

        protected override void Initialize(){
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent(){
            /// READ MORE ABOUT LOADING CONTENT BECAUSE
            /// THIS FUNCTION WILL LOOK LIKE SHIT 
            /// IF IT WILL STAY IN CURRENT VERSION OF 
            /// LOADING CONTENT 
            spriteBatch = new SpriteBatch(GraphicsDevice);
            myImage = Content.Load<Texture2D>("ball");
            rect = new Texture2D(graphics.GraphicsDevice, groundSprite.SpriteCollisionBoarders.X, groundSprite.SpriteCollisionBoarders.Y);
            Color[] data = new Color[groundSprite.SpriteCollisionBoarders.X * groundSprite.SpriteCollisionBoarders.Y];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Blue;
                rect.SetData(data);  
        }

        protected override void UnloadContent(){
        }

        protected override void Update(GameTime gameTime){
            
            if (IsActive) { 
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();
                ballSprite.SpritePlacement = playerMovement.PlayerControls(ballSprite.SpritePlacement, gameTime, graphics);
                if (coliderChecker.checkCollisions(ballSprite, groundSprite)) { 
                    playerMovement.grounded = true;
                    playerMovement.velocity.Y = 0;
                }
                if (!coliderChecker.checkCollisions(ballSprite, groundSprite)) {
                    playerMovement.grounded = false;
                    playerMovement.velocity.Y = 5;
                }

                base.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime){
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(myImage, ballSprite.SpritePlacement, Color.White);
            spriteBatch.Draw(rect, groundSprite.SpritePlacement, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
