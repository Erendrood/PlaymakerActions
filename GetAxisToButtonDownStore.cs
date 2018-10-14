// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made by Thore: change anything you like, but if you do, mind the squirrels.


using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Input)]
    [Tooltip("Treat the axis input as buttons, i.e. uses Positive Button and Negative Button (e.g. up/down, left/right). There are potentially sibling actions I made, with threshold and additional settings.")]
    public class GetAxisToButtonDownStore : FsmStateAction
    {
        [RequiredField]
        [Tooltip("The name of the axis. Set in the Unity Input Manager.")]
        public FsmString axisName;

        [Tooltip("Set to True if the button is pressed.")]
        [UIHint(UIHint.Variable), Readonly]
        public FsmBool storePositivePressed;

        [Tooltip("Set to True if the button is pressed.")]
        [UIHint(UIHint.Variable), Readonly]
        public FsmBool storeNegativePressed; 
    
        [Tooltip("Event to send if Positive Button is pressed (e.g. right or up).")]
        public FsmEvent eventPositiveButton;

        [Tooltip("Event to send if the Negative Button is pressed (e.g. down or left).")]
        public FsmEvent eventNegativeButton;

        public override void Reset()
        {
           axisName = "";
           storePositivePressed = null;
           storeNegativePressed = null;
        }

        public override void OnUpdate()

        {
            if (FsmString.IsNullOrEmpty(axisName)) return;
            var axisValue = Input.GetAxisRaw(axisName.Value);

            if (Input.GetButtonDown(axisName.Value) && Input.GetAxisRaw(axisName.Value) > 0)
            {
                Fsm.Event(eventPositiveButton);
                storePositivePressed.Value = true;
                storeNegativePressed.Value = false;
            }
            else if (Input.GetButtonDown(axisName.Value) && Input.GetAxisRaw(axisName.Value) < 0)
            {
                Fsm.Event(eventNegativeButton);
                storePositivePressed.Value = false;
                storeNegativePressed.Value = true;
            }


        }

    } // Class
} // Namespace

