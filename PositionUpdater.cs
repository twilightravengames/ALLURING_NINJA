using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlluringNinja.SceneGraph_Classes;
using AlluringNinja.Message_Data_Types;
using Microsoft.Xna.Framework;
using System.Collections.Specialized;
using System.Collections;
namespace AlluringNinja
{
    public class PositionUpdater
    {
        Game1 game;
        SortedList movementList = new SortedList();

        public SortedList getMovementList()
        {
            return movementList;
        }

        public MovementMessage getMessageFromListByKey(String key)
        {
            foreach (MovementMessage message in movementList.Values)
            {
                if (message.objectId.Equals(key))
                {
                    return message;
                }

            }
            return null;
        }

        public PositionUpdater(Game1 game)
        {
            this.game = game;
            
        }

        public void registerMovement(String idString, String movementType)
        {
            //System.Console.WriteLine("Register movement type: " + movementType);
            if (movementType.Equals(GameConstants.PLAYER_MOVEMENT_RIGHT_MSG))
            {

                

                Player player = game.getSceneGraph().getPlayer(idString);
                
        
                MovementMessage message = new MovementMessage();
                Vector2 destinationPosition = new Vector2();
                destinationPosition.X = player.objectPosition.X + GameConstants.PLAYER_AMOUNT_MOVED_PER_KEYPRESS;
                destinationPosition.Y = player.objectPosition.Y;

                message.objectId = GameConstants.PLAYER_OBJECT_ID;
                message.messageTypeId = movementType;
                message.destinationPosition = destinationPosition;
                
                message.rateOfMovement = GameConstants.PLAYER_RATE_OF_MOVEMENT;

                if (!movementList.Contains(message.objectId))
                {
                    //System.Console.WriteLine("Adding message to movement list");
                    movementList.Add(message.objectId, message);
                }
         
                
            }

            else if (movementType.Equals(GameConstants.PLAYER_MOVEMENT_LEFT_MSG))
            {

                Player player = game.getSceneGraph().getPlayer(idString);


                MovementMessage message = new MovementMessage();
                Vector2 destinationPosition = new Vector2();
                destinationPosition.X = player.objectPosition.X - GameConstants.PLAYER_AMOUNT_MOVED_PER_KEYPRESS;
                destinationPosition.Y = player.objectPosition.Y;

                message.objectId = GameConstants.PLAYER_OBJECT_ID;
                message.messageTypeId = movementType;
                message.destinationPosition = destinationPosition;

                message.rateOfMovement = GameConstants.PLAYER_RATE_OF_MOVEMENT;

                if (!movementList.Contains(message.objectId))
                {
                    //System.Console.WriteLine("Adding message to movement list");
                    movementList.Add(message.objectId, message);
                }


            }

            else if (movementType.Equals(GameConstants.PLAYER_CHANGE_CLOTHES_MSG))
            {

                Player player = game.getSceneGraph().getPlayer(idString);


                MovementMessage message = new MovementMessage();
                Vector2 destinationPosition = new Vector2();
                destinationPosition.X = player.objectPosition.X;
                destinationPosition.Y = player.objectPosition.Y;

                message.objectId = GameConstants.PLAYER_OBJECT_ID;
                message.messageTypeId = movementType;
                message.destinationPosition = destinationPosition;

                message.rateOfMovement = GameConstants.PLAYER_RATE_OF_MOVEMENT;

                if (!movementList.Contains(message.objectId))
                {
                    //System.Console.WriteLine("Adding message to movement list");
                    movementList.Add(message.objectId, message);
                }


            }

            else if (movementType.Equals(GameConstants.PLAYER_INITIAL_JUMP_MSG))
            {

                Player player = game.getSceneGraph().getPlayer(idString);


                MovementMessage message = new MovementMessage();
                Vector2 destinationPosition = new Vector2();
                destinationPosition.X = player.objectPosition.X;
                destinationPosition.Y = player.objectPosition.Y - GameConstants.PLAYER_JUMP_HEIGHT;

                message.objectId = GameConstants.PLAYER_OBJECT_ID;
                message.messageTypeId = movementType;
                message.destinationPosition = destinationPosition;

                message.rateOfMovement = GameConstants.PLAYER_RATE_OF_JUMP;

                MovementMessage oldMessage = (MovementMessage)getMessageFromListByKey(GameConstants.PLAYER_OBJECT_ID);
                //if was walking and switching to jump...
                if (movementList.Contains(message.objectId))
                {
                    if (oldMessage != null && 
                        (oldMessage.messageTypeId.Equals(GameConstants.PLAYER_MOVEMENT_RIGHT_MSG) 
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_MOVEMENT_LEFT_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_INITIAL_JUMP_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_CYCLE_JUMP_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_FALL_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_INITIAL_JUMP_MOVING_LEFT_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_INITIAL_JUMP_MOVING_RIGHT_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_FALL_MOVING_LEFT_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_FALL_MOVING_RIGHT_MSG)))
                    {
                        movementList.Remove(oldMessage.objectId);
                    }
                }

                if (!movementList.Contains(message.objectId))
                {
                    //System.Console.WriteLine("Adding message: " + message.messageTypeId + " to movement list");
                    movementList.Add(message.objectId, message);
                }


            }


            else if (movementType.Equals(GameConstants.PLAYER_INITIAL_JUMP_MOVING_RIGHT_MSG))
            {

                Player player = game.getSceneGraph().getPlayer(idString);


                MovementMessage message = new MovementMessage();
                Vector2 destinationPosition = new Vector2();
                destinationPosition.X = player.objectPosition.X + GameConstants.PLAYER_MAGNIFIED_RATE_OF_MOVEMENT;
                destinationPosition.Y = player.objectPosition.Y - GameConstants.PLAYER_JUMP_HEIGHT;

                message.objectId = GameConstants.PLAYER_OBJECT_ID;
                message.messageTypeId = movementType;
                message.destinationPosition = destinationPosition;

                message.rateOfMovement = GameConstants.PLAYER_RATE_OF_JUMP;

                MovementMessage oldMessage = (MovementMessage)getMessageFromListByKey(GameConstants.PLAYER_OBJECT_ID);
                //if was walking and switching to jump...
                if (movementList.Contains(message.objectId))
                {
                    if (oldMessage != null &&
                        (oldMessage.messageTypeId.Equals(GameConstants.PLAYER_MOVEMENT_RIGHT_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_MOVEMENT_LEFT_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_INITIAL_JUMP_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_CYCLE_JUMP_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_FALL_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_INITIAL_JUMP_MOVING_LEFT_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_INITIAL_JUMP_MOVING_RIGHT_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_FALL_MOVING_LEFT_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_FALL_MOVING_RIGHT_MSG)))
                    {
                        movementList.Remove(oldMessage.objectId);
                    }
                }

                if (!movementList.Contains(message.objectId))
                {
                    //System.Console.WriteLine("Adding message: " + message.messageTypeId + " to movement list");
                    movementList.Add(message.objectId, message);
                }


            }

            else if (movementType.Equals(GameConstants.PLAYER_INITIAL_JUMP_MOVING_LEFT_MSG))
            {

                Player player = game.getSceneGraph().getPlayer(idString);


                MovementMessage message = new MovementMessage();
                Vector2 destinationPosition = new Vector2();
                destinationPosition.X = player.objectPosition.X - GameConstants.PLAYER_MAGNIFIED_RATE_OF_MOVEMENT;
                destinationPosition.Y = player.objectPosition.Y - GameConstants.PLAYER_JUMP_HEIGHT;

                message.objectId = GameConstants.PLAYER_OBJECT_ID;
                message.messageTypeId = movementType;
                message.destinationPosition = destinationPosition;

                message.rateOfMovement = GameConstants.PLAYER_RATE_OF_JUMP;

                MovementMessage oldMessage = (MovementMessage)getMessageFromListByKey(GameConstants.PLAYER_OBJECT_ID);
                //if was walking and switching to jump...
                if (movementList.Contains(message.objectId))
                {
                    if (oldMessage != null &&
                        (oldMessage.messageTypeId.Equals(GameConstants.PLAYER_MOVEMENT_RIGHT_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_MOVEMENT_LEFT_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_INITIAL_JUMP_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_CYCLE_JUMP_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_FALL_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_INITIAL_JUMP_MOVING_LEFT_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_INITIAL_JUMP_MOVING_RIGHT_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_FALL_MOVING_LEFT_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_FALL_MOVING_RIGHT_MSG)))
                    {
                        movementList.Remove(oldMessage.objectId);
                    }
                }

                if (!movementList.Contains(message.objectId))
                {
                    //System.Console.WriteLine("Adding message: " + message.messageTypeId + " to movement list");
                    movementList.Add(message.objectId, message);
                }


            }

            else if (movementType.Equals(GameConstants.PLAYER_FALL_MSG))
            {

                Player player = game.getSceneGraph().getPlayer(idString);


                MovementMessage message = new MovementMessage();
                Vector2 destinationPosition = new Vector2();
                destinationPosition.X = player.objectPosition.X;
                destinationPosition.Y = player.objectPosition.Y + GameConstants.PLAYER_FALL_DISTANCE;

                message.objectId = GameConstants.PLAYER_OBJECT_ID;
                message.messageTypeId = movementType;
                message.destinationPosition = destinationPosition;

                message.rateOfMovement = GameConstants.PLAYER_RATE_OF_JUMP;
                

                if (!movementList.Contains(message.objectId))
                {
                    //System.Console.WriteLine("Adding message to movement list");
                    movementList.Add(message.objectId, message);
                }


            }

            else if (movementType.Equals(GameConstants.PLAYER_FALL_MOVING_LEFT_MSG))
            {

                Player player = game.getSceneGraph().getPlayer(idString);


                MovementMessage message = new MovementMessage();
                Vector2 destinationPosition = new Vector2();
                destinationPosition.X = player.objectPosition.X - GameConstants.PLAYER_MAGNIFIED_RATE_OF_MOVEMENT;
                destinationPosition.Y = player.objectPosition.Y + GameConstants.PLAYER_FALL_DISTANCE;

                message.objectId = GameConstants.PLAYER_OBJECT_ID;
                message.messageTypeId = movementType;
                message.destinationPosition = destinationPosition;

                message.rateOfMovement = GameConstants.PLAYER_RATE_OF_JUMP;


                if (!movementList.Contains(message.objectId))
                {
                    //System.Console.WriteLine("Adding message to movement list");
                    movementList.Add(message.objectId, message);
                }


            }

            else if (movementType.Equals(GameConstants.PLAYER_FALL_MOVING_RIGHT_MSG))
            {

                Player player = game.getSceneGraph().getPlayer(idString);


                MovementMessage message = new MovementMessage();
                Vector2 destinationPosition = new Vector2();
                destinationPosition.X = player.objectPosition.X + GameConstants.PLAYER_MAGNIFIED_RATE_OF_MOVEMENT;
                destinationPosition.Y = player.objectPosition.Y + GameConstants.PLAYER_FALL_DISTANCE;

                message.objectId = GameConstants.PLAYER_OBJECT_ID;
                message.messageTypeId = movementType;
                message.destinationPosition = destinationPosition;

                message.rateOfMovement = GameConstants.PLAYER_RATE_OF_JUMP;


                if (!movementList.Contains(message.objectId))
                {
                    //System.Console.WriteLine("Adding message to movement list");
                    movementList.Add(message.objectId, message);
                }


            }




            else if (movementType.Equals(GameConstants.PLAYER_ATTACK_MSG))
            {

                Player player = game.getSceneGraph().getPlayer(idString);


                MovementMessage message = new MovementMessage();
                Vector2 destinationPosition = new Vector2();
                destinationPosition.X = player.objectPosition.X;
                destinationPosition.Y = player.objectPosition.Y;

                message.objectId = GameConstants.PLAYER_OBJECT_ID;
                message.messageTypeId = movementType;
                message.destinationPosition = destinationPosition;

                message.rateOfMovement = GameConstants.PLAYER_RATE_OF_MOVEMENT;

                MovementMessage oldMessage = (MovementMessage)getMessageFromListByKey(GameConstants.PLAYER_OBJECT_ID);
                //if was walking and switching to jump...
                if (movementList.Contains(message.objectId))
                {
                    if (oldMessage != null &&
                        (oldMessage.messageTypeId.Equals(GameConstants.PLAYER_MOVEMENT_RIGHT_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_MOVEMENT_LEFT_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_INITIAL_JUMP_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_CYCLE_JUMP_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_FALL_MSG)))
                    {
                        movementList.Remove(oldMessage.objectId);
                    }
                }

                if (!movementList.Contains(message.objectId))
                {
                    //System.Console.WriteLine("Adding message: " + message.messageTypeId + " to movement list");
                    movementList.Add(message.objectId, message);
                }


            }

            //handle jump modifiers


            else if (movementType.Equals(GameConstants.PLAYER_INITIAL_JUMP_MOVING_LEFT_MODIFIER)
                    || movementType.Equals(GameConstants.PLAYER_INITIAL_JUMP_MOVING_RIGHT_MODIFIER)
                    || movementType.Equals(GameConstants.PLAYER_CYCLE_JUMP_MOVING_LEFT_MODIFIER)
                    || movementType.Equals(GameConstants.PLAYER_CYCLE_JUMP_MOVING_RIGHT_MODIFIER)
                    || movementType.Equals(GameConstants.PLAYER_FALL_MOVING_LEFT_MODIFIER)
                    || movementType.Equals(GameConstants.PLAYER_FALL_MOVING_RIGHT_MODIFIER))
            {

                Player player = game.getSceneGraph().getPlayer(idString);


                MovementMessage message = new MovementMessage();
                Vector2 destinationPosition = new Vector2();

                message.objectId = GameConstants.PLAYER_OBJECT_ID;

                if (movementList.Contains(message.objectId))
                {
                    MovementMessage containedMessage = getMessageFromListByKey(message.objectId);
                    destinationPosition.Y = containedMessage.destinationPosition.Y;
                    if (movementType.Equals(GameConstants.PLAYER_INITIAL_JUMP_MOVING_LEFT_MODIFIER)
                        || movementType.Equals(GameConstants.PLAYER_CYCLE_JUMP_MOVING_LEFT_MODIFIER)
                        || movementType.Equals(GameConstants.PLAYER_FALL_MOVING_LEFT_MODIFIER))
                    {
                        destinationPosition.X = player.objectPosition.X - GameConstants.PLAYER_MAGNIFIED_RATE_OF_MOVEMENT;
                    }
                    else if (movementType.Equals(GameConstants.PLAYER_INITIAL_JUMP_MOVING_RIGHT_MODIFIER)
                        || movementType.Equals(GameConstants.PLAYER_CYCLE_JUMP_MOVING_RIGHT_MODIFIER)
                        || movementType.Equals(GameConstants.PLAYER_FALL_MOVING_RIGHT_MODIFIER))
                    {
                        destinationPosition.X = player.objectPosition.X + GameConstants.PLAYER_MAGNIFIED_RATE_OF_MOVEMENT;
                    }

                    message.messageTypeId = containedMessage.messageTypeId;
                }

                else
                {
                    if (movementType.Equals(GameConstants.PLAYER_INITIAL_JUMP_MOVING_LEFT_MODIFIER)
                        || movementType.Equals(GameConstants.PLAYER_CYCLE_JUMP_MOVING_LEFT_MODIFIER)
                        || movementType.Equals(GameConstants.PLAYER_FALL_MOVING_LEFT_MODIFIER))
                    {
                        destinationPosition.X = player.objectPosition.X - GameConstants.PLAYER_MAGNIFIED_RATE_OF_MOVEMENT;                    }

                    else if (movementType.Equals(GameConstants.PLAYER_INITIAL_JUMP_MOVING_RIGHT_MODIFIER)
                        || movementType.Equals(GameConstants.PLAYER_CYCLE_JUMP_MOVING_RIGHT_MODIFIER)
                        || movementType.Equals(GameConstants.PLAYER_FALL_MOVING_RIGHT_MODIFIER))
                    {
                        destinationPosition.X = player.objectPosition.X + GameConstants.PLAYER_MAGNIFIED_RATE_OF_MOVEMENT;
                    }

                    destinationPosition.Y = player.objectPosition.Y - GameConstants.PLAYER_JUMP_HEIGHT;
                    message.messageTypeId = movementType;
                }

                
                
                message.destinationPosition = destinationPosition;

                message.rateOfMovement = GameConstants.PLAYER_RATE_OF_JUMP;

                MovementMessage oldMessage = (MovementMessage)getMessageFromListByKey(GameConstants.PLAYER_OBJECT_ID);
                //if was walking and switching to jump...
                if (movementList.Contains(message.objectId))
                {
                    if (oldMessage != null &&
                        (oldMessage.messageTypeId.Equals(GameConstants.PLAYER_MOVEMENT_RIGHT_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_MOVEMENT_LEFT_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_INITIAL_JUMP_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_CYCLE_JUMP_MSG)
                        || oldMessage.messageTypeId.Equals(GameConstants.PLAYER_FALL_MSG)))
                    {
                        
                        movementList.Remove(oldMessage.objectId);
                    }
                }

                if (!movementList.Contains(message.objectId))
                {
                    //System.Console.WriteLine("Adding message: " + message.messageTypeId + " to movement list");
                    movementList.Add(message.objectId, message);
                }



            }

        }

        public void update()
        {   
            updateCharacterMovement();

            cleanUpMovementList();

        }


        public void updateCharacterMovement()
        {
            //System.Console.WriteLine("Running  updateCharacterMovement()");
            foreach (MovementMessage message in movementList.Values)
            {
                
                //System.Console.WriteLine("Executing message movement check TIME IS:" +  UtilityTimer.getTime());
                //System.Console.WriteLine("Executing movement message requirements - ");
                
                int timeElapsed = UtilityTimer.getTime() - message.lastMovementTime;
                message.lastMovementTime = UtilityTimer.getTime();

                //System.Console.WriteLine("Movement Time Elapsed: " + timeElapsed);
                Character2D character = game.getSceneGraph().getGenericCharacter2D(message.objectId);

                //System.Console.WriteLine("Current message type id: " + message.messageTypeId);

                Vector2 amountOfMovement = new Vector2(0, 0);

                Vector2 distance = new Vector2(0,0);
                distance.X = message.destinationPosition.X - character.objectPosition.X;
                distance.Y = message.destinationPosition.Y - character.objectPosition.Y;

                //System.Console.WriteLine("Message type " + message.messageTypeId);
                //System.Console.WriteLine("Distance X " + distance.X);
                //System.Console.WriteLine("Distance Y " + distance.Y);

                if (timeElapsed > 0)
                {

                    float movementFactorX = ( (float)timeElapsed * message.rateOfMovement);
                    float movementFactorY = ( (float)timeElapsed * message.rateOfMovement);

                    //System.Console.WriteLine("Movement factor Y is: " + movementFactorY);

                    if (distance.X != 0)
                    {
                        amountOfMovement.X = (int)(movementFactorX / (float)distance.X);
                    }
                    
                    else
                    {
                        amountOfMovement.X = 0;
                    }

                    if (distance.Y != 0)
                    {
                        amountOfMovement.Y = (int)(movementFactorY / (float)distance.Y);
                    }
                    else
                    {
                        amountOfMovement.Y = 0;
                    }
                }
                //System.Console.WriteLine("Distance to cover" + (float)distance.X);
                //System.Console.WriteLine("Time elapsed: " + (float)timeElapsed);
                //System.Console.WriteLine("Rate of Movement" + message.rateOfMovement);
                //System.Console.WriteLine("Movement factor" + ((float)timeElapsed * message.rateOfMovement));
                //System.Console.WriteLine("Amount of Movement" + amountOfMovement.Y);
                
                
                Vector2 tempDestinationVariable = new Vector2();
                


                tempDestinationVariable.X = amountOfMovement.X + character.objectPosition.X;
                tempDestinationVariable.Y = amountOfMovement.Y + character.objectPosition.Y;

                Vector2 tempMaxDifference = new Vector2();

                tempMaxDifference.X = message.destinationPosition.X - character.objectPosition.X;
                tempMaxDifference.Y = message.destinationPosition.Y - character.objectPosition.Y;


                //System.Console.WriteLine("TempDestinationX" + tempDestinationVariable.X);



                bool completeX = false;
                bool completeY = false;

                if (character.objectPosition.X < message.destinationPosition.X)
                {
                    if (tempDestinationVariable.X < message.destinationPosition.X)
                    {
                        if (!game.getSceneGraph().isInCollisions(tempDestinationVariable, character.width, character.height))
                        {

                            character.objectPosition.X = tempDestinationVariable.X;
                            game.getSceneGraph().moveCameraX(-(int)amountOfMovement.X);
                        }
                        else
                        {
                            completeX = true;
                        }

                                                           
                        //System.Console.WriteLine("Updating character x coordinate");
                    }

                    else if (tempDestinationVariable.X >= message.destinationPosition.X)
                    {
                        //System.Console.WriteLine("Max movement X Coordinate: " + character.objectPosition.X);
                        //System.Console.WriteLine("Destination Position X: " + message.destinationPosition.X);
                        if (!game.getSceneGraph().isInCollisions(message.destinationPosition, character.width, character.height))
                        {
                            character.objectPosition.X = message.destinationPosition.X;
                            game.getSceneGraph().moveCameraX(-(int)tempMaxDifference.X);
                            completeX = true;
                        }
                        else
                        {
                            completeX = true;
                        }
                        //System.Console.WriteLine("Terminated X");
                    }
                }
                else if (character.objectPosition.X > message.destinationPosition.X)
                {
                    if (tempDestinationVariable.X > message.destinationPosition.X)
                    {
                        if (!game.getSceneGraph().isInCollisions(tempDestinationVariable, character.width, character.height))
                        {
                            character.objectPosition.X = tempDestinationVariable.X;
                            game.getSceneGraph().moveCameraX(-(int)amountOfMovement.X);
                        }
                        else
                        {
                            Console.WriteLine("Collided with X");
                            completeX = true;
                        }
                        //System.Console.WriteLine("Updating character x coordinate");
                    }

                    else if (tempDestinationVariable.X <= message.destinationPosition.X)
                    {
                        //System.Console.WriteLine("Max movement X Coordinate: " + character.objectPosition.X);
                        //System.Console.WriteLine("Destination Position X: " + message.destinationPosition.X);
                        if (!game.getSceneGraph().isInCollisions(message.destinationPosition, character.width, character.height))
                        {
                            character.objectPosition.X = message.destinationPosition.X;
                            game.getSceneGraph().moveCameraX(-(int)tempMaxDifference.X);

                            completeX = true;
                        }
                        else
                        {
                            Console.WriteLine("Collided with X");
                            completeX = true;
                        }
                        //System.Console.WriteLine("Terminated X"); 
                    }
                }
                else if (character.objectPosition.X == message.destinationPosition.X)
                {
                    //System.Console.WriteLine("Terminated X"); 
                    completeX = true;
                }


                if (character.objectPosition.Y < message.destinationPosition.Y)
                {
                    if (tempDestinationVariable.Y < message.destinationPosition.Y)
                    {
                        //System.Console.WriteLine("Updating character y coordinate");

                        //game.getSceneGraph().moveCameraY(-(int)amountOfMovement.Y); 
                        if (!game.getSceneGraph().isInCollisions(tempDestinationVariable, character.width, character.height))
                        {
                            character.objectPosition.Y = tempDestinationVariable.Y;
                        }
                        else
                        {
                            Console.WriteLine("Collided with Y case 1");
                            Console.WriteLine("Temp Destination Variable Y" + tempDestinationVariable.Y);
                            completeY = true;
                        }

                    }

                    else if (tempDestinationVariable.Y >= message.destinationPosition.Y)
                    {
                        //System.Console.WriteLine("Finishing Updating character x coordinate");
                        //System.Console.WriteLine("Max movement Y Coordinate: " + character.objectPosition.Y);
                        //System.Console.WriteLine("Destination Position Y: " + message.destinationPosition.Y);

                        if (!game.getSceneGraph().isInCollisions(tempDestinationVariable, character.width, character.height))
                        {
                            character.objectPosition.Y = message.destinationPosition.Y;
                            //game.getSceneGraph().moveCameraY(-(int)tempMaxDifference.Y);
                            completeY = true;
                        }
                        else
                        {
                            Console.WriteLine("Collided with Y case 2");
                            completeY = true;
                        }
                        //System.Console.WriteLine("Terminated Y"); 
                    }
                }
                else if (character.objectPosition.Y > message.destinationPosition.Y)
                {
                    if (tempDestinationVariable.Y > message.destinationPosition.Y)
                    {
                        //System.Console.WriteLine("Setting Y to tempDestinationVariable");
                        //System.Console.WriteLine("Updating character y coordinate");
                        //game.getSceneGraph().moveCameraY(-(int)amountOfMovement.Y); 
                        if (!game.getSceneGraph().isInCollisions(tempDestinationVariable, character.width, character.height))
                        {
                            //System.Console.WriteLine("Found no collisions. tempDestinationVariable value is " + tempDestinationVariable);
                            character.objectPosition.Y = tempDestinationVariable.Y;
                        }
                        else
                        {
                            Console.WriteLine("Collided with Y case 3");
                            completeY = true;
                        }
                    }

                    else if (tempDestinationVariable.Y <= message.destinationPosition.Y)
                    {
                        //System.Console.WriteLine("Finishing Updating character x coordinate");
                        //System.Console.WriteLine("Max movement Y Coordinate: " + character.objectPosition.Y);
                        //System.Console.WriteLine("Destination Position Y: " + message.destinationPosition.Y);
                        //System.Console.WriteLine("Setting Y to destinationPosition Y");
                        if (!game.getSceneGraph().isInCollisions(message.destinationPosition, character.width, character.height))
                        {
                            //System.Console.WriteLine("Found no collisions.");
                            character.objectPosition.Y = message.destinationPosition.Y;
                            //game.getSceneGraph().moveCameraY(-(int)tempMaxDifference.Y);
                            completeY = true;
                        }
                        else
                        {
                            Console.WriteLine("Collided with Y case 4");
                            completeY = true;
                        }
                        //System.Console.WriteLine("Terminated Y"); 
                    }
                }
                else if (character.objectPosition.Y == message.destinationPosition.Y)
                {
                    completeY = true;
                    //System.Console.WriteLine("Terminated Y"); 
                }

                if (completeX && completeY)
                {
                    //System.Console.WriteLine("Message Terminated: + " + message.messageTypeId);
                    
                    message.messageTerminated = true;
                }
                
                
            }
            
            
        }

        

        public void cleanUpMovementList()
        {
            //System.Console.WriteLine("Cleaning up movement list");
            int listCount = movementList.Values.Count;
            
            for (int i = 0; i < listCount; i++)
            {
                //System.Console.WriteLine("Iterating through movementlist");
                if (((MovementMessage)movementList.GetByIndex(i)).messageTerminated == true)
                {
                    MovementMessage message = ((MovementMessage)movementList.GetByIndex(i));
                    String messageTypeId = message.messageTypeId;
                    Character2D character = game.getSceneGraph().getGenericCharacter2D(message.objectId);
                    
                    ////System.Console.WriteLine("Removing terminated message: " + message.messageTypeId);
                    movementList.RemoveAt(i);

                    if (messageTypeId.Equals(GameConstants.PLAYER_INITIAL_JUMP_MSG))
                    {
                        System.Console.WriteLine("Triggering fall message after cleanup");
                        //character.changeStatus(GameConstants.PLAYER_FALL_MSG);
                    }
                    else if (messageTypeId.Equals(GameConstants.PLAYER_INITIAL_JUMP_MOVING_LEFT_MSG))
                    {
                        ////System.Console.WriteLine("Triggering fall message after cleanup");
                        character.changeStatus(GameConstants.PLAYER_FALL_MOVING_LEFT_MSG);
                    }
                    else if (messageTypeId.Equals(GameConstants.PLAYER_INITIAL_JUMP_MOVING_RIGHT_MSG))
                    {
                        //System.Console.WriteLine("Triggering fall message after cleanup");
                        character.changeStatus(GameConstants.PLAYER_FALL_MOVING_RIGHT_MSG);
                    }
                }
            }
        }


    }
}
