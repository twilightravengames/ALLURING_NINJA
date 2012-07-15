using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlluringNinja.SceneGraph_Classes
{
    public class Player : Character2D
    {
        

        public Player(SceneGraph sceneGraph) : base(sceneGraph)
        {
            currentStatus = GameConstants.PLAYER_NO_MOVEMENT_MSG;
            
        }

        public override void draw(RenderingEngine renderingEngine)
        {
            ((Animation)(animationList[currentAnimation])).draw(renderingEngine, this);
        }    

        
    
    }
}
