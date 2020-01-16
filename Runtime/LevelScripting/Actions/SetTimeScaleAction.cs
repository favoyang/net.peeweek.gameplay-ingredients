using UnityEngine;

namespace GameplayIngredients.Actions
{
    public class SetTimeScaleAction : ActionBase
    {
        public float TimeScale = 1.0f;

        public override void Execute(GameObject instigator = null, params object[] paramObjects)
        {
            Time.timeScale = TimeScale;
        }

        public void SetTimeScale(float value)
        {
            TimeScale = value;
            Execute();
        }
    }
}
