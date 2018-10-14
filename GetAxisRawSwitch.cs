// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
// Adapted from GetAxis by : Thor (Thore) Erendrood
// Nevermind the neverminders.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Input)]
    [Tooltip("Gets an Axis and stores it in a Float Variable. With bool to switch between raw and smooth. See Unity Input Manager docs and Input.GetAxis and Input.GetAxisRaw.")]
    public class GetAxisRawSwitch : FsmStateAction
    {
        [RequiredField]
        [Tooltip("The name of the axis. Set in the Unity Input Manager.")]
        public FsmString axisName;

        [Tooltip("Axis values are in the range -1 to 1. Use the multiplier to set a larger range.")]
        public FsmFloat multiplier;

        [Tooltip("Turns off smoothing for snappier control. Axis values are either -1 or 1.")]
        public FsmBool useRaw;
     
        [RequiredField]
        [UIHint(UIHint.Variable)]
        [Tooltip("Store the result in a float variable.")]
        public FsmFloat store;

        [Tooltip("Repeat every frame. Typically this would be set to True.")]
        public bool everyFrame;

        public override void Reset()
        {
            axisName = "";
            multiplier = 1.0f;
            store = null;
            everyFrame = true;
        }

        public override void OnEnter()
        {
          
            DoAxis();

            if (!everyFrame)
            {
                Finish();
            }
        }

        public override void OnUpdate()
        {

            DoAxis();

        }

        void DoAxis()
        {

            if (!useRaw.Value)
            {
                DoGetAxis();
            }
            else
            {
                DoGetAxisRaw();
            }


        }

        void DoGetAxis()
        {
            if (FsmString.IsNullOrEmpty(axisName)) return;

            var axisValue = Input.GetAxis(axisName.Value);

            // if variable set to none, assume multiplier of 1
            if (!multiplier.IsNone)
            {
                axisValue *= multiplier.Value;
            }

            store.Value = axisValue;
        }

        void DoGetAxisRaw()
        {
            if (FsmString.IsNullOrEmpty(axisName)) return;

            var axisValue = Input.GetAxisRaw(axisName.Value);

            // if variable set to none, assume multiplier of 1
            if (!multiplier.IsNone)
            {
                axisValue *= multiplier.Value;
            }

            store.Value = axisValue;
        }
    }
}

