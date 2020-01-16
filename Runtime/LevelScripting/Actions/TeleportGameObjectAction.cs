using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameplayIngredients.Actions
{
    public class TeleportGameObjectAction : ActionBase
    {
        [ReorderableList]
        public GameObject[] ObjectsToTeleport;
        public bool TeleportInstigator = false;
        public bool TeleportToFirstCollisionParam = false;

        public Transform TeleportTarget;

        public override void Execute(GameObject instigator = null, params object[] paramObjects)
        {
            if(TeleportTarget == null)
            {
                Debug.LogWarning("No Teleport Target");
                return;
            }
            if(ObjectsToTeleport != null)
            {
                foreach(var obj in ObjectsToTeleport)
                {
                    Teleport(obj, TeleportTarget.position, TeleportTarget.rotation);
                }
            }
            var position = TeleportTarget.position;
            var rotation = TeleportTarget.rotation;

            if(TeleportToFirstCollisionParam)
            {
                var collision = GetParam<Collision>(paramObjects);
                if(collision != null)
                {
                    position = collision.gameObject.transform.position;
                    rotation = collision.gameObject.transform.rotation;
                }
            }


            if (TeleportInstigator && instigator != null)
                Teleport(instigator, position, rotation);
        }

        static void Teleport(GameObject obj, Vector3 worldPosition, Quaternion rotation)
        {
            obj.transform.position = worldPosition;
            obj.transform.rotation = rotation;
        }
    }
}
