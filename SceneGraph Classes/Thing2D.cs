using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AlluringNinja.SceneGraph_Classes
{
    public class Thing2D
    {
        public Texture2D objectTexture;
        public Vector2 objectPosition;
        public Vector2 scale;
        public String idString;
        public float width;
        public float height;

        public void draw(RenderingEngine renderingEngine)
        {
            renderingEngine.DrawScaled2DModel(this);
        }

        public Vector2 getObjectPosition()
        {
            return objectPosition;
        }

        public void setObjectPosition(Vector2 objectPosition)
        {
            this.objectPosition = objectPosition;
        }

        public void setTexture2D(Texture2D objectTexture)
        {
            this.objectTexture = objectTexture;
        }

        public void setScale(Vector2 scale)
        {
            this.scale = scale;
        }
    }
}
