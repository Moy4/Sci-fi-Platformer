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
        Texture2D myImage;
        Vector2 position;
        Vector2 coor;
        Movement playerMovement;
        Texture2D rect;
        Collisions coliderChecker = new Collisions();
        Point groundFrameSize = new Point(700, 100);
        Point ballFrameSize = new Point(64, 64);

        int groundCollisionRectOffset = 0;
        int ballCollisionRectOffset = 0;

        protected bool Collide() {
            Rectangle ballRect = new Rectangle((int)position.X + ballCollisionRectOffset,
                                                 (int)position.Y + ballCollisionRectOffset,
                                                 ballFrameSize.X - (ballCollisionRectOffset * 2),
                                                 ballFrameSize.Y - (ballCollisionRectOffset * 2));

            Rectangle groundRect = new Rectangle((int)coor.X + groundCollisionRectOffset,
                                                (int)coor.Y + groundCollisionRectOffset,
                                                groundFrameSize.X - (groundCollisionRectOffset * 2),
                                                groundFrameSize.Y - (groundCollisionRectOffset * 2));

            return ballRect.Intersects(groundRect);
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            position = new Vector2(1, 2);
            coor = new Vector2(1, 500);
            playerMovement = new Movement();

        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            myImage = Content.Load<Texture2D>("ball");
            rect = new Texture2D(graphics.GraphicsDevice, 700, 100);
            Color[] data = new Color[700 * 100];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Blue;
                rect.SetData(data);

            
        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            
            if (IsActive) { 
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();
                position = playerMovement.PlayerControls(position, gameTime, graphics);
                ///playerMovement.DetectCollision(position, coor);
                if (Collide()) { 
                    playerMovement.grounded = true;
                    playerMovement.velocity.Y = 0;
                }
                if (!Collide()) {
                    playerMovement.grounded = false;
                    playerMovement.velocity.Y = 5;
                }

                base.Update(gameTime);
            }
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(myImage, position, Color.White);
            spriteBatch.Draw(rect, coor, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
