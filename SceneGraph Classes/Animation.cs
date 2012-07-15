using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;

namespace AlluringNinja.SceneGraph_Classes
{
    public class Animation
    {
        private int maxFrames = 0;
        float frameRate = 0.0f;
        int frameCounter = 0;

        //used for animation updates
        int lastFrameTime = 0;

       

        String animationId;

        Boolean cycleAnimation = false;
        Boolean isFlipHorizontally = false;


        SortedList texture2DList = new SortedList();

        public Animation()
        {
            lastFrameTime = UtilityTimer.getTime();
        }

        public Boolean isCycleAnimation()
        {
            return cycleAnimation;
        }

        public void cycleAnimationOn()
        {
            cycleAnimation = true;
        }

        public void cycleAnimationOff()
        {
            cycleAnimation = false;
        }

        public void flipHorizontally()
        {
            isFlipHorizontally = true;
        }

        public Boolean isTerminated()
        {
            if (frameCounter >= maxFrames)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int getTextureListSize()
        {
            return texture2DList.Count;
        }

        public void setAnimationId(String animationId)
        {
            this.animationId = animationId;
        }

        public String getAnimationId()
        {
            return animationId;
        }

        //reset method resets frame counter
        public void resetFrameCounter()
        {
            frameCounter = 0;
        }

        public void resetLastFrameTime()
        {
            lastFrameTime = UtilityTimer.getTime();
            //System.Console.WriteLine("Reseting last frame time...value is " + lastFrameTime);
        }

        public void setFrameRate(float frameRate)
        {
            this.frameRate = frameRate;
        }

        public void setMaxFrames(int maxFrames)
        {
            this.maxFrames = maxFrames;
        }

        //update method (called to update animation frame. dependent upon time
        //retrieved from UtilityTimer class, will update accordingly (skip frames if necessary)
        //or wait to draw frames. updates by increasing texture index, wrapping around if 
        //necessary

        public void updateAnimation()
        {

                int currentTime = UtilityTimer.getTime();
                int timeElapsed = UtilityTimer.getTime() - lastFrameTime;

                //System.Console.WriteLine("Last Frame Time" + lastFrameTime);
                //System.Console.WriteLine("Current Time" + currentTime); 
                //System.Console.WriteLine("Time Elapsed" + timeElapsed);
                //System.Console.WriteLine("Current Frame" + frameCounter);
                //System.Console.WriteLine("Animation ID" + animationId);
                

                if (timeElapsed >= frameRate)
                {
                    lastFrameTime = UtilityTimer.getTime();
                    //enough time has elapsed to move to next frame

                    //check to see if less than two frames have passed
                    if (timeElapsed < (2 * frameRate))
                    {
                        //System.Console.WriteLine("Not performing frame skip");
                        //check to make sure not at max frames
                        if (frameCounter < maxFrames)
                        {
                            //update frame by 1

                            frameCounter++;
                        }

                        //if at max frames...
                        else
                        {
                            //check for wrap around
                            if (cycleAnimation == true)
                            {
                                resetFrameCounter();
                            }
                        }
                    }

                    //more than one frame has passed
                    else
                    {
                        int frameSkip = (int)(timeElapsed / frameRate);

                        //System.Console.WriteLine("Performing frame skip");
                        // check to make sure not at max frames
                        if ((frameCounter + frameSkip) < maxFrames)
                        {
                            //System.Console.WriteLine("Adding frame skip");
                            frameCounter += frameSkip;
                        }

                        //else if at max frames
                        else 
                        {
                            //check for wrap around
                            if (cycleAnimation == true && frameCounter >= maxFrames)
                            {
                                resetFrameCounter();
                            }

                            //otherwise set to last frame
                            else
                            {
                                frameCounter = maxFrames;
                            }
                        }


                    }

                }

            }
        
        //draw method: will draw the texture in the current texture index

        public void draw(RenderingEngine renderingEngine, Character2D c)
        {
            //System.Console.WriteLine("Flip Horizontally: " + isFlipHorizontally);
            if (isFlipHorizontally)
            {
                //System.Console.WriteLine("Drawing flip horizontal model");
                renderingEngine.DrawScaledHorizontallyFlipped2DModel(c, (Texture2D)texture2DList.GetByIndex(frameCounter));
            }
            else
            {
                renderingEngine.DrawScaled2DModel(c, (Texture2D)texture2DList.GetByIndex(frameCounter));
            }
            
            if (texture2DList.Count == 0)
            {
                //System.Console.WriteLine("Texture 2D List is empty");
            }
            //System.Console.WriteLine("Max Frames is " + maxFrames);
            //System.Console.WriteLine("Frame Counter is " + frameCounter);
        
            //System.Console.WriteLine("Count is " + texture2DList.Count);
        }

        public void draw(RenderingEngine renderingEngine, Player c)
        {
            //System.Console.WriteLine("Flip Horizontally: " + isFlipHorizontally);
            if (isFlipHorizontally)
            {
                //System.Console.WriteLine("Drawing flip horizontal model");
                renderingEngine.DrawScaledHorizontallyFlipped2DModel(c, (Texture2D)texture2DList.GetByIndex(frameCounter));
            }
            else
            {
                renderingEngine.DrawScaled2DModel(c, (Texture2D)texture2DList.GetByIndex(frameCounter));
            }

            if (texture2DList.Count == 0)
            {
                System.Console.WriteLine("Texture 2D List is empty");
            }
            //System.Console.WriteLine("Max Frames is " + maxFrames);
            //System.Console.WriteLine("Frame Counter is " + frameCounter);

            //System.Console.WriteLine("Count is " + texture2DList.Count);
        }


        public void addToTexture2DList(Texture2D texture)
        {
            texture2DList.Add(texture2DList.Count + 1, texture);
            maxFrames++;
        }

    }
}
