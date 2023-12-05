using System.Collections.Generic;
using _0_Navigation.Scripts.UI;
using UnityEngine;

namespace _0_Navigation.Scripts.Commands
{
    public class CommandInvoker : MonoBehaviour
    {
        private List<ICommand> _commands = new();

        private ICommand _currentCommand;

        private void Update()
        {
            if (_commands.Count == 0)
            {
                return;
            }
            
            _commands[0].Update();
        }

        private void ExecuteNextCommand()
        {
            if (_commands.Count == 0)
            {
                return;
            }
            _commands[0].Execute(_commands);
            _commands[0].OnFinished += () =>
            {
                RemoveCommand(0);
                ExecuteNextCommand();
            };
        }
        
        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
            Debug.Log("Command added");
            if (_commands.Count == 1)
            {
                ExecuteNextCommand();
            }
        }

        public void RemoveCommand(ICommand command)
        {
            RemoveCommand(_commands.IndexOf(command));
        }

        private void RemoveCommand(int id)
        {
            _commands.RemoveAt(id);
            Debug.Log("Command removed");
        }

    }
}