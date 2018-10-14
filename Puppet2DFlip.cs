// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.
/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/
// Created by Thor (Thore) Erendrood
// For use with Puppet2D Asset

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	
	[ActionCategory(ActionCategory.Animation)]
	[Tooltip("Flip character using the Puppet2D Flip variable")]
	public class Puppet2DFlip : FsmStateAction
		{
			Puppet2D_GlobalControl script; 
			public FsmGameObject globalCTRL;
			public FsmBool flip;
				
				public override void OnEnter()
				{	
				script = globalCTRL.Value.GetComponent<Puppet2D_GlobalControl>();	
				script.flip = flip.Value;
				Finish();
				}
		}

}
