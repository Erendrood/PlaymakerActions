// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
// Created by Thor (Thore) Erendrood


using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory(ActionCategory.GameObject)]
    [Tooltip("Sets the Parent of a Game Object.")]
    public class SetParent3 : FsmStateAction
    {
        [RequiredField]
        [Tooltip("The Game Object to parent.")]
        public FsmOwnerDefault gameObject;

        [Tooltip("The new parent for the Game Object.")]
        public FsmGameObject parent;

        
        public override void Reset()
        {
            gameObject = null;
            parent = null;
  
        }

        public override void OnEnter()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);

            if (go != null)
            {
              go.transform.transform.SetParent(parent.Value.transform, false);

            }

            Finish();
        }
    }
}
