using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory("Sprite")]
    [Tooltip("Set the 'Order in Layer' property in a SVG Importer SpriteRenderer. Note: the original SVG Importer paid asset, not Unity's that is in development.")]
    public class SVGSetOrderInLayer : FsmStateAction
    {
        [RequiredField]
        [CheckForComponent(typeof(SVGImporter.SVGRenderer))]
        [Tooltip("The GameObject with the Sprite")]
        public FsmOwnerDefault gameObject;
        public FsmInt OrderInLayer;
        private SVGImporter.SVGRenderer sprite;



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
            sprite = go.GetComponent<SVGImporter.SVGRenderer>();

            sprite.sortingOrder = OrderInLayer.Value;
            Finish();
        }


    }

}


