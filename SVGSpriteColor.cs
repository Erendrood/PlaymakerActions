// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
// Created by Thor (Thore) Erendrood
// Don't trust any advice that begins with //

using UnityEngine;
using SVGImporter;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("Sprite")]
	[Tooltip("Set the color property in a SVG SpriteRenderer (paid asset, SVG Importer).")]
	public class SVGSpriteColor : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(SVGImporter.SVGRenderer))]
		[Tooltip("The GameObject with the SVG Sprite / SVG Importer")]
		public FsmOwnerDefault gameObject;
		public FsmColor color;
		private SVGImporter.SVGRenderer sprite;

        		public override void Reset()
		{

			gameObject = null;
			color = null;
			sprite = null;

		}


		// Code that runs on entering the state.
		public override void OnEnter()
		{

			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			sprite = go.GetComponent<SVGImporter.SVGRenderer> ();

			sprite.color = color.Value;
			Finish();
		}


	}

}


