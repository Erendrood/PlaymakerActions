// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
// Created by : Thor (Thore) Erendrood
// Thomas Moore is one of my favourite Monty Python sketches. Maybe not all-time-favourite, but up there with the other very good sketches. At least most of the time.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Input)]
	[Tooltip("When a Button is pressed, sends an event based on axis direction.")]
	public class GetButtonDownAndAxis : FsmStateAction
	{
		[RequiredField]
        [Tooltip("The name of the button. Set in the Unity Input Manager.")]
		public FsmString buttonName;

        [RequiredField]
        [Tooltip("The name of the axis. Set in the Unity Input Manager.")]
        public FsmString axisName;

        [Tooltip("Event to send when button is pressed and direction is positive (e.g. right or up).")]
        public FsmEvent eventPositiveButton;

        [Tooltip("Event to send when button is pressed and direction is negative (e.g. down or left).")]
        public FsmEvent eventNegativeButton;
        
        public override void Reset()
		{
			buttonName = "Fire1";
            axisName = "";
	     		
		}

		public override void OnUpdate()
		{
            // Error Handling
            if (FsmString.IsNullOrEmpty(axisName)) return;

            // Listen for Button AND direction.
            var buttonDown = Input.GetButtonDown(buttonName.Value);
            var axisValue = Input.GetAxisRaw(axisName.Value);

            if (buttonDown)
            {

               if (Input.GetAxisRaw(axisName.Value) > 0)             
                {
                Fsm.Event(eventPositiveButton);
                }
               else if (Input.GetAxisRaw(axisName.Value) < 0)
                {
                Fsm.Event(eventNegativeButton);
                }

            }

        }


        
	} // Class
} // Namespace
