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
        public bool checkCollisions(int firstPossitionX, int secondPossitionX,
                                    int firstPossitionY, int secondPossitionY,
                                    int firstCollisionBoxSizeY, int secondCollisionBoxSizeY,
                                    int firstCollisionBoxSizeX, int secondCollisionBoxSizeX,
                                    int firstObjectOffset, int secondObjectOffset)
        {

            Rectangle firstObj = new Rectangle((int)firstPossitionX + firstObjectOffset,
                                                 (int)firstPossitionY + firstObjectOffset,
                                                 firstCollisionBoxSizeX - (firstObjectOffset * 2),
                                                 firstCollisionBoxSizeX - (firstObjectOffset * 2));

            Rectangle secondObj = new Rectangle((int)secondPossitionX + secondObjectOffset,
                                                (int)secondPossitionY + secondObjectOffset,
                                                secondCollisionBoxSizeX - (secondObjectOffset * 2),
                                                secondCollisionBoxSizeY - (secondObjectOffset * 2));

            return firstObj.Intersects(secondObj);

        }

    }
}
