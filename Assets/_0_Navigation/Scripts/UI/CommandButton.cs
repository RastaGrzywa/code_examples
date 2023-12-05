using System;
using _0_Navigation.Scripts.Commands;
using UnityEngine;
using UnityEngine.UI;

namespace _0_Navigation.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class CommandButton : MonoBehaviour
    {
        private Button _button;
        private CommandInvoker _commandInvoker;
        private ICommand _command;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClicked);
        }

        public void Initialize(CommandInvoker commandInvoker, ICommand command)
        {
            _commandInvoker = commandInvoker;
            _command = command;
            _command.OnFinished += () =>
            {
                Destroy(gameObject);
            };
        }

        private void OnButtonClicked()
        {
            _commandInvoker.RemoveCommand(_command);
            Destroy(gameObject);
        }
    }
}