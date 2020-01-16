using UnityEngine;

namespace GameplayIngredients.Actions
{
    public class SendMessageAction : ActionBase
    {
        public string MessageToSend = "Message";

        public override void Execute(GameObject instigator = null, params object[] paramObjects)
        {
            Messager.Send(MessageToSend, instigator, paramObjects);
        }
    }
}


