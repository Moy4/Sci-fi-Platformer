using Microsoft.Xna.Framework;
using System;

namespace TestGame{

    class Sprite{

        private Vector3 spritePlacement;
        private Vector3 spriteCollisionBoarders;
        private int collisionOffset; 

        public Vector3 SpritePlacement{

            get{
                return spritePlacement;
            }                          

            set{
                spritePlacement = value;
            }
        }

        public Vector3 SpriteCollisionBoarders{

            get{
                return spriteCollisionBoarders;
            }

            set{
                spriteCollisionBoarders = value;
            }
        }

        public int CollisionOffset {
            get {
                return collisionOffset;
            }

            set {
                collisionOffset = value;
            }
        }

        public Sprite(int sprite) {
        }

    }
}
