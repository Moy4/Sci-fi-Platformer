using Microsoft.Xna.Framework;

namespace TestGame{

    class Sprite{

        private Vector2 spritePlacement;
        private Point spriteCollisionBoarders;
        private int collisionOffset; 

        public Vector2 SpritePlacement {

            get{
                return spritePlacement;
            }                          

            set{
                spritePlacement = value;
            }
        }

        public Point SpriteCollisionBoarders {

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

        public Sprite(int placementX, int placementY, int pointX, int pointY, int offset) {
            SpritePlacement = new Vector2(placementX, placementY);
            SpriteCollisionBoarders = new Point(pointX, pointY);
            CollisionOffset = offset;


        }

    }
}
