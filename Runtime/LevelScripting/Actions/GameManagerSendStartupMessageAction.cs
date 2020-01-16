using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameplayIngredients.Actions
{
    public class GameManagerSendStartupMessageAction : ActionBase
    {
        public enum MessageType
        {
            MainMenuStart,
            GameLevelStart,
        }

        public MessageType messageType;

        public override void Execute(GameObject instigator = null, params object[] paramObjects)
        {
            switch(messageType)
            {
                case MessageType.GameLevelStart:
                    Messager.Send(GameManager.GameLevelStartMessage, instigator, paramObjects);
                    break;
                case MessageType.MainMenuStart:
                    Messager.Send(GameManager.MainMenuStartMessage, instigator, paramObjects);
                    break;
            }
        }
    }
}
