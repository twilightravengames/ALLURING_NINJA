using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using AlluringNinja.SceneGraph_Classes;

namespace AlluringNinja
{
    public class TextureUtility
    {
        public static Texture2D SplitTexture(RenderingEngine renderingEngine, Texture2D baseTexture, Rectangle source)
        {
            GraphicsDevice graphicsDevice = renderingEngine.graphics.GraphicsDevice;
        

            Color[] data = new Color[source.Width * source.Height];
            baseTexture.GetData<Color>(0, source, data, 0, data.Length);

            Texture2D newTexture = new Texture2D(graphicsDevice, source.Width, source.Height);
            newTexture.SetData<Color>(data);

            return newTexture;
        } 

        public static Animation ConvertWalkingAnimation(RenderingEngine renderingEngine, Texture2D totalTexture)
        {
            Animation animation = new Animation();

            int width = 98;
            int height = 139;

            for (int animationNumber = 0; animationNumber < 10; animationNumber++)
            {
                
                Texture2D texture = TextureUtility.SplitTexture(renderingEngine, totalTexture, new Rectangle(animationNumber*width+animationNumber, 0, width, height));
                animation.addToTexture2DList(texture);
            }
            return animation;
        }


      

        public static Animation ConvertStillAnimation(RenderingEngine renderingEngine, Texture2D totalTexture)
        {
            Animation animation = new Animation();

            int width = 62;
            int height = 139;

            for (int animationNumber = 0; animationNumber < 3; animationNumber++)
            {
                Texture2D texture = TextureUtility.SplitTexture(renderingEngine, totalTexture, new Rectangle(animationNumber * width + animationNumber, height, width, height));
                animation.addToTexture2DList(texture);
            }
            return animation;
        }

        public static Animation ConvertChangingAnimation(RenderingEngine renderingEngine, Texture2D totalTexture)
        {
            Animation animation = new Animation();

            int width = 62;
            int height = 139;

            for (int animationNumber = 0; animationNumber < 6; animationNumber++)
            {
                Texture2D texture = TextureUtility.SplitTexture(renderingEngine, totalTexture, new Rectangle(animationNumber * width + animationNumber, 2*height, width, height));
                animation.addToTexture2DList(texture);
            }
            return animation;
        }

        public static Animation ConvertDeathAnimation(RenderingEngine renderingEngine, Texture2D totalTexture)
        {
            Animation animation = new Animation();

            int width = 62;
            int height = 131;

            for (int animationNumber = 0; animationNumber < 7; animationNumber++)
            {
                if (animationNumber > 3)
                {
                    width = 100;
                }
                Texture2D texture = TextureUtility.SplitTexture(renderingEngine, totalTexture, new Rectangle(animationNumber * width + animationNumber, 3 * height, width, height));
                animation.addToTexture2DList(texture);
            }
            return animation;
        }

        public static Animation ConvertInitialJumpAnimation(RenderingEngine renderingEngine, Texture2D totalTexture)
        {
            Animation animation = new Animation();

            int width = 100;
            int height = 131;

            for (int animationNumber = 0; animationNumber < 3; animationNumber++)
            {
                Texture2D texture = TextureUtility.SplitTexture(renderingEngine, totalTexture, new Rectangle(animationNumber * width + animationNumber, 4 * height, width, height));
                animation.addToTexture2DList(texture);
            }
            return animation;
        }

        public static Animation ConvertCycleJumpAnimation(RenderingEngine renderingEngine, Texture2D totalTexture)
        {
            Animation animation = new Animation();

            int width = 100;
            int height = 131;

            for (int animationNumber = 0; animationNumber < 2; animationNumber++)
            {
                Texture2D texture = TextureUtility.SplitTexture(renderingEngine, totalTexture, new Rectangle(3*(width + 1) + animationNumber * width + animationNumber, 4 * height, width, height));
                animation.addToTexture2DList(texture);
            }
            return animation;
        }

        public static Animation ConvertFallAnimation(RenderingEngine renderingEngine, Texture2D totalTexture)
        {
            Animation animation = new Animation();

            int width = 100;
            int height = 131;

            for (int animationNumber = 0; animationNumber < 2; animationNumber++)
            {
                Texture2D texture = TextureUtility.SplitTexture(renderingEngine, totalTexture, new Rectangle(5 * (width + 1) + animationNumber * width + animationNumber, 4 * height, width, height));
                animation.addToTexture2DList(texture);
            }
            return animation;
        }
        public static Animation ConvertAttackAnimation(RenderingEngine renderingEngine, Texture2D totalTexture)
        {
            Animation animation = new Animation();

            int width = 200;
            int height = 131;

            for (int animationNumber = 0; animationNumber < 3; animationNumber++)
            {
                Texture2D texture = TextureUtility.SplitTexture(renderingEngine, totalTexture, new Rectangle(animationNumber * width + animationNumber, 5 * height, width, height));
                animation.addToTexture2DList(texture);
            }
            return animation;
        }
    }

}
