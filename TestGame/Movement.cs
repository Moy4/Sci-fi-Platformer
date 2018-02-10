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
        public Vector2 velocity = new Vector2(0, 10);
        GamePadState previousState;
        GamePadState statepad;
        bool hasJumped = false;

        public Vector2 PlayerControls(Vector2 position, GameTime gameTime, GraphicsDeviceManager graphic) {
            previousState = GamePad.GetState(PlayerIndex.One);
            position.Y += velocity.Y;
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);
            if (capabilities.IsConnected)
            {
                previousState = statepad;
                statepad = GamePad.GetState(PlayerIndex.One);
                if (statepad.ThumbSticks.Left.X < -0.5f)
                    position.X -= 10.0f;
                if (statepad.ThumbSticks.Left.X > 0.5f)
                    position.X += 10.0f;

                if (statepad.DPad.Left == ButtonState.Pressed)
                    position.X -= 10.0f;
                if (statepad.DPad.Right == ButtonState.Pressed)
                    position.X += 10.0f;

           
                bool wasJump = statepad.Buttons.A == ButtonState.Pressed && previousState.Buttons.A == ButtonState.Released && grounded;
                if (wasJump) {
                    grounded = false;
                    velocity -= new Vector2(0, 150);
                    hasJumped = true;
                }
                if (hasJumped) {
                    position.Y += velocity.Y;
                }
            }
            return position;
        }
    }
}
