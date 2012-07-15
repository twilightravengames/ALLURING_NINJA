using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Collections;

namespace AlluringNinja.SceneGraph_Classes
{
    public class Character2D
    {

        public SceneGraph sceneGraph;

        //includes a list/vector of animation objects (represent each possible animation)
        //index variable to hold current animation

        public Vector2 objectPosition;
        public Vector2 scale;
        public float width;
        public float height;
        
        public SortedList animationList = new SortedList();
        public String currentAnimation;
        
        public String idString;
        public String walkingStatus;
        public String currentStatus;
        public Boolean isJumpingMovingRight = false;
        public Boolean isJumpingMovingLeft = false;
        public Boolean isJumpingAttacking = false;
        public Boolean isJumpingStraightUp = false;
        public Boolean statusIsLocked = false;
        public Boolean attackIsLocked = false;
        public Boolean isDead = false;
        public int numberOfJumps = 0;
        public int facing = GameConstants.FRONT;

        public Character2D(SceneGraph sceneGraph)
        {
            this.sceneGraph = sceneGraph;
            objectPosition = new Vector2(10.0f, 0.0f);
            
        }

        public void resetJumps()
        {
            numberOfJumps = 0;
        }

        public void addToAnimationList(Animation animation)
        {
            animationList.Add(animation.getAnimationId(), animation);
        }

        public virtual void draw(RenderingEngine renderingEngine)
        {
            ((Animation)(animationList[currentAnimation])).draw(renderingEngine, this);
        }

        public void updateAnimation(RenderingEngine renderingEngine)
        {
            //System.Console.WriteLine("Updating this animation: " + currentAnimation);
            ((Animation)(animationList[currentAnimation])).updateAnimation();
            if (((Animation)(animationList[currentAnimation])).isTerminated() == true && statusIsLocked == true && ((Animation)(animationList[currentAnimation])).isCycleAnimation() == false)
            {
                statusIsLocked = false;
            }
            if (((Animation)(animationList[currentAnimation])).isTerminated() == true && ((Animation)(animationList[currentAnimation])).getAnimationId().Equals(GameConstants.PLAYER_INITIAL_JUMP_ANIMATION))
            
            {
                statusIsLocked = false;
               
                changeStatus(GameConstants.PLAYER_CYCLE_JUMP_MSG);
            }
            
            if (((Animation)(animationList[currentAnimation])).isTerminated() == true && ((Animation)(animationList[currentAnimation])).getAnimationId().Equals(GameConstants.PLAYER_INITIAL_JUMP_LEFT_ANIMATION))
            {
                statusIsLocked = false;

                changeStatus(GameConstants.PLAYER_CYCLE_JUMP_MSG);
            }
            if (((Animation)(animationList[currentAnimation])).isTerminated() == true && ((Animation)(animationList[currentAnimation])).getAnimationId().Equals(GameConstants.PLAYER_FALL_ANIMATION))
            {
                //System.Console.WriteLine("Unlocking status, falling animation terminated.");
                   
                statusIsLocked = false;
            }
            if (((Animation)(animationList[currentAnimation])).isTerminated() == true && ((Animation)(animationList[currentAnimation])).getAnimationId().Equals(GameConstants.PLAYER_FALL_LEFT_ANIMATION))
            {
                //System.Console.WriteLine("Unlocking status, falling animation terminated.");

                statusIsLocked = false;
            }
            if (((Animation)(animationList[currentAnimation])).isTerminated() == true && ((Animation)(animationList[currentAnimation])).getAnimationId().Equals(GameConstants.PLAYER_ATTACK_ANIMATION))
            {
                //System.Console.WriteLine("Unlocking status, falling animation terminated.");

                statusIsLocked = false;
                attackIsLocked = false;
            }
            if (((Animation)(animationList[currentAnimation])).isTerminated() == true && ((Animation)(animationList[currentAnimation])).getAnimationId().Equals(GameConstants.PLAYER_ATTACK_LEFT_ANIMATION))
            {
                //System.Console.WriteLine("Unlocking status, falling animation terminated.");

                statusIsLocked = false;
                attackIsLocked = false;
            }

        }

                
        public virtual void triggerAnimation(String animationIdString)
        {
            String oldAnimation = currentAnimation;
            currentAnimation = animationIdString;

            //System.Console.WriteLine("current animation: " + animationIdString);
            Animation currentAnimationObject = ((Animation)(animationList[currentAnimation]));

            //if the old animation is not the same as the new animatino
            //we do not want to reset the animation, we want it to continue
            if (!oldAnimation.Equals(currentAnimation) || currentAnimationObject.isTerminated())
            {
                //System.Console.WriteLine("Reseting frame and time for animation: " + currentAnimation);
                currentAnimationObject.resetFrameCounter();
                currentAnimationObject.resetLastFrameTime();
            }
        }


        public void changeStatus(String statusString)
        {

            if (statusString.Equals(GameConstants.PLAYER_MOVEMENT_RIGHT_MSG))
            {
                //Console.WriteLine("Received a changeStatus message of PLAYER_MOVEMENT_RIGHT_MSG");
            }

            if (!statusString.Equals(GameConstants.PLAYER_ATTACK_MSG))
            {
                attackIsLocked = false;
            }
            //System.Console.WriteLine("received change status to:" + statusString);
            if (statusString.Equals(GameConstants.PLAYER_FALL_MOVING_LEFT_MSG))
            {
                isJumpingMovingLeft = true;
                statusString = GameConstants.PLAYER_FALL_MSG;
            }
            else if (statusString.Equals(GameConstants.PLAYER_FALL_MOVING_RIGHT_MSG))
            {
                isJumpingMovingRight = true;
                statusString = GameConstants.PLAYER_FALL_MSG;
            }
            else if (statusString.Equals(GameConstants.PLAYER_INITIAL_JUMP_MOVING_LEFT_MSG))
            {
                isJumpingMovingLeft = true;
                statusString = GameConstants.PLAYER_INITIAL_JUMP_MSG;
            }
            else if (statusString.Equals(GameConstants.PLAYER_INITIAL_JUMP_MOVING_RIGHT_MSG))
            {
                isJumpingMovingRight = true;
                statusString = GameConstants.PLAYER_INITIAL_JUMP_MSG;
            }
            else if (statusString.Equals(GameConstants.PLAYER_INITIAL_JUMP_MSG))
            {
                
                isJumpingStraightUp = true;

            }
           
            else
            {
                isJumpingMovingRight = false;
                isJumpingMovingLeft = false;
                isJumpingStraightUp = false;
            }

            
            //

            if (currentStatus.Equals(GameConstants.PLAYER_INITIAL_JUMP_MSG))
            {
                //Console.WriteLine("currentStatus is Player Initial Jump Msg and statusString is: " + statusString);
                if (statusString.Equals(GameConstants.PLAYER_MOVEMENT_LEFT_MSG))
                {
                    isJumpingMovingLeft = true;
                    statusString = GameConstants.PLAYER_INITIAL_JUMP_MOVING_LEFT_MODIFIER;
                   
                }
                else if (statusString.Equals(GameConstants.PLAYER_MOVEMENT_RIGHT_MSG))
                {
                    isJumpingMovingRight = true;
                    statusString = GameConstants.PLAYER_INITIAL_JUMP_MOVING_RIGHT_MODIFIER;
                }
            }

            else if (currentStatus.Equals(GameConstants.PLAYER_CYCLE_JUMP_MSG))
            {
                //Console.WriteLine("currentStatus is Player Cycle Jump Msg");
                if (statusString.Equals(GameConstants.PLAYER_MOVEMENT_LEFT_MSG))
                {
                    isJumpingMovingLeft = true;
                    statusString = GameConstants.PLAYER_CYCLE_JUMP_MOVING_LEFT_MODIFIER;
                }
                else if (statusString.Equals(GameConstants.PLAYER_MOVEMENT_RIGHT_MSG))
                {
                    isJumpingMovingRight = true;
                    statusString = GameConstants.PLAYER_CYCLE_JUMP_MOVING_RIGHT_MODIFIER;
                }
            }

            else if (currentStatus.Equals(GameConstants.PLAYER_FALL_MSG))
            {
                if (statusString.Equals(GameConstants.PLAYER_MOVEMENT_LEFT_MSG))
                {
                    statusString = GameConstants.PLAYER_FALL_MOVING_LEFT_MODIFIER;
                }
                else if (statusString.Equals(GameConstants.PLAYER_MOVEMENT_RIGHT_MSG))
                {
                    statusString = GameConstants.PLAYER_FALL_MOVING_RIGHT_MODIFIER;

                }
            }
            


            //

            //handle locking conditions: conditions that will only change if status is not locked
            if (!statusIsLocked && !isDead)
            {
                if (statusString.Equals(GameConstants.PLAYER_MOVEMENT_RIGHT_MSG))
                {

                    walkingStatus = GameConstants.PLAYER_MOVEMENT_RIGHT_MSG;
                    triggerAnimation(GameConstants.PLAYER_MOVEMENT_RIGHT_ANIMATION);
                    facing = GameConstants.RIGHT;
                    resetJumps();
                    sceneGraph.positionUpdater.registerMovement(GameConstants.PLAYER_OBJECT_ID, GameConstants.PLAYER_MOVEMENT_RIGHT_MSG);
                }

                if (statusString.Equals(GameConstants.PLAYER_MOVEMENT_LEFT_MSG))
                {
                    //System.Console.WriteLine("Character2D object received move left message");
                    walkingStatus = GameConstants.PLAYER_MOVEMENT_LEFT_MSG;
                    triggerAnimation(GameConstants.PLAYER_MOVEMENT_LEFT_ANIMATION);
                    facing = GameConstants.LEFT;
                    resetJumps();
                    sceneGraph.positionUpdater.registerMovement(GameConstants.PLAYER_OBJECT_ID, GameConstants.PLAYER_MOVEMENT_LEFT_MSG);
                }

                if (statusString.Equals(GameConstants.PLAYER_NO_MOVEMENT_MSG))
                {

                    walkingStatus = GameConstants.PLAYER_NO_MOVEMENT_MSG;
                    triggerAnimation(GameConstants.PLAYER_NO_MOVEMENT_ANIMATION);
                    resetJumps();
                    facing = GameConstants.FRONT;
                    sceneGraph.positionUpdater.registerMovement(GameConstants.PLAYER_OBJECT_ID, GameConstants.PLAYER_NO_MOVEMENT_MSG);
                }

                if (statusString.Equals(GameConstants.PLAYER_CHANGE_CLOTHES_MSG))
                {


                    triggerAnimation(GameConstants.PLAYER_CHANGING_CLOTHES_ANIMATION);
                    statusIsLocked = true;
                    //sceneGraph.positionUpdater.registerMovement(GameConstants.PLAYER_OBJECT_ID, GameConstants.PLAYER_CHANGE_CLOTHES_MSG);
                }
                if (statusString.Equals(GameConstants.PLAYER_INITIAL_JUMP_MSG) && numberOfJumps < 2)
                {
                    if (facing == GameConstants.LEFT)
                    {
                        triggerAnimation(GameConstants.PLAYER_INITIAL_JUMP_LEFT_ANIMATION);
                    }
                    else
                    {

                        triggerAnimation(GameConstants.PLAYER_INITIAL_JUMP_ANIMATION);
                    }

                    if (isJumpingMovingLeft)
                    {
                        sceneGraph.positionUpdater.registerMovement(GameConstants.PLAYER_OBJECT_ID, GameConstants.PLAYER_INITIAL_JUMP_MOVING_LEFT_MSG);
                    }
                    else if (isJumpingMovingRight)
                    {
                        sceneGraph.positionUpdater.registerMovement(GameConstants.PLAYER_OBJECT_ID, GameConstants.PLAYER_INITIAL_JUMP_MOVING_RIGHT_MSG);
                    }
                    else
                    {
                        sceneGraph.positionUpdater.registerMovement(GameConstants.PLAYER_OBJECT_ID, GameConstants.PLAYER_INITIAL_JUMP_MSG);
                    }
                    statusIsLocked = true;
                    numberOfJumps++;
                }
                 
                currentStatus = statusString;
            }
            //handle non-locking conditions (conditions that don't matter if status is locked)
            if (!isDead)
            {
                if (statusString.Equals(GameConstants.PLAYER_DEATH_MSG))
                {
                    //System.Console.WriteLine("Triggering death animation");
                    triggerAnimation(GameConstants.PLAYER_DEATH_ANIMATION);
                    isDead = true;
                    currentStatus = statusString;
                }
                if (statusString.Equals(GameConstants.PLAYER_FALL_MSG))
                {
                    //System.Console.WriteLine("Changing status to player fall.");

                    if (facing == GameConstants.LEFT)
                    {
                        triggerAnimation(GameConstants.PLAYER_FALL_LEFT_ANIMATION);
                    }
                    else
                    {
                        triggerAnimation(GameConstants.PLAYER_FALL_ANIMATION);
                    }

                    if (isJumpingMovingLeft)
                    {
                        sceneGraph.positionUpdater.registerMovement(GameConstants.PLAYER_OBJECT_ID, GameConstants.PLAYER_FALL_MOVING_LEFT_MSG);
                    }
                    else if (isJumpingMovingRight)
                    {
                        sceneGraph.positionUpdater.registerMovement(GameConstants.PLAYER_OBJECT_ID, GameConstants.PLAYER_FALL_MOVING_RIGHT_MSG);
                    }
                    else
                    {
                        sceneGraph.positionUpdater.registerMovement(GameConstants.PLAYER_OBJECT_ID, GameConstants.PLAYER_FALL_MSG);
                    }
                    currentStatus = statusString;
                    statusIsLocked = true;
                }
                if (statusString.Equals(GameConstants.PLAYER_CYCLE_JUMP_MSG))
                {
                    //System.Console.WriteLine("Changing status to player cycle jump.");
                    triggerAnimation(GameConstants.PLAYER_CYCLE_JUMP_ANIMATION);
                    currentStatus = statusString;
                    statusIsLocked = true;
                }
                if (statusString.Equals(GameConstants.PLAYER_ATTACK_MSG) && !attackIsLocked)
                {
                    if (facing == GameConstants.LEFT)
                    {
                        triggerAnimation(GameConstants.PLAYER_ATTACK_LEFT_ANIMATION);
                    }
                    else
                    {
                        triggerAnimation(GameConstants.PLAYER_ATTACK_ANIMATION);
                    }
                    //sceneGraph.positionUpdater.registerMovement(GameConstants.PLAYER_OBJECT_ID, GameConstants.PLAYER_ATTACK_MSG);                 

                    statusIsLocked = true;
                    attackIsLocked = true;
                    currentStatus = statusString;
                }


                //mid-jump modifiers
                
                if (statusString.Equals(GameConstants.PLAYER_INITIAL_JUMP_MOVING_LEFT_MODIFIER)
                    || statusString.Equals(GameConstants.PLAYER_INITIAL_JUMP_MOVING_RIGHT_MODIFIER)
                    || statusString.Equals(GameConstants.PLAYER_CYCLE_JUMP_MOVING_LEFT_MODIFIER) 
                    || statusString.Equals(GameConstants.PLAYER_CYCLE_JUMP_MOVING_RIGHT_MODIFIER)
                    || statusString.Equals(GameConstants.PLAYER_FALL_MOVING_LEFT_MODIFIER)
                    || statusString.Equals(GameConstants.PLAYER_FALL_MOVING_RIGHT_MODIFIER))
                {
                    //Console.WriteLine("Status String modifier: " + statusString);
                    sceneGraph.positionUpdater.registerMovement(GameConstants.PLAYER_OBJECT_ID, statusString);
                }
                
                


            }


            

            
            
                Console.WriteLine("statusString is: " + statusString);
                
                
        }

        //draw method calls draw on appropriate animation (by index)
        //update method calls update on appropriate animation (by index)
    }
}
