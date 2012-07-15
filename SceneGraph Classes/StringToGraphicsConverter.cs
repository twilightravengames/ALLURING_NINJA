using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace AlluringNinja.SceneGraph_Classes
{
    public class StringToGraphicsConverter
    {
  
            public static Texture2D convertBackgroundTile(String id, SceneGraph sceneGraph)
            {
                Texture2D texture = null;

                if (id.Equals("TEST_TILE"))
                {
                    texture = sceneGraph.getContentManager().Load<Texture2D>("bg1");
                }

                return texture;
            }
        }

}
