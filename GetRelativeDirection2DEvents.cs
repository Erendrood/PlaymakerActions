// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
// Created by Thor (Thore) Erendrood // http://hutonggames.com/playmakerforum/index.php?topic=19490
// Nobody exists on purpose, nobody belongs anywhere, everybody's going to die, come watch TV.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.GameObject)]
    [Tooltip("Measures the distance between objects for X and Y separately (left and down is negative), and can trigger events based on where the target is. Useful to add direction effects on the target. There's also a twin without the events.")]
    public class GetRelativeDirection2DEvents : FsmStateAction
    {

        // BASE VARIABLES
        [RequiredField]
        [Tooltip("Measure distance FROM this GameObject (e.g. when the target is left/up by 1 unit, will return -1x / +1y")]
        public FsmOwnerDefault origin;

        [RequiredField]
        [Tooltip("The Target GameObject.")]
        public FsmGameObject target;

        [UIHint(UIHint.Variable), Readonly]
        [Tooltip("Store the X direction in a float variable. When target is leftwards, returns a negative value! (use float abs if you want only positive values).")]
        public FsmFloat storeDirectionX;

        [UIHint(UIHint.Variable), Readonly]
        [Tooltip("Store the Y direction in a float variable.")]
        public FsmFloat storeDirectionY;


        //  public Space space;                                       // see block below, if somehow world/local space switch is needed.


        [UIHint(UIHint.Variable), Readonly]
        [Tooltip("Option to store vertical direction to target in a bool. (e.g. 'storeIsRight = false' target is leftwards.")]
        public FsmBool storeIsRight = true;

        [UIHint(UIHint.Variable), Readonly]
        [Tooltip("Option to horizontal direction to target in a bool. (e.g. 'storeIsUp = false' target is downwards.")]
        public FsmBool storeIsUp = true;

        [Tooltip("This will ignore the events. Better use 'GetRelativeDirection2D'")]
        public bool everyFrame;


        // DIRECTION EVENT VARIABLES
        // the ints are to keep the settings intact when you change/add this. 
      
        public enum Orientation
        {
             MatchBest = 1,
             HorizontalOnly = 2,
             VerticalOnly = 3,
             ShortestAxis = 4,
             Inverted = 5,

        }

        [Tooltip("If target is closer rightwards than upwards: MATCH BEST = return rightwards. SHORT AXIS = returns upwards. Inverted = returns leftwards, i.e. think of this as origin is 'left' of target, rather than target is 'right' of origin.).")]
        public Orientation preference;
        
        [UIHint(UIHint.FsmEvent)]
        [Tooltip("Event to send if target is considered leftwards.")]
        public FsmEvent isLeftwards;

        [UIHint(UIHint.FsmEvent)]
        [Tooltip("Event to send if target is considered rightwards.")]
        public FsmEvent isRightwards;

        [UIHint(UIHint.FsmEvent)]
        [Tooltip("Event to send if target is considered upwards.")]
        public FsmEvent isUpwards;

        [UIHint(UIHint.FsmEvent)]
        [Tooltip("Event to send if target is considered downwards.")]
        public FsmEvent isDownwards;


        // STANDARD METHODS

        public override void Reset()
        {
            origin = null;
            target = null;
            storeDirectionX = null;
            storeDirectionY = null;
            storeIsRight = true;
            storeIsUp = true;
            everyFrame = false;

            preference = Orientation.MatchBest;

            isLeftwards = null;
            isRightwards = null;
            isUpwards = null;
            isDownwards = null;
        }

        public override void OnEnter()
        {
            DoGetDirection();

            if (!everyFrame)
            {
                Finish();
            }
        }
        public override void OnUpdate()
        {
            DoGetDirection();
        }
        

        ///  EXECUTE ///////////////////////////////////////////


        void DoGetDirection()
        {
            var originObject = Fsm.GetOwnerDefaultTarget(origin);
               
            if (originObject == null || target.Value == null || storeDirectionX == null || storeDirectionY == null || storeIsUp == null || storeIsRight == null)
            {
                return;
            }

            var posOrigin = originObject.transform.position;
            var posTarget = target.Value.transform.position;

           // var posOrigin = space == Space.World ? originObject.transform.position : originObject.transform.localPosition;   // Use this INSTEAD of two lines above, for extra world/local space switch. NOTE: uncomment space var on top, too!
           // var posTarget = space == Space.World ? target.Value.transform.position : target.Value.transform.localPosition;  

           storeDirectionX.Value =  Mathf.Abs(posTarget.x) - Mathf.Abs(posOrigin.x);
           storeDirectionY.Value = Mathf.Abs(posTarget.y) - Mathf.Abs(posOrigin.y);

            storeIsRight.Value = true;
            if (storeDirectionX.Value < 0)
            {
                storeIsRight.Value = false;
            }


            storeIsUp.Value  = true;
            if (storeDirectionY.Value < 0)
            {
                storeIsUp.Value  = false;
            }


            // Trigger events based on direction.


            if (!everyFrame)
            {
               
                if (preference == Orientation.HorizontalOnly)
                {
                    Fsm.Event(storeIsRight.Value ? isRightwards : isLeftwards);
                }

                if (preference == Orientation.VerticalOnly)
                {
                    Fsm.Event(storeIsUp.Value  ? isUpwards : isDownwards);
                }
                
                if (preference == Orientation.MatchBest)
                {
                   if ( Mathf.Abs(storeDirectionX.Value) > Mathf.Abs(storeDirectionY.Value))
                    {
                        Fsm.Event(storeIsRight.Value ? isRightwards : isLeftwards);
                    }

                    if (Mathf.Abs(storeDirectionY.Value) > Mathf.Abs(storeDirectionX.Value))
                    {
                        Fsm.Event(storeIsUp.Value  ? isUpwards : isDownwards);
                    }                    
                }

                if (preference == Orientation.ShortestAxis)
                {
                    if (Mathf.Abs(storeDirectionX.Value) < Mathf.Abs(storeDirectionY.Value))
                    {
                        Fsm.Event(storeIsRight.Value ? isRightwards : isLeftwards);
                    }

                    if (Mathf.Abs(storeDirectionY.Value) < Mathf.Abs(storeDirectionX.Value))
                    {
                        Fsm.Event(storeIsUp.Value  ? isUpwards : isDownwards);
                    }
                }

                if (preference == Orientation.Inverted)
                {
                    if (Mathf.Abs(storeDirectionX.Value) > Mathf.Abs(storeDirectionY.Value))
                    {
                        Fsm.Event(!storeIsRight.Value ? isRightwards : isLeftwards);
                    }

                    if (Mathf.Abs(storeDirectionY.Value) > Mathf.Abs(storeDirectionX.Value))
                    {
                        Fsm.Event(!storeIsUp.Value  ? isUpwards : isDownwards);
                    }
                }

            }



        }
        
       

    }
}

