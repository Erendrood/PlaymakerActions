// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by Thore
// Same as the other action, but with storing function.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Input)]
    [Tooltip("Button up, but treats axis input as buttons, i.e. uses Positive Button and Negative Button (e.g. up/down, left/right).")]
    public class GetAxisToButtonUp : FsmStateAction
    {
        [RequiredField]
        [Tooltip("The name of the axis. Set in the Unity Input Manager.")]
        public FsmString axisName;

        [Tooltip("Set to True if the button is pressed.")]
        [UIHint(UIHint.Variable)]
        public FsmBool storePositiveReleased;

        [Tooltip("Set to True if the button is pressed.")]
        [UIHint(UIHint.Variable)]
        public FsmBool storeNegativeReleased; 

        [ActionSection("Events")]
        [Tooltip("Event to send if Positive Button is pressed (e.g. right or up).")]
        public FsmEvent eventPositiveButton;

        [Tooltip("Event to send if the Negative Button is pressed (e.g. down or left).")]
        public FsmEvent eventNegativeButton;

        public override void Reset()
        {
            axisName = "";
            // storePositiveReleased = null;
            // storeNegativeReleased = null;
        }

        public override void OnUpdate()

        {
            if (FsmString.IsNullOrEmpty(axisName)) return;
            var axisValue = Input.GetAxisRaw(axisName.Value);

            if (Input.GetButtonUp(axisName.Value) && Input.GetAxisRaw(axisName.Value) > 0)
            {
                Fsm.Event(eventPositiveButton);
                storePositiveReleased.Value = true;
                storeNegativeReleased.Value = false;
            }
            else if (Input.GetButtonUp(axisName.Value) && Input.GetAxisRaw(axisName.Value) < 0)
            {
                Fsm.Event(eventNegativeButton);
                storePositiveReleased.Value = false;
                storeNegativeReleased.Value = true;
            }


        }

    } // Class
} // Namespace

