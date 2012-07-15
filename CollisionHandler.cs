using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using AlluringNinja.SceneGraph_Classes;

namespace AlluringNinja
{
    public class CollisionHandler
    {
        SceneGraph sceneGraph;

        public CollisionHandler(SceneGraph sceneGraph)
        {
            this.sceneGraph = sceneGraph;
        }


        public Boolean isInCollisions(Vector2 objectPosition, float width, float height)
        {
            return sceneGraph.isInCollisions(objectPosition, width, height);
        }

        public Boolean isCollidingWithFloor(Vector2 objectPosition, float width, float height)
        {
            return sceneGraph.isCollidingWithFloor(objectPosition, width, height);
        }

        public void gravityHandler(Character2D character)
        {
            if (!isCollidingWithFloor(character.objectPosition, character.width, character.height))
            {
                //System.Console.WriteLine("Gravity Handler: changing status to falling");
                character.changeStatus(GameConstants.PLAYER_FALL_MSG);
            }
            else
            {
                Console.WriteLine("Gravity collision");
            }
        }

    }
}
