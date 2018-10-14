// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
// Created by : Thor (Thore) Erendrood
// Open a window, enjoy the fresh air and let in an ant or wasp to enjoy your company.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.GameObject)]
    [Tooltip("Measures the distance between objects for X and Y separately (left and down is negative). Useful to add direction effects on the target. See twin action 'GetRelativeDirection2DEvents'")]
    public class GetRelativeDirection2D : FsmStateAction
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

    // see block below, if somehow world/local space switch is needed.
        //  public Space space;                                       

        [UIHint(UIHint.Variable), Readonly]
        [Tooltip("Option to store vertical direction to target in a bool. (e.g. 'storeIsRight = false' target is leftwards.")]
        public FsmBool storeIsRight = true;

        [UIHint(UIHint.Variable), Readonly]
        [Tooltip("Option to horizontal direction to target in a bool. (e.g. 'storeIsUp = false' target is downwards.")]
        public FsmBool storeIsUp = true;

        
        [Tooltip("Repeat every frame.")]
        public bool everyFrame;

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
          
        // Use this INSTEAD of two lines above, for extra world/local space switch. NOTE: uncomment space var on top, too!
           // var posOrigin = space == Space.World ? originObject.transform.position : originObject.transform.localPosition;  
           // var posTarget = space == Space.World ? target.Value.transform.position : target.Value.transform.localPosition;  

           storeDirectionX.Value =  Mathf.Abs(posTarget.x) - Mathf.Abs(posOrigin.x);
           storeDirectionY.Value = Mathf.Abs(posTarget.y) - Mathf.Abs(posOrigin.y);

            storeIsRight.Value  = true;
            if (storeDirectionX.Value < 0)
            {
                storeIsRight.Value  = false;
            }

            storeIsUp.Value = true;
            if (storeDirectionY.Value < 0)
            {
                storeIsUp.Value = false;
            }

          } // METHOD
          
    } // CLASS
} // NAMESPACE
