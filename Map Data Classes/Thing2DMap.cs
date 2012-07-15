using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace AlluringNinja.Map_Data_Classes
{
    public class Thing2DMap
    {
        public Vector2 objectPosition;
        public Vector2 scale;

        public Vector2 getObjectPosition()
        {
            return objectPosition;
        }

        public Vector2 getScale()
        {
            return scale;
        }

        public void setObjectPosition(Vector2 objectPosition)
        {
            this.objectPosition = objectPosition;
        }

        public void setScale(Vector2 scale)
        {
            this.scale = scale;
        }
    }
}
