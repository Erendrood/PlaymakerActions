// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
// Created by Thor (Thore) Erendrood
// change anything you like, but consult your pineal gland.


using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.Input)]
    [Tooltip("AxisRaw value set to Velocity2D, option to fire events based on direction, and more. This is the snappy version. For the smooth twin, see AxisToVelocity2D.")]
    public class AxisRawToVelocity2D : ComponentAction<Rigidbody2D>
    {

        [RequiredField]
        [CheckForComponent(typeof(Rigidbody2D))]
        [Tooltip("The GameObject with the Rigidbody2D attached")]
        public FsmOwnerDefault gameObject;

        [RequiredField]
        [Tooltip("The name of the axis. Set in the Unity Input Manager.")]
        public FsmString axisName;

        public enum AxisOrientation
        {
            Horizontal,
            Vertical,
        }

        [Tooltip("Should the axis change velocity.x or velocity.y?")]
        public AxisOrientation axisOrientation;
     
        [UIHint(UIHint.Variable)]
        [Tooltip("Store the axis value as absolute, e.g. to set animator float")]
        public FsmFloat storeAxisAbs;

        [Tooltip("Axis values are either -1, 0, or +1. For more velocity, you typically need to multiply it. Try 5.")]
        public FsmFloat multiplier;

        [Tooltip("When the axis is in neutral position, don't change velocity. Object is only affected by settings in rigidbody (think momentum/inertia). Useful for physics objects, thruster, on joints etc.")]
        public FsmBool hasNeutral;

       [Tooltip("The space reference to express the velocity")] 
        public Space space;

        private Vector2 velocity;

        [ActionSection("Events")]

        [Tooltip("Event to send if 'Positive Button' is pressed (e.g. right or up).")]
        public FsmEvent eventPositiveButton;

        [Tooltip("Event to send if the 'Negative Button' is pressed (e.g. down or left).")]
        public FsmEvent eventNegativeButton;

        [Tooltip("Repeat every frame.")]
        public bool everyFrame;



        public override void Awake()
        {
            Fsm.HandleFixedUpdate = true;
        }

        public override void Reset()
        {
            axisName = "";
            everyFrame = false;
            velocity = new Vector2(0,0);
            multiplier = 0f;
            storeAxisAbs = null;
            space = Space.World; 

        }

        public override void OnFixedUpdate()
        {
            DoAxisToVelocity();

            if (!everyFrame)
            {
                Finish();
            }
        }


        void DoAxisToVelocity()
        {
            if (FsmString.IsNullOrEmpty(axisName)) return;
            var axisValue = Input.GetAxisRaw(axisName.Value);
            storeAxisAbs.Value = Mathf.Abs(axisValue);

            // Velocity Part

            var go = Fsm.GetOwnerDefaultTarget(gameObject);

            if (!UpdateCache(go))
            {
                return;
            }

            var velocity = rigidbody2d.velocity;

            if (space == Space.Self)
            {
                velocity = rigidbody2d.transform.InverseTransformDirection(velocity);
            }

            // override any axis

            if (axisOrientation == AxisOrientation.Vertical)
            {
               velocity.y = axisValue * multiplier.Value;


            }

            else
            {
                velocity.x = axisValue * multiplier.Value;

            }


            // apply

         
            if (hasNeutral.Value && Input.GetAxisRaw(axisName.Value) == 0)
            {
                // Don't set velocity when hasNeutral is true, and the axis is zeroed.
            }

    
            else          
            {
                rigidbody2d.velocity = velocity;
            }



            // Event Switch


            if (Input.GetAxisRaw(axisName.Value) > 0)
            {
                Fsm.Event(eventPositiveButton);

            }
            else if (Input.GetAxisRaw(axisName.Value) < 0)
            {
                Fsm.Event(eventNegativeButton);

            }

            if (!everyFrame)
            {
                Finish();
            }
           


        } // Method


    } // Class

} // Namespace

