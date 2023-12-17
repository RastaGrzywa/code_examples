using UnityEngine;

namespace _2_PullMyObjects.Scripts.Standard
{
    public class Bullet : MonoBehaviour
    {
        private void OnEnable()
        {
            Invoke(nameof(DisableBullet), 10f);
        }
        
        private void DisableBullet()
        {
            Destroy(gameObject);
        }
    }
}