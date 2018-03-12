using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestGame
{
    class Movement
    {
        public bool grounded = false;
        public int gravity = 5;
        public int jumpForce = -10;
        public float maxJumpHeight = 10;
        public float currentHeight = 0;
        public float jumpOffset = 90.0f;
        public Vector2 acceleration = new Vector2(0, 0);
        GamePadState previousState;
        GamePadState statepad;

        public Vector2 PlayerControls(Vector2 position, GameTime gameTime, GraphicsDeviceManager graphic) {
            previousState = GamePad.GetState(PlayerIndex.One);
            position.Y += acceleration.Y + gravity;
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);

            if (capabilities.IsConnected)
            {
                position = BasicMovement(position);
                position = JumpingSection(position);
                
            }
            return position;
        }

        public Vector2 BasicMovement(Vector2 position) {
            previousState = statepad;
            statepad = GamePad.GetState(PlayerIndex.One);
            if(statepad.ThumbSticks.Left.X < -0.5f)
                position.X -= 10.0f;
            if(statepad.ThumbSticks.Left.X > 0.5f)
                position.X += 10.0f;

            if(statepad.DPad.Left == ButtonState.Pressed)
                position.X -= 10.0f;
            if(statepad.DPad.Right == ButtonState.Pressed)
                position.X += 10.0f;
            return position;
        }


        public Vector2 JumpingSection(Vector2 position) {

            bool wasJump = statepad.Buttons.A == ButtonState.Pressed && previousState.Buttons.A == ButtonState.Released && grounded;
            if(grounded) {
                currentHeight = position.Y;
            }
            if(wasJump) {
                acceleration.Y = jumpForce;
                grounded = false;
                maxJumpHeight = currentHeight - jumpOffset; /// how high can player jump from current location
            }
            if(position.Y < maxJumpHeight) {
                gravity = 5;
                acceleration.Y = 0;
            }
            return position;
        }
    }
}
