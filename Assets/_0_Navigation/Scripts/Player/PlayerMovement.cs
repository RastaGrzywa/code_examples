using UnityEngine;
using UnityEngine.AI;

namespace _0_Navigation.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        public bool IsMoving => _navMeshAgent.remainingDistance > 0.1f;
        
        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void MoveTo(Vector3 destination)
        {
            _navMeshAgent.destination = destination;
        }
    }
}