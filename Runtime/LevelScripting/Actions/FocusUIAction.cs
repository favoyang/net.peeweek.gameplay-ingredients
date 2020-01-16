using UnityEngine;
using UnityEngine.UI;

namespace GameplayIngredients.Actions
{
    public class FocusUIAction : ActionBase
    {
        public Selectable UIObjectToFocus;

        public override void Execute(GameObject instigator = null, params object[] paramObjects)
        {
            if (UIObjectToFocus != null)
            {
                UIObjectToFocus.Select();
            }
        }
    }
}
