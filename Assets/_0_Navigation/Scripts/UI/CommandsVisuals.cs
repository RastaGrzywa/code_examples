using _0_Navigation.Scripts.Commands;
using UnityEngine;

namespace _0_Navigation.Scripts.UI
{
    public class CommandsVisuals : MonoBehaviour
    {
        [SerializeField] 
        private CommandButton commandButtonPrefab;

        [SerializeField] 
        private Transform buttonsParent;

        public GameObject SpawnNewButton(CommandInvoker commandInvoker, ICommand command)
        {
            var commandButton = Instantiate(commandButtonPrefab, buttonsParent);
            commandButton.Initialize(commandInvoker, command);
            return commandButton.gameObject;
        }
    }
}