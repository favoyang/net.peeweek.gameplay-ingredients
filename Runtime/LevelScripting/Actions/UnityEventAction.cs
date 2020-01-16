using UnityEngine;
using UnityEngine.Events;

namespace GameplayIngredients.Actions
{
    public class UnityEventAction : ActionBase
    {
        public UnityEvent OnExecute;

        public override void Execute(GameObject instigator = null, params object[] paramObjects)
        {
            OnExecute.Invoke();
        }
    }
}
