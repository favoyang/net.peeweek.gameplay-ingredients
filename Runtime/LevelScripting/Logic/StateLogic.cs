using GameplayIngredients.StateMachines;
using NaughtyAttributes;
using UnityEngine;

namespace GameplayIngredients.Logic
{
    public class StateLogic : LogicBase
    {
        public StateMachine StateMachine;
        public State TargetState;

        [ReorderableList]
        public Callable[] IfCurrentState;
        [ReorderableList]
        public Callable[] IfNotCurrentState;

        public override void Execute(GameObject instigator = null, params object[] paramObjects)
        {
            if (StateMachine.CurrentState == TargetState && IfCurrentState != null && IfCurrentState.Length > 0)
                Call(IfCurrentState, instigator, paramObjects);
            else if (StateMachine.CurrentState != TargetState && IfNotCurrentState != null && IfNotCurrentState.Length > 0)
                Call(IfNotCurrentState, instigator, paramObjects);
        }
    }

}

