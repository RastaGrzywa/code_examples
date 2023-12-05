using System;
using System.Collections.Generic;
using _0_Navigation.Scripts.Player;
using UnityEngine;

namespace _0_Navigation.Scripts.Commands
{
    public class MoveCommand : ICommand
    {
        private PlayerMovement _playerMovement;
        private Vector3 _moveToPosition;

        public event Action OnFinished = delegate { };
        private bool _isFinished;
        
        public MoveCommand(PlayerMovement playerMovement, Vector3 moveToPosition)
        {
            _playerMovement = playerMovement;
            _moveToPosition = moveToPosition;
        }


        public void Execute(List<ICommand> commands)
        {
            _playerMovement.MoveTo(_moveToPosition);
            Debug.Log("Start executing command");
        }

        public void Update()
        {
            if (_isFinished)
            {
                return;
            }
            
            if (_playerMovement.IsMoving == false)
            {
                Finish();
            }
        }


        public void Finish()
        {
            Debug.Log("Finished executing command");
            _isFinished = true;
            OnFinished.Invoke();
        }
        
    }
}