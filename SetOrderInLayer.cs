// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
// Created by Thor (Thore) Erendrood // http://hutonggames.com/playmakerforum/index.php?topic=19379
// Any of my actions may be cause of a Guru Medidation.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("Sprite")]
	[Tooltip("Set the 'Order in Layer' property in a SpriteRenderer.")]
	public class SetOrderInLayer : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(SpriteRenderer))]
		[Tooltip("The GameObject with the Sprite")]
		public FsmOwnerDefault gameObject;
		public FsmInt OrderInLayer;
		private SpriteRenderer sprite;



		public override void Reset()
		{

			gameObject = null;
			OrderInLayer = null;
			sprite = null;

		}


		// Code that runs on entering the state.
		public override void OnEnter()
		{

			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			sprite = go.GetComponent<SpriteRenderer> ();

			sprite.sortingOrder = OrderInLayer.Value;
			Finish();
		}


	}

}


