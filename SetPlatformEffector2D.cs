// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
// Made by Thore, complementing zeeawk's (SetPlatformEffector2DColliderMask).
// 君達の基地は、全てCATSがいただいた。

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory(ActionCategory.Physics2D)]
    [Tooltip("The action to set almost everything in Platform Effector 2D. To add/remove from Collider Mask, use Platform Effector 2D Collider Mask action.")]
    public class SetPlatformEffector2D : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(PlatformEffector2D))]
        [Tooltip("The GameObject with the PlatformEffector2D attached")]
        public FsmOwnerDefault gameObject;

        [Tooltip("Should the ‘Collider Mask’ property be used? If not then the global collision matrix will be used as is the default for all colliders.")]
        public FsmBool useColliderMask = true;

        [Tooltip("The rotational offset angle from the local 'up'. This allows both the surface and sides to be rotated in local-space.")]
        public FsmFloat rotationalOffset;

        [Tooltip("Should the one-way collision behaviour be used? When true, an object moving up will pass through, but an object moving down will collide (modifable with Rotational Offset)")]
        public FsmBool useOneWay = true;

        [Tooltip("Ensures that all contacts controlled by the one-way behaviour act the same. When true, all collider contacts are disabled when any are disabled.")]
        public FsmBool useOneWayGrouping = false;

        [Tooltip("The angle of an arc that defines the surface of the platform centered of the local 'up' of the effector. Any collision normal with an angle within this arc is never considered for one - way whereas everything outside this arc is considered for one - way. The default defines an arc that includes collisions from the local horizontal to the local vertical.If collisions with the local vertical sides are not required then you can reduce the arc by a few degrees.")]
        public FsmFloat surfaceArc = 180;

        [Tooltip("Should friction be used on the platform sides? When false, a contact on the side uses no friction.When true, any existing friction is used.This is useful to stop friction slowing a Collider2D when in contact with a vertical surface when a force is being applied to keep the Collider2D in contact with the surface.The 'sides' are defined as the edges perpendicular to the 'top' surface(s) in local - space.")]
        public FsmBool useSideFriction = false;

        [Tooltip("Should bounce be used on the platform sides? When false, a contact on the sides uses no bounce.When true, any existing bounce is used.This is useful to stop bouncing of a Collider2D when in contact with a vertical surface.The 'sides' are defined as the edges perpendicular to the 'top' surface(s) in local - space.")]
        public FsmBool useSideBounce = false;

        [Tooltip("The angle of an arc that defines the sides of the platform centered on the local 'left' and 'right' of the effector. Any collision normals within this arc are considered for the 'side' behaviours.Any collision normal with an angle within this arc is always considered for the optional side behaviours, whereas everything outside this arc is never considered for side behaviours.")]
        public FsmFloat sideArc;

        [Tooltip("Reset to default when exiting this state.")]
        public FsmBool resetOnExit;

        PlatformEffector2D pe;

        public override void Reset()
        {
            gameObject = null;
            useColliderMask = true;
            rotationalOffset = 0;
            useOneWay = true;
            useOneWayGrouping = false;
            surfaceArc = 180;
            useSideFriction = false;
            useSideBounce = false;
            sideArc = 0;
            resetOnExit = false;
        }

        public override void OnEnter()
        {
            GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);
            if (go == null) return;

            pe = go.GetComponent<PlatformEffector2D>();
            if (pe != null)
            {
                DoSetPlatformEffector2D();
                Finish();
            }
        }

        void DoSetPlatformEffector2D()
        {
            pe.useColliderMask = useColliderMask.Value;
            pe.rotationalOffset = rotationalOffset.Value;
            pe.useOneWay = useOneWay.Value;
            pe.useOneWayGrouping = useOneWayGrouping.Value;
            pe.surfaceArc = surfaceArc.Value;
            pe.useSideFriction = useSideFriction.Value;
            pe.useSideBounce = useSideBounce.Value;
            pe.sideArc = sideArc.Value;
        }


        public override void OnExit()
        {
            if (pe != null && resetOnExit.Value)
            {
                pe.useColliderMask = true;
                pe.rotationalOffset = 0;
                pe.useOneWay = true;
                pe.useOneWayGrouping = false;
                pe.surfaceArc = 180;
                pe.useSideFriction = false;
                pe.useSideBounce = false;
                pe.sideArc = 0;

            }

        }

      
    }
}