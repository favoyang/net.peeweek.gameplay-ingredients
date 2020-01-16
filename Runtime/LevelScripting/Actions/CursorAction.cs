using UnityEngine;

namespace GameplayIngredients.Actions
{
    public class CursorAction : ActionBase
    {
        public CursorLockMode LockState = CursorLockMode.None;
        public bool CursorVisible = true;

        public override void Execute(GameObject instigator = null, params object[] paramObjects)
        {
            Cursor.lockState = LockState;
            Cursor.visible = CursorVisible;
        }
    }
}

