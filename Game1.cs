using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace AlluringNinja
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        RenderingEngine renderingEngine;
        SceneGraph sceneGraph;
        PositionUpdater positionUpdater;
        KeyHandler keyHandler;
        CollisionHandler collisionHandler;

        public Game1()
        {
            renderingEngine = new RenderingEngine(this);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            renderingEngine.initialize();
            positionUpdater = new PositionUpdater(this); //must be created before scenegraph
            sceneGraph = new SceneGraph(this);
            collisionHandler = new CollisionHandler(sceneGraph);
            sceneGraph.initializeCollisionHandler(collisionHandler);
            keyHandler = new KeyHandler(this);
            
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            keyHandler.update();
            
            positionUpdater.update();
            UpdateScrolling();

            

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here


            sceneGraph.updateAnimations();
            sceneGraph.updatePhysics();

            base.Update(gameTime);
        }

        protected void UpdateScrolling()
        {
            //scrollFactor += SCROLL_FACTOR;
            //renderingEngine.cameraVector.X = scrollFactor;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            //Draw2DModel(person);

            sceneGraph.drawSceneGraph();

            base.Draw(gameTime);

        }

        public PositionUpdater getPositionUpdater()
        {
            return positionUpdater;
        }

        public SceneGraph getSceneGraph()
        {
            return sceneGraph;
        }

        public RenderingEngine getRenderingEngine()
        {
            return renderingEngine;
        }
        public CollisionHandler getCollisionHandler()
        {
            return collisionHandler;
        }
    }
}
