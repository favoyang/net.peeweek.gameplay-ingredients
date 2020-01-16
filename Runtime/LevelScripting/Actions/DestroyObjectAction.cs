using NaughtyAttributes;
using UnityEngine;

namespace GameplayIngredients.Actions
{
    public class DestroyObjectAction : ActionBase
    {
        [ReorderableList]
        public GameObject[] ObjectsToDestroy;
        public bool DestroyInstigator = false;
        public bool DestroyCollisionParamObjects = false;
        public override void Execute(GameObject instigator = null, params object[] paramObjects)
        {
            if (ObjectsToDestroy != null )
            {
                foreach(var obj in ObjectsToDestroy)
                    Destroy(obj);
            }

            if(DestroyCollisionParamObjects)
            {
                foreach(var collision in GetParams<Collision>(paramObjects))
                {
                    Destroy(collision.gameObject);
                }
            }

            if(DestroyInstigator && instigator != null)
                Destroy(instigator);
        }
    }
}
