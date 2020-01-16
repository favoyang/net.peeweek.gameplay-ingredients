using NaughtyAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace GameplayIngredients.Logic
{
    public class NextFrameLogic : LogicBase
    {
        [ReorderableList]
        public Callable[] OnNextFrame;
        IEnumerator m_Coroutine;

        public override void Execute(GameObject instigator = null, params object[] paramObjects)
        {
            m_Coroutine = RunDelay(instigator, paramObjects);
            StartCoroutine(m_Coroutine);
        }

        IEnumerator RunDelay(GameObject instigator = null, params object[] paramObjects)
        {
            yield return new WaitForEndOfFrame();
            Callable.Call(OnNextFrame, instigator, paramObjects);
            m_Coroutine = null;
        }
    }
}

