using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AlluringNinja.Message_Data_Types
{
    public class MovementMessage
    {
        public String objectId = null;
        public Vector2 originalPosition = new Vector2(0, 0);
        public Vector2 destinationPosition = new Vector2(0, 0);
        public float rateOfMovement = 0.0f;
        public bool messageTerminated = false;
        public int lastMovementTime = UtilityTimer.getTime();
        public String messageTypeId = null;
    }
}
