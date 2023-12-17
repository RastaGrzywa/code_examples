using UnityEngine;

namespace _2_PullMyObjects.Scripts.ObjectPool
{
    public class OPBullet : MonoBehaviour
    {
        private void OnEnable()
        {
            Invoke(nameof(DisableBullet), 10f);
            
        }
        
        private void DisableBullet()
        {
            Scripts.ObjectPool.ObjectPool.Instance.ReturnBullet(gameObject);
        }
    }
}