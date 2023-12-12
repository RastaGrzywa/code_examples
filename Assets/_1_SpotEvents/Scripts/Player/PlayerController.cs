using System;
using UnityEngine;

namespace _1_SpotEvents.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        private float _speed = 9f;
        private CharacterController _characterController;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
            _characterController.SimpleMove(movement * _speed);
        }
    }
}