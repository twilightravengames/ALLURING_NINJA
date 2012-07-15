using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlluringNinja.SceneGraph_Classes;
using Microsoft.Xna.Framework.Content;
using AlluringNinja.Map_Data_Classes;
using Microsoft.Xna.Framework.Graphics;
using GLEED2D;
using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics.SpriteBlendMode;



namespace AlluringNinja
{
    public class SceneGraph
    {
        public List<Enemy> enemyList = new List<Enemy>();
        public List<Player> playerList = new List<Player>();
        public List<BackgroundTile> backgroundTileList = new List<BackgroundTile>();
        public List<Level> levelList = new List<Level>();
        public Map map = null;

        public ContentManager contentManager;
        public RenderingEngine renderingEngine;
        public PositionUpdater positionUpdater;
        public CollisionHandler collisionHandler;
        public Camera camera = new Camera();

        public Texture2D yellowNinjaTotalTexture;
        public Texture2D redNinjaTotalTexture;




        public SceneGraph(Game1 game)
        {

            contentManager = new ContentManager(game.Services, "Content");
            contentManager.RootDirectory = "Content";
            renderingEngine = game.getRenderingEngine();
            positionUpdater = game.getPositionUpdater();
            loadMap("default");
            Level level = Level.FromFile("Levels\\sample.xml", contentManager);
            levelList.Add(level);

        }

        public void initializeCollisionHandler(CollisionHandler collisionHandler)
        {
            this.collisionHandler = collisionHandler;
        }

        public Boolean isInCollisions(Vector2 position, float width, float height)
        {
            Boolean collided = false;

            foreach (Level level in levelList)
            {
                foreach (Layer layer in level.Layers)
                {
                    if (layer.Name.Equals("collisions"))
                    {
                        //found the collision layer
                        foreach (Item item in layer.Items)
                        {
                            if (item.GetType().Name.Equals("RectangleItem"))
                            {
                                RectangleItem rectangleItem = (RectangleItem)item;
                                //iterating through each item in the collision layer
                                Vector2 collisionItemPosition = item.Position;
                                float collisionWidth = rectangleItem.Width;
                                float collisionHeight = rectangleItem.Height;
                                
                                Boolean tempCollided = isInCollisionBox(position, width, height, collisionItemPosition, collisionWidth, collisionHeight);
                                if (tempCollided)
                                {
                                    collided = true;
                                }
                            }
                        }
                    }
                }
            }
            if (collided)
            {
                //System.Console.WriteLine("Collision occured in level");
            }

            return collided;
        }

        public Boolean isCollidingWithFloor(Vector2 position, float width, float height)
        {
            Boolean collided = false;

            foreach (Level level in levelList)
            {
                foreach (Layer layer in level.Layers)
                {
                    if (layer.Name.Equals("collisions"))
                    {
                        //found the collision layer
                        foreach (Item item in layer.Items)
                        {
                            if (item.GetType().Name.Equals("RectangleItem"))
                            {
                                RectangleItem rectangleItem = (RectangleItem)item;
                                //iterating through each item in the collision layer
                                Vector2 collisionItemPosition = item.Position;
                                float collisionWidth = rectangleItem.Width;
                                float collisionHeight = rectangleItem.Height;

                                Boolean tempCollided = isCollidingWithFloorLayer(position, width, height, collisionItemPosition, collisionWidth, collisionHeight);
                                if (tempCollided)
                                {
                                    collided = true;
                                }
                            }
                        }
                    }
                }
            }
            if (collided)
            {
                //System.Console.WriteLine("Is colliding with floor");
            }

            return collided;
        }

        public Boolean isCollidingWithFloorLayer(Vector2 position, float width, float height, Vector2 collisionItemPosition, float collisionWidth, float collisionHeight)
        {
            Vector2 upperLeftCollision = new Vector2(collisionItemPosition.X, collisionItemPosition.Y);
            Vector2 upperRightCollision = new Vector2(collisionItemPosition.X + collisionWidth, collisionItemPosition.Y);
            Vector2 lowerLeftCollision = new Vector2(collisionItemPosition.X, collisionItemPosition.Y + collisionHeight);
            Vector2 lowerRightCollision = new Vector2(collisionItemPosition.X + collisionWidth, collisionItemPosition.Y + collisionHeight);

            Vector2 upperLeftObject = new Vector2(position.X, position.Y);
            Vector2 upperRightObject = new Vector2(position.X + width, position.Y);
            Vector2 lowerLeftObject = new Vector2(position.X, position.Y + height);
            Vector2 lowerRightObject = new Vector2(position.X + width, position.Y + height);

            Boolean collided = false;

            //check left-most border of collision



            //check against the top most border of collision block

            float distanceY = upperLeftCollision.Y - lowerLeftObject.Y;

            
            if (distanceY <= GameConstants.PLAYER_GROUND_SEPERATION_CNSTNT && distanceY >= 0)
            {
                if (lowerLeftObject.X >= upperLeftCollision.X && lowerRightObject.X <= upperRightCollision.X)
                {
                    //System.Console.WriteLine("Gravity Upper left collision: " + upperLeftCollision.Y);
                    //System.Console.WriteLine("Gravity Lower left object: " + lowerLeftObject.Y);

                    collided = true;
                }
                if (lowerRightObject.X >= upperLeftCollision.X && lowerLeftObject.X <= upperRightCollision.X)
                {
                    //System.Console.WriteLine("Gravity Upper left collision: " + upperLeftCollision.Y);
                    //System.Console.WriteLine("Gravity Lower left object: " + lowerLeftObject.Y);

                    collided = true;
                }
            }


            if (collided)
            {
                //System.Console.WriteLine("Collision occured");
            }

            return collided;
        }


        public Boolean isInCollisionBox(Vector2 position, float width, float height, Vector2 collisionItemPosition, float collisionWidth, float collisionHeight)
        {
            Vector2 upperLeftCollision = new Vector2(collisionItemPosition.X, collisionItemPosition.Y);
            Vector2 upperRightCollision = new Vector2(collisionItemPosition.X + collisionWidth, collisionItemPosition.Y);
            Vector2 lowerLeftCollision = new Vector2(collisionItemPosition.X, collisionItemPosition.Y + collisionHeight);
            Vector2 lowerRightCollision = new Vector2(collisionItemPosition.X + collisionWidth, collisionItemPosition.Y + collisionHeight);

            Vector2 upperLeftObject = new Vector2(position.X, position.Y);
            Vector2 upperRightObject = new Vector2(position.X + width, position.Y);
            Vector2 lowerLeftObject = new Vector2(position.X, position.Y + height);
            Vector2 lowerRightObject = new Vector2(position.X + width, position.Y + height);

            Boolean collided = false;

            //check left-most border of collision
            
                //check against left most border of collision block
            if (upperRightObject.Y >= upperLeftCollision.Y && lowerRightObject.Y <= lowerLeftCollision.Y)
            {
                if (upperRightObject.X >= upperLeftCollision.X && upperRightObject.X <= upperRightCollision.X)
                {
                    collided = true;
                }
            }

            //check against the right most border of collision block
            if (upperLeftObject.Y >= upperRightCollision.Y && lowerLeftObject.Y <= lowerLeftCollision.Y)
            {
                if (upperLeftObject.X <= upperRightCollision.X && upperRightObject.X >= upperLeftCollision.X)
                {
                    collided = true;
                }
            }

            //check against the top most border of collision block

            if (lowerLeftObject.Y >= upperLeftCollision.Y && upperLeftObject.Y <= lowerLeftCollision.Y)
            {

                
                if (lowerLeftObject.X >= upperLeftCollision.X && lowerRightObject.X <= upperRightCollision.X)
                {
                    collided = true;
                }
                if (lowerRightObject.X >= upperLeftCollision.X && lowerLeftObject.X <= upperRightCollision.X)
                {
                    //System.Console.WriteLine("UpperLeft Collision is " + upperLeftCollision);
                    //System.Console.WriteLine("UpperRight Collision is " + upperRightCollision);
                    //System.Console.WriteLine("LowerRight object is " + lowerRightObject);
                    //System.Console.WriteLine("LowerLeft object is" + lowerLeftObject);

                    collided = true;
                }
                

            }

            //check against the bottom most border of collision block

            if (upperLeftObject.Y <= lowerLeftCollision.Y && upperRightObject.Y >= upperRightCollision.Y)
            {
                if (upperLeftObject.X >= lowerLeftCollision.X && upperRightObject.X <= lowerRightCollision.X)
                {
                    collided = true;
                }

                //standing to the left
                if (upperRightObject.X >= lowerLeftCollision.X && upperLeftObject.X <= lowerRightCollision.X)
                {
                    collided = true;
                }
            }

            if (collided)
            {
                //System.Console.WriteLine("Collision occured");
            }

            return collided;
        }


        public void moveCamera(Vector2 movement)
        {
            Vector2 positionVector = camera.getPositionVector();
            positionVector.X += movement.X;
            positionVector.Y += movement.Y;
            camera.setPositionVector(positionVector);
        }

        public void moveCameraX(int movementX)
        {
            Vector2 positionVector = camera.getPositionVector();
            //System.Console.WriteLine("Movement amount is " + movementX);
            positionVector.X += movementX;

            //System.Console.WriteLine("Old camera position is " + camera.getPositionVector().X);
            camera.setPositionVector(positionVector);
            
            //System.Console.WriteLine("Move Camera X by " + movementX);
            //System.Console.WriteLine("New camera position is " + camera.getPositionVector().X);
        }

        public void moveCameraY(int movementY)
        {
            Vector2 positionVector = camera.getPositionVector();
            positionVector.Y += movementY;
            camera.setPositionVector(positionVector);
        }


        public ContentManager getContentManager()
        {
            return contentManager;
        }

        public void addBackgroundTile(BackgroundTile backgroundTile)
        {
            backgroundTileList.Add(backgroundTile);
        }

        public void addPlayer(Player player)
        {
            playerList.Add(player);
        }

        public void drawSceneGraph()
        {
            //call draw methods on objects in order of z index passing renderingEngine object
            foreach (BackgroundTile backgroundTile in backgroundTileList)
            {
                //backgroundTile.draw(renderingEngine);
            }

            
            foreach (Level level in levelList)
            {
                
                //level.draw(renderingEngine.spriteBatch);
                foreach (Layer layer in level.Layers)
                {
                    Camera tempCamera = new Camera();
                    Vector2 cameraPosition = camera.getPositionVector();
                    //System.Console.WriteLine("Current Camera Position in Draw() is " + cameraPosition);
                    Vector2 tempCameraPosition = cameraPosition * layer.ScrollSpeed;
                    //System.Console.WriteLine("Scroll speed is " + layer.ScrollSpeed);
                    tempCamera.setPositionVector(tempCameraPosition);
                    Matrix cameraMatrix = tempCamera.getPositionMatrix();
                    //renderingEngine.spriteBatch.Begin(SpriteBlendMode.AlphaBlend,
                    //SpriteSortMode.Deferred,
                    //SaveStateMode.None,
                    //cameraMatrix);

                    renderingEngine.spriteBatch.Begin();

                    layer.draw(renderingEngine.spriteBatch);
                    renderingEngine.spriteBatch.End();
                }

                
            }

            foreach (Player player in playerList)
            {
                player.draw(renderingEngine);
            }


        }

        public void updateAnimations()
        {
            foreach (Player player in playerList)
            {
                
                player.updateAnimation(renderingEngine);
           
            }
        }

        public void updatePhysics()
        {
            foreach (Player player in playerList)
            {
                //System.Console.WriteLine("Player position: " + player.objectPosition);
                collisionHandler.gravityHandler(player);
            }
        }
        public void loadMap(String fileName)
        {
            map = new Map();
            map.load(fileName, renderingEngine);
            MapToSceneGraphConverter.convert(map, this);

        }

        public Player getPlayer(String idString)
        {
            foreach (Player player in playerList)
            {
                if (player.idString.Equals(idString))
                {
                    return player;
                }
            }
            return null;
        }

        public Enemy getEnemy(String idString)
        {
            foreach (Enemy enemy in enemyList)
            {
                if (enemy.idString.Equals(idString))
                {
                    return enemy;
                }
            }
            return null;
        }
   

        public Character2D getGenericCharacter2D(String idString)
        {
            Player player = getPlayer(idString);

            if (player != null)
            {
                return player;
            }

            Enemy enemy = getEnemy(idString);

            if (enemy != null)
            {
                return enemy;
            }

            return null;

        }

    }
}
