using _0_Navigation.Scripts.Commands;
using _0_Navigation.Scripts.UI;
using UnityEngine;

namespace _0_Navigation.Scripts.Player
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] 
        private GameObject clickVfxPrefab;
        
        [SerializeField]
        private CommandInvoker playerCommandInvoker;

        [SerializeField] 
        private CommandsVisuals commandsVisuals;
        
        private Camera _camera;
        private PlayerMovement _playerMovement;

        
        private void Awake()
        {
            _camera = Camera.main;
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnMouseClicked();
            }
        }

        private void OnMouseClicked()
        {
            var position = Input.mousePosition;
            var ray = _camera.ScreenPointToRay(position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            { 
                var command = new MoveCommand(_playerMovement, hit.point);
                playerCommandInvoker.AddCommand(command);
                commandsVisuals.SpawnNewButton(playerCommandInvoker, command);
                Instantiate(clickVfxPrefab, hit.point, Quaternion.identity);
            }
        }
    }
}
