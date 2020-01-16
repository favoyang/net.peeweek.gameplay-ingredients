using UnityEngine;

namespace GameplayIngredients.Actions
{
    public class ApplicationExitAction : ActionBase
    {
        public override void Execute(GameObject instigator = null, params object[] paramObjects)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }
}

