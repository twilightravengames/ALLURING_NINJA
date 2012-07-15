using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace AlluringNinja
{
    public class KeyHandler
    {
        Game1 game;

        public KeyHandler(Game1 game)
        {
            this.game = game;
        }

        public void update()
        {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Escape))
            {
                game.Exit();
            }

            else if (keyState.IsKeyDown(Keys.Left) && keyState.IsKeyDown(Keys.A))
            {
                attackHandler();
                //sceneGraph.ulf.Position.X -= 1.0f;
            }

            else if (keyState.IsKeyDown(Keys.Left) && keyState.IsKeyDown(Keys.Up))
            {
                upAndLeftHandler();
            }

            else if (keyState.IsKeyDown(Keys.Left))
            {
                handleLeftArrowPressed();
                //sceneGraph.ulf.Position.X -= 1.0f;
            }

            else if (keyState.IsKeyDown(Keys.Right) && keyState.IsKeyDown(Keys.A))
            {
                attackHandler();
                //sceneGraph.ulf.Position.X -= 1.0f;
            }

            else if (keyState.IsKeyDown(Keys.Right) && keyState.IsKeyDown(Keys.Up))
            {
                upAndRightHandler();
                //sceneGraph.ulf.Position.X -= 1.0f;
            }



            else if (keyState.IsKeyDown(Keys.Right))
            {
                handleRightArrowPressed();
                //sceneGraph.ulf.Position.X += 1.0f;
            }



            else if (keyState.IsKeyDown(Keys.Up))
            {
                jumpHandler();
                //Zoom -= 1.0f;
                //sceneGraph.ulf.Position.Y += 1.0f;
            }

            else if (keyState.IsKeyDown(Keys.Down))
            {
                //Zoom += 1.0f;
                //sceneGraph.ulf.Position.Y -= 1.0f;
            }

            else if (keyState.IsKeyDown(Keys.C))
            {
                changeClothesHandler();
            }

            else if (keyState.IsKeyDown(Keys.D))
            {
                deathHandler();
            }

            else if (keyState.IsKeyDown(Keys.A))
            {
                attackHandler();
            }

            else
            {
                //no input
                handleNoInput();
            }
        

            //MouseState current_mouse = Mouse.GetState();

            // The mouse x and y positions are returned relative to the
            // upper-left corner of the game window.
            //int mouseX = current_mouse.X;
            //int mouseY = current_mouse.Y;
            //int mouseXDiff = 0;
            //int mouseYDiff = 0;

        }

        private void handleRightArrowPressed()
        {
                //Console.WriteLine("Detected right arrow pressed, passing on message PLAYER_MOVEMENT_RIGHT_MSG");

                game.getSceneGraph().getPlayer(GameConstants.PLAYER_OBJECT_ID).changeStatus(GameConstants.PLAYER_MOVEMENT_RIGHT_MSG);
        
        }

        private void handleLeftArrowPressed()
        {
            //Console.WriteLine("Detected left arrow pressed, passing on message PLAYER_MOVEMENT_LEFT_MSG");
                game.getSceneGraph().getPlayer(GameConstants.PLAYER_OBJECT_ID).changeStatus(GameConstants.PLAYER_MOVEMENT_LEFT_MSG);
        
        }

        private void handleNoInput()
        {
            game.getSceneGraph().getPlayer(GameConstants.PLAYER_OBJECT_ID).changeStatus(GameConstants.PLAYER_NO_MOVEMENT_MSG);
        }

        private void changeClothesHandler()
        {
            game.getSceneGraph().getPlayer(GameConstants.PLAYER_OBJECT_ID).changeStatus(GameConstants.PLAYER_CHANGE_CLOTHES_MSG);
        }

        private void deathHandler()
        {
            //System.Console.WriteLine("Running Death Handler");
            game.getSceneGraph().getPlayer(GameConstants.PLAYER_OBJECT_ID).changeStatus(GameConstants.PLAYER_DEATH_MSG);
        }

        private void jumpHandler()
        {
            game.getSceneGraph().getPlayer(GameConstants.PLAYER_OBJECT_ID).changeStatus(GameConstants.PLAYER_INITIAL_JUMP_MSG);
        }

        private void attackHandler()
        {
            game.getSceneGraph().getPlayer(GameConstants.PLAYER_OBJECT_ID).changeStatus(GameConstants.PLAYER_ATTACK_MSG);
        }

        private void upAndLeftHandler()
        {
            game.getSceneGraph().getPlayer(GameConstants.PLAYER_OBJECT_ID).changeStatus(GameConstants.PLAYER_INITIAL_JUMP_MOVING_LEFT_MSG);
        }

        private void upAndRightHandler()
        {
            game.getSceneGraph().getPlayer(GameConstants.PLAYER_OBJECT_ID).changeStatus(GameConstants.PLAYER_INITIAL_JUMP_MOVING_RIGHT_MSG);
        }
    }
}
