using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlluringNinja
{
    public class GameConstants
    {
        //Facing constants
        public const int FRONT = 0;
        public const int BACK = 1;
        public const int LEFT = 2;
        public const int RIGHT = 3;

        //Movement Constants
        public const float PLAYER_RATE_OF_MOVEMENT = 10.0f;
        public const float PLAYER_MAGNIFIED_RATE_OF_MOVEMENT = 120.0f;
        public const int PLAYER_AMOUNT_MOVED_PER_KEYPRESS = 40;
        public const int PLAYER_JUMP_HEIGHT = 180; //original 130, 150 to right below second platform
        public const int PLAYER_FALL_DISTANCE = 120;
        public const float PLAYER_RATE_OF_JUMP = 35.0f; //(20 is moderately slow, 50 is extremely fast)
        

        //PositionUpdater/KeyHandler Message Constants
        public const String PLAYER_NO_MOVEMENT_MSG = "Still";
        public const String PLAYER_MOVEMENT_RIGHT_MSG = "MoveRight";
        public const String PLAYER_MOVEMENT_LEFT_MSG = "MoveLeft";
        public const String PLAYER_CHANGE_CLOTHES_MSG = "Change";
        public const String PLAYER_DEATH_MSG = "Death";
        public const String PLAYER_INITIAL_JUMP_MSG = "InitialJump";
        public const String PLAYER_CYCLE_JUMP_MSG = "CycleJump";
        public const String PLAYER_FALL_MSG = "Fall";
        public const String PLAYER_ATTACK_MSG = "Attack";
        public const String PLAYER_INITIAL_JUMP_MOVING_LEFT_MSG = "InitialJumpMovingLeft";
        public const String PLAYER_INITIAL_JUMP_MOVING_RIGHT_MSG = "InitialJumpMovingRight";
        public const String PLAYER_CYCLE_JUMP_MOVING_LEFT_MSG = "CycleJumpMovingLeft";
        public const String PLAYER_CYCLE_JUMP_MOVING_RIGHT_MSG = "CycleJumpMovingRight";
        public const String PLAYER_FALL_MOVING_LEFT_MSG = "FallMovingLeft";
        public const String PLAYER_FALL_MOVING_RIGHT_MSG = "FallMovingRight";
        public const String PLAYER_ATTACKING_WHILE_JUMPING = "AttackingWhileJumping";        
        
        //movement modifier messages
        public const String PLAYER_INITIAL_JUMP_MOVING_LEFT_MODIFIER = "IJMLM";
        public const String PLAYER_INITIAL_JUMP_MOVING_RIGHT_MODIFIER = "IJMRM";
        public const String PLAYER_CYCLE_JUMP_MOVING_LEFT_MODIFIER = "CJMLM";
        public const String PLAYER_CYCLE_JUMP_MOVING_RIGHT_MODIFIER = "CJMRM";
        public const String PLAYER_FALL_MOVING_LEFT_MODIFIER = "FMLM";
        public const String PLAYER_FALL_MOVING_RIGHT_MODIFIER = "FMRM";



        //Animation ID Constants
        public const String PLAYER_NO_MOVEMENT_ANIMATION = "Still";
        public const String PLAYER_MOVEMENT_RIGHT_ANIMATION = "MoveRight";
        public const String PLAYER_MOVEMENT_LEFT_ANIMATION = "MoveLeft";
        public const String PLAYER_CHANGING_CLOTHES_ANIMATION = "Changing";
        public const String PLAYER_DEATH_ANIMATION = "Death";
        public const String PLAYER_INITIAL_JUMP_ANIMATION = "InitialJump";
        public const String PLAYER_INITIAL_JUMP_LEFT_ANIMATION = "InitialJumpLeft";
        public const String PLAYER_CYCLE_JUMP_ANIMATION = "CycleJump";
        public const String PLAYER_CYCLE_JUMP_LEFT_ANIMATION = "CycleJumpLeft";
        public const String PLAYER_FALL_ANIMATION = "Fall";
        public const String PLAYER_FALL_LEFT_ANIMATION = "FallLeft";
        public const String PLAYER_ATTACK_ANIMATION = "Attack";
        public const String PLAYER_ATTACK_LEFT_ANIMATION = "AttackLeft";

        //Object ID Constants
        public const String PLAYER_OBJECT_ID = "Player";

        //Animation framerate constants (the higher the framerate, the slower the animation)
        public const float PLAYER_WALKING_FRAMERATE = 50.0f;
        public const float PLAYER_STILL_FRAMERATE = 300.0f;
        public const float PLAYER_CHANGING_CLOTHES_FRAMERATE = 300.0f;
        public const float PLAYER_DEATH_FRAMERATE = 300.0f;
        public const float PLAYER_JUMP_FRAMERATE = 300.0f;
        public const float PLAYER_FALL_FRAMERATE = 300.0f;
        public const float PLAYER_ATTACK_FRAMERATE = 125.0f;

        //Gravity Constants
        public const float PLAYER_GROUND_SEPERATION_CNSTNT = 7.0f;
        
    
    }
}
