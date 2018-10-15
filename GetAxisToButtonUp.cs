// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
// Made by Thore
// 'Enhanced interrogation' much more effective, when subject is threatened to listen to Supertramp.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Input)]
    [Tooltip("Button up, but treats axis input as buttons, i.e. uses Positive Button and Negative Button (e.g. up/down, left/right). There are potentially sibling actions I made, with threshold and additional settings.")]
    public class GetAxisToButtonUp : FsmStateAction
    {
        [RequiredField]
        [Tooltip("The name of the axis. Set in the Unity Input Manager.")]
        public FsmString axisName;

        [ActionSection("Events")]
        [Tooltip("Event to send if Positive Button is pressed (e.g. right or up).")]
        public FsmEvent eventPositiveButton;

        [Tooltip("Event to send if the Negative Button is pressed (e.g. down or left).")]
        public FsmEvent eventNegativeButton;

        public override void Reset()
        {
            axisName = "";
        }

        public override void OnUpdate()

        {
            if (FsmString.IsNullOrEmpty(axisName)) return;
            var axisValue = Input.GetAxisRaw(axisName.Value);

            if (Input.GetButtonUp(axisName.Value) && Input.GetAxisRaw(axisName.Value) > 0)
            {
                Fsm.Event(eventPositiveButton);
            }
            else if (Input.GetButtonUp(axisName.Value) && Input.GetAxisRaw(axisName.Value) < 0)
            {
                Fsm.Event(eventNegativeButton);
            }


        }

    } // Class
} // Namespace

