using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
