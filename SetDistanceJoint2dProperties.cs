// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
// Made By Thore with Five Tons of Flax.

using System;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Physics2D)]
	[Tooltip("Sets the various properties of a HingeJoint2d component")]
	public class SetDistanceJoint2dProperties : FsmStateAction
	{

        [Tooltip("Check this box to enable collision between the two connected GameObjects")]
        public FsmBool enableCollision;

        [RequiredField]
		[Tooltip("The DistanceJoint2D object")]
		[CheckForComponent(typeof(DistanceJoint2D))]
		public FsmOwnerDefault gameObject;
                
        [CheckForComponent(typeof(Rigidbody2D))]
        [Tooltip("Use this field to specify the other GameObject that this Distance Joint 2D connects to. If ths is left as None (Rigidbody 2D), the other end of the Distance Joint 2D is fixed at a point in space defined by the Connected Anchor setting.")]
        public FsmGameObject connectedRigidBody; 

        [Tooltip("Check this box to automatically set the anchor location for the other GameObject this Distance Joint 2D connects to. If you enable this, you don’t need to complete the Connected Anchor fields.")]
        public FsmBool autoConfigureConnectedAnchor;

        [Tooltip("Define where (x/y coordinate on the Rigidbody 2D) the end point of the Distance Joint 2D connects to this GameObject.")]
        public FsmVector2 anchor;

        [Tooltip("Define where (x/y coordinate on the Rigidbody 2D) the end point of the Distance Joint 2D connects to this GameObject.")]
        public FsmVector2 connectedAnchor;
        
        [Tooltip("Check this box to automatically detect the current distance between the two GameObjects, and set it as the distance that the Distance Joint 2D keeps between the two GameObjects. If you enable this, you don’t need to complete the Distance field.")]
        public FsmBool autoConfigureDistance;

        [Tooltip("Specify the distance that the Distance Joint 2D keeps between the two GameObjects.")]
        public FsmFloat distance;

        [Tooltip("If enabled, the Distance Joint 2D only enforces a maximum distance, so the connected GameObjects can still move closer to each other, but not further than the Distance field defines. If this is not enabled, the distance between the GameObjects is fixed.")]
        public FsmBool maxDistanceOnly;
              
        [Tooltip("Specify the force level needed to break and therefore delete the Distance Joint 2D.")]
        public FsmFloat breakForce;
        [Tooltip("Infinity means it is unbreakable. If set, overrides Break Force.")]
        public FsmBool setBreakForceInfinty;
        
        [Tooltip("Repeat every frame while the state is active.")]
        public bool everyFrame = false;
               
        [Tooltip("Enable or disable Distance Joint.")] 
        public FsmBool enabled = true;

        DistanceJoint2D _joint;
        GameObject go;

        public override void Reset()
        {

            enableCollision = new FsmBool() { UseVariable = false };
            connectedRigidBody = null;
            autoConfigureConnectedAnchor = null;
            anchor = new Vector2(); // something missing?
            connectedAnchor = new Vector2(); // something missing?
            autoConfigureDistance = new FsmBool() { UseVariable = false };
            distance = new FsmFloat() { UseVariable = false };
            maxDistanceOnly = new FsmBool() { UseVariable = false };
            breakForce = new FsmFloat() { UseVariable = false };
            setBreakForceInfinty = new FsmBool() { UseVariable = false };
            everyFrame = false;
            enabled = true;

        }

        public override void OnEnter()
        {
            go = Fsm.GetOwnerDefaultTarget(gameObject);

            if (go != null)
            {
                _joint = go.GetComponent<DistanceJoint2D>();
 
            }

            if (!enabled.Value)
            {
                _joint.enabled = !_joint.enabled;
            }

            SetProperties();

            if (!everyFrame)
            {
                Finish();
            }
        
        }

        private T GetComponent<T>()
        {
            throw new NotImplementedException();
        }

        public override void OnUpdate()
        {
            SetProperties();
        }

        void SetProperties()
        {
            if (_joint == null)
            {
                return;
            }

            // Set the Stuff

            if (!enableCollision.IsNone)
            {
                _joint.enableCollision = enableCollision.Value;
            }

            if (connectedRigidBody != null) 
            {
                _joint.connectedBody = connectedRigidBody.Value.GetComponent<Rigidbody2D>();
                
            }

            if (!autoConfigureConnectedAnchor.IsNone)
            {
                _joint.autoConfigureConnectedAnchor = autoConfigureConnectedAnchor.Value;
            }
            
            if (!anchor.IsNone)
            {
                _joint.anchor = anchor.Value;
            }

            if (!connectedAnchor.IsNone)
            {
                _joint.connectedAnchor = connectedAnchor.Value;
            }

            if (!autoConfigureDistance.IsNone)
            {
                _joint.autoConfigureDistance = autoConfigureDistance.Value;
            }

            if (!distance.IsNone)
            {
                _joint.distance = distance.Value;
            }

            if (!maxDistanceOnly.IsNone)
            {
                _joint.maxDistanceOnly = maxDistanceOnly.Value;
            }

            if (!autoConfigureConnectedAnchor.IsNone)
            {
                _joint.breakForce = breakForce.Value;
            }

            if (!setBreakForceInfinty.IsNone)
            {
                _joint.breakForce = Mathf.Infinity;
            }

        } // END METHOD

    } // END CLASS
} // END NAMESPACE