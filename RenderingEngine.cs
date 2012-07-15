using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AlluringNinja.SceneGraph_Classes;

namespace AlluringNinja
{
    public class RenderingEngine
    {
        public RenderingEngine(Game1 game)
        {
            graphics = new GraphicsDeviceManager(game);
            this.game = game;
        }

        public void initialize()
        {
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);

            //gameWorldRotation =
            //Matrix.CreateRotationX(MathHelper.ToRadians(RotationX)) *
            //Matrix.CreateRotationY(MathHelper.ToRadians(RotationY));

            aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;

            projection =
                Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                aspectRatio, 1.0f, 10000.0f);

            view = Matrix.CreateLookAt(new Vector3(0.0f, 50.0f, Zoom),
                Vector3.Zero, Vector3.Up);

            worldMatrix = Matrix.CreateTranslation(cameraVector);

            graphics.ToggleFullScreen();
        }


        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public Game1 game;
        public Vector3 cameraVector = new Vector3(0.0f, 0.0f, 0.0f);
        public Vector3 Position = Vector3.One;
        public float Zoom = 50;

        public float RotationY = 0.0f;
        public float RotationX = 0.0f;


        public Matrix gameWorldRotation;
        public Matrix projection;
        public Matrix view;
        public Matrix worldMatrix;
        public float aspectRatio;

        public Vector2 grab2DCoordinates(Vector3 position)
        {
            Matrix tempWorldMatrix = Matrix.CreateTranslation(position) * Matrix.CreateTranslation(cameraVector);

            Vector3 result = graphics.GraphicsDevice.Viewport.Project(position, projection, view, tempWorldMatrix);

            Vector2 returnValueVector = new Vector2(result.X, result.Y);

            return returnValueVector;
        }

        public void Draw2DModel(Thing2D c)
        {

            spriteBatch.Begin();

            spriteBatch.Draw(c.objectTexture, c.objectPosition, Color.White);
            spriteBatch.End();


        }

        public void DrawScaled2DModel(Thing2D c)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(c.objectTexture, c.objectPosition, null, Color.White, 0f, Vector2.Zero,
                             c.scale, SpriteEffects.None, 0f);
            spriteBatch.End();
        }

        public void DrawScaled2DModel(Character2D a, Texture2D c)
        {
            //System.Console.WriteLine("Object Position coordinates X: " + a.objectPosition.X);
            //System.Console.WriteLine("Object Position coordinates Y: " + a.objectPosition.Y);
            spriteBatch.Begin();
            
            spriteBatch.Draw(c, correctPosition(a.objectPosition), null, Color.White, 0f, Vector2.Zero,
                             a.scale, SpriteEffects.None, 0f);
            spriteBatch.End();
        }

        public void DrawScaledHorizontallyFlipped2DModel(Character2D a, Texture2D c)
        {
            //System.Console.WriteLine("Object Position coordinates X: " + a.objectPosition.X);
           // System.Console.WriteLine("Object Position coordinates Y: " + a.objectPosition.Y);
            spriteBatch.Begin();

            spriteBatch.Draw(c, correctPosition(a.objectPosition), null, Color.White, 0f, Vector2.Zero,
                             a.scale, SpriteEffects.FlipHorizontally, 0f);
            spriteBatch.End();
        }

        public void DrawScaled2DModel(Player a, Texture2D c)
        {
            //System.Console.WriteLine("Object Position coordinates X: " + a.objectPosition.X);
            //System.Console.WriteLine("Object Position coordinates Y: " + a.objectPosition.Y);
            spriteBatch.Begin();

            spriteBatch.Draw(c, correctPosition(new Vector2(a.objectPosition.X + game.getSceneGraph().camera.getPositionVector().X,a.objectPosition.Y)), null, Color.White, 0f, Vector2.Zero,
                             a.scale, SpriteEffects.None, 0f);
            spriteBatch.End();
        }

        public void DrawScaledHorizontallyFlipped2DModel(Player a, Texture2D c)
        {
            //System.Console.WriteLine("Object Position coordinates X: " + a.objectPosition.X);
            // System.Console.WriteLine("Object Position coordinates Y: " + a.objectPosition.Y);
            spriteBatch.Begin();

            spriteBatch.Draw(c, correctPosition(new Vector2(a.objectPosition.X + game.getSceneGraph().camera.getPositionVector().X, a.objectPosition.Y)), null, Color.White, 0f, Vector2.Zero,
                             a.scale, SpriteEffects.FlipHorizontally, 0f);
            spriteBatch.End();
        }



        public Vector2 correctPosition(Vector2 vector)
        {
            Vector2 returnVector = new Vector2();
            returnVector.X = (float)Math.Floor(vector.X);
            returnVector.Y = (float)Math.Floor(vector.Y);

            return returnVector;

        }

        public Vector3 transformWorldToScreenCoordinates(Vector3 source)
        {
            Vector3 transformedVector = graphics.GraphicsDevice.Viewport.Project(source, projection, view, worldMatrix);
            return transformedVector;
        }

        public Vector3 transformScreenToWorldCoordinates(Vector3 source)
        {
            Vector3 transformedVector = graphics.GraphicsDevice.Viewport.Unproject(source, projection, view, worldMatrix);
            return transformedVector;
        }

        public int getViewportUpperX()
        {
            return graphics.GraphicsDevice.Viewport.X;
        }

        public int getViewportUpperY()
        {
            return graphics.GraphicsDevice.Viewport.Y;
        }

        public int getViewportHeight()
        {
            return graphics.GraphicsDevice.Viewport.Height;
        }

        public int getViewportWidth()
        {
            return graphics.GraphicsDevice.Viewport.Width;
        }

    }
}
