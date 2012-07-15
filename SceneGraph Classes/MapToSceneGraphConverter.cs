using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlluringNinja.Map_Data_Classes;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace AlluringNinja.SceneGraph_Classes
{
    public class MapToSceneGraphConverter
    {
        public static void convert(Map map, SceneGraph sceneGraph)
        {
            convertBackgroundTiles(map, sceneGraph);
            convertCharacters(map, sceneGraph);
        }

        private static void convertBackgroundTiles(Map map, SceneGraph sceneGraph)
        {
            foreach (BackgroundTileMap backgroundMapTile in map.getBackgroundTileList())
            {

                BackgroundTile backgroundTile = new BackgroundTile();
                backgroundTile.setObjectPosition(backgroundMapTile.getObjectPosition());
                backgroundTile.setScale(backgroundMapTile.getScale());
                Texture2D texture2D = StringToGraphicsConverter.convertBackgroundTile(backgroundMapTile.getTileType(), sceneGraph);
                backgroundTile.setTexture2D(texture2D);
                sceneGraph.addBackgroundTile(backgroundTile);
            }
        }
        //under construction

        private static void convertCharacters(Map map, SceneGraph sceneGraph)
        {
            Player character = new Player(sceneGraph);

            character.objectPosition = new Vector2(0, 0);

            character.scale = new Vector2(1, 1);

            
            
            //load sprite sheets

            sceneGraph.redNinjaTotalTexture = sceneGraph.getContentManager().Load<Texture2D>("red_ninja");
            sceneGraph.yellowNinjaTotalTexture = sceneGraph.getContentManager().Load<Texture2D>("yellow_ninja");

            
            Animation stillAnimation = TextureUtility.ConvertStillAnimation(sceneGraph.renderingEngine, sceneGraph.redNinjaTotalTexture);
            stillAnimation.setFrameRate(GameConstants.PLAYER_STILL_FRAMERATE);
            stillAnimation.setAnimationId(GameConstants.PLAYER_NO_MOVEMENT_ANIMATION);
            stillAnimation.setMaxFrames(stillAnimation.getTextureListSize() - 1);
            stillAnimation.cycleAnimationOn();
            character.addToAnimationList(stillAnimation);

            //movement animation

            Animation walkingRightAnimation = TextureUtility.ConvertWalkingAnimation(sceneGraph.renderingEngine, sceneGraph.redNinjaTotalTexture);
            walkingRightAnimation.setFrameRate(GameConstants.PLAYER_WALKING_FRAMERATE);
            walkingRightAnimation.setMaxFrames(walkingRightAnimation.getTextureListSize()-1);
            walkingRightAnimation.setAnimationId(GameConstants.PLAYER_MOVEMENT_RIGHT_ANIMATION);
            walkingRightAnimation.cycleAnimationOn();
            
            character.addToAnimationList(walkingRightAnimation);

            Animation walkingLeftAnimation = TextureUtility.ConvertWalkingAnimation(sceneGraph.renderingEngine, sceneGraph.redNinjaTotalTexture);
            walkingLeftAnimation.setFrameRate(GameConstants.PLAYER_WALKING_FRAMERATE);
            walkingLeftAnimation.setMaxFrames(walkingRightAnimation.getTextureListSize() - 1);
            walkingLeftAnimation.setAnimationId(GameConstants.PLAYER_MOVEMENT_LEFT_ANIMATION);
            walkingLeftAnimation.cycleAnimationOn();
            walkingLeftAnimation.flipHorizontally();
            character.addToAnimationList(walkingLeftAnimation);

            Animation changingClothesAnimation = TextureUtility.ConvertChangingAnimation(sceneGraph.renderingEngine, sceneGraph.redNinjaTotalTexture);
            changingClothesAnimation.setFrameRate(GameConstants.PLAYER_CHANGING_CLOTHES_FRAMERATE);
            changingClothesAnimation.setMaxFrames(changingClothesAnimation.getTextureListSize() - 1);
            changingClothesAnimation.setAnimationId(GameConstants.PLAYER_CHANGING_CLOTHES_ANIMATION);
            character.addToAnimationList(changingClothesAnimation);

            Animation deathAnimation = TextureUtility.ConvertDeathAnimation(sceneGraph.renderingEngine, sceneGraph.redNinjaTotalTexture);
            deathAnimation.setFrameRate(GameConstants.PLAYER_DEATH_FRAMERATE);
            deathAnimation.setMaxFrames(changingClothesAnimation.getTextureListSize() - 1);
            deathAnimation.setAnimationId(GameConstants.PLAYER_DEATH_ANIMATION);
            character.addToAnimationList(deathAnimation);

            Animation initialJumpAnimation = TextureUtility.ConvertInitialJumpAnimation(sceneGraph.renderingEngine, sceneGraph.redNinjaTotalTexture);
            initialJumpAnimation.setFrameRate(GameConstants.PLAYER_JUMP_FRAMERATE);
            initialJumpAnimation.setMaxFrames(initialJumpAnimation.getTextureListSize() - 1);
            initialJumpAnimation.setAnimationId(GameConstants.PLAYER_INITIAL_JUMP_ANIMATION);
            character.addToAnimationList(initialJumpAnimation);

            Animation initialJumpLeftAnimation = TextureUtility.ConvertInitialJumpAnimation(sceneGraph.renderingEngine, sceneGraph.redNinjaTotalTexture);
            initialJumpLeftAnimation.setFrameRate(GameConstants.PLAYER_JUMP_FRAMERATE);
            initialJumpLeftAnimation.setMaxFrames(initialJumpLeftAnimation.getTextureListSize() - 1);
            initialJumpLeftAnimation.setAnimationId(GameConstants.PLAYER_INITIAL_JUMP_LEFT_ANIMATION);
            initialJumpLeftAnimation.flipHorizontally();
            character.addToAnimationList(initialJumpLeftAnimation);


            Animation cycleJumpAnimation = TextureUtility.ConvertCycleJumpAnimation(sceneGraph.renderingEngine, sceneGraph.redNinjaTotalTexture);
            cycleJumpAnimation.setFrameRate(GameConstants.PLAYER_JUMP_FRAMERATE);
            cycleJumpAnimation.setMaxFrames(cycleJumpAnimation.getTextureListSize() - 1);
            cycleJumpAnimation.setAnimationId(GameConstants.PLAYER_CYCLE_JUMP_ANIMATION);
            cycleJumpAnimation.cycleAnimationOn();
            character.addToAnimationList(cycleJumpAnimation);

            Animation cycleJumpLeftAnimation = TextureUtility.ConvertCycleJumpAnimation(sceneGraph.renderingEngine, sceneGraph.redNinjaTotalTexture);
            cycleJumpLeftAnimation.setFrameRate(GameConstants.PLAYER_JUMP_FRAMERATE);
            cycleJumpLeftAnimation.setMaxFrames(cycleJumpLeftAnimation.getTextureListSize() - 1);
            cycleJumpLeftAnimation.setAnimationId(GameConstants.PLAYER_CYCLE_JUMP_LEFT_ANIMATION);
            cycleJumpLeftAnimation.cycleAnimationOn();
            character.addToAnimationList(cycleJumpLeftAnimation);


            Animation fallAnimation = TextureUtility.ConvertCycleJumpAnimation(sceneGraph.renderingEngine, sceneGraph.redNinjaTotalTexture);
            fallAnimation.setFrameRate(GameConstants.PLAYER_JUMP_FRAMERATE);
            fallAnimation.setMaxFrames(fallAnimation.getTextureListSize() - 1);
            fallAnimation.setAnimationId(GameConstants.PLAYER_FALL_ANIMATION);
            fallAnimation.cycleAnimationOn();
            character.addToAnimationList(fallAnimation);

            Animation fallLeftAnimation = TextureUtility.ConvertCycleJumpAnimation(sceneGraph.renderingEngine, sceneGraph.redNinjaTotalTexture);
            fallLeftAnimation.setFrameRate(GameConstants.PLAYER_JUMP_FRAMERATE);
            fallLeftAnimation.setMaxFrames(fallLeftAnimation.getTextureListSize() - 1);
            fallLeftAnimation.setAnimationId(GameConstants.PLAYER_FALL_LEFT_ANIMATION);
            fallLeftAnimation.cycleAnimationOn();
            fallLeftAnimation.flipHorizontally();
            character.addToAnimationList(fallLeftAnimation);

            Animation attackAnimation = TextureUtility.ConvertAttackAnimation(sceneGraph.renderingEngine, sceneGraph.redNinjaTotalTexture);
            attackAnimation.setFrameRate(GameConstants.PLAYER_ATTACK_FRAMERATE);
            attackAnimation.setMaxFrames(attackAnimation.getTextureListSize() - 1);
            attackAnimation.setAnimationId(GameConstants.PLAYER_ATTACK_ANIMATION);
            character.addToAnimationList(attackAnimation);

            Animation attackLeftAnimation = TextureUtility.ConvertAttackAnimation(sceneGraph.renderingEngine, sceneGraph.redNinjaTotalTexture);
            attackLeftAnimation.setFrameRate(GameConstants.PLAYER_ATTACK_FRAMERATE);
            attackLeftAnimation.setMaxFrames(attackLeftAnimation.getTextureListSize() - 1);
            attackLeftAnimation.setAnimationId(GameConstants.PLAYER_ATTACK_LEFT_ANIMATION);
            attackLeftAnimation.flipHorizontally();
            character.addToAnimationList(attackLeftAnimation);


            //initalize character
            character.currentAnimation = GameConstants.PLAYER_NO_MOVEMENT_ANIMATION;
            //character.objectPosition = new Vector2(270, 280);
            character.objectPosition = new Vector2(270, 180);
            //character.objectPosition = new Vector2(0, 0);
            character.width = 100;
            character.height = 100;
            character.idString = GameConstants.PLAYER_OBJECT_ID;


            sceneGraph.addPlayer(character);


        }
    }
}
