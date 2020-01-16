using NaughtyAttributes;
using System.Collections;
using UnityEngine;
namespace GameplayIngredients.Logic
{
    public class DelayedLogic : LogicBase
    {
        public enum DelayMode { Constant, Random };
        public DelayMode delayMode;
        [ShowIf("DelayIsConstant")]
        public float Delay = 1.0f;
        [ShowIf("DelayIsRandom")]
        public Vector2 DelayRange = Vector2.one;
        [ReorderableList]
        public Callable[] OnDelayComplete;
        [ReorderableList]
        public Callable[] OnCanceled;
        IEnumerator m_Coroutine;
        private void OnValidate()
        {
            if (DelayIsConstant())
                DelayRange = new Vector2(Delay, Delay + 1);
        }
        private bool DelayIsRandom()
        {
            bool random = delayMode == DelayMode.Random ? true : false;
            return random;
        }
        private bool DelayIsConstant() { return !DelayIsRandom(); }
        public void Cancel(GameObject instigator = null)
        {
            if (m_Coroutine != null)
            {
                StopCoroutine(m_Coroutine);
                Callable.Call(OnCanceled, instigator);
                m_Coroutine = null;
            }
        }
        public override void Execute(GameObject instigator = null, params object[] paramObjects)
        {
            float newDelay;
            if (m_Coroutine != null) Cancel();
            if (delayMode == DelayMode.Random)
                newDelay = Random.Range(DelayRange.x, DelayRange.y);
            else
                newDelay = Delay;
            m_Coroutine = RunDelay(newDelay, instigator, paramObjects);
            StartCoroutine(m_Coroutine);
        }
        IEnumerator RunDelay(float Seconds, GameObject instigator = null, params object[] paramObjects)
        {
            yield return new WaitForSeconds(Seconds);
            Callable.Call(OnDelayComplete, instigator, paramObjects);
            m_Coroutine = null;
        }
    }
}