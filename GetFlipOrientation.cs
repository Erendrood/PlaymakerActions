// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.
// http://hutonggames.com/playmakerforum/index.php?topic=63.0
// Thanks: MaDDoX

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Transform)]
    [Tooltip("Gets the x Scale of a Game Object, sets a bool and fires off events according to orientation.")]
    public class GetFlipOrientation: FsmStateAction
    {
        [RequiredField]
        public FsmOwnerDefault gameObject;

        [Tooltip("Event to send if scale returns as positive (e.g. character is not flipped).")]
        public FsmEvent eventPositiveScale;

        [Tooltip("Event to send if scale returns as negative (e.g. character is flipped).")]
        public FsmEvent eventNegativeScale;
        
        [Tooltip("Event to send if scale returns as negative (e.g. character is flipped).")]
        [UIHint(UIHint.Variable), Readonly]
        public FsmBool storeScaleIsPositive;
        
        public bool everyFrame;

        public override void Reset()
        {
            gameObject = null;
            everyFrame = false;
            storeScaleIsPositive = null;
        }

        public override void OnEnter()
        {
            DoGetOrientation();

            if (!everyFrame)
            {
                Finish();
            }
        }

        public override void OnUpdate()
        {
            DoGetOrientation(); 
        }

        void DoGetOrientation()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null)
            {
                return;
            }

            var scale = go.transform.localScale;

            if (scale.x < 0)
            {
                Fsm.Event(eventNegativeScale);
                storeScaleIsPositive.Value = true;
            }
            else
            {
                Fsm.Event(eventPositiveScale);
                storeScaleIsPositive.Value = false;
            }


        }


    }
}