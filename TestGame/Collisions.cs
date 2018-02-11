using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TestGame
{
    class Collisions
    {
        public bool checkCollisions(Sprite firstSprite, Sprite secondSprite)
        {

            Rectangle firstObj = new Rectangle((int)firstSprite.SpritePlacement.X + firstSprite.CollisionOffset,
                                                 (int)firstSprite.SpritePlacement.Y + firstSprite.CollisionOffset,
                                                 firstSprite.SpriteCollisionBoarders.X - (firstSprite.CollisionOffset * 2),
                                                 firstSprite.SpriteCollisionBoarders.Y - (firstSprite.CollisionOffset * 2));

            Rectangle secondObj = new Rectangle((int)secondSprite.SpritePlacement.X + secondSprite.CollisionOffset,
                                                (int)secondSprite.SpritePlacement.Y + secondSprite.CollisionOffset,
                                                secondSprite.SpriteCollisionBoarders.X - (secondSprite.CollisionOffset * 2),
                                                secondSprite.SpriteCollisionBoarders.Y - (secondSprite.CollisionOffset * 2));

            return firstObj.Intersects(secondObj);

        }

    }
}
