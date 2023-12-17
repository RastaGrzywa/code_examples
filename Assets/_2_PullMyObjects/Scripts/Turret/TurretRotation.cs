using UnityEngine;

namespace _2_PullMyObjects.Scripts.Turret
{
    public class TurretRotation : MonoBehaviour
    {
        private void Start()
        {
            LeanTween.rotateAround(gameObject, Vector3.up, 90f, 3f).setLoopPingPong();
        }
    }
}