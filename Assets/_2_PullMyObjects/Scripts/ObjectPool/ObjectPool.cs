using System.Collections.Generic;
using UnityEngine;

namespace _2_PullMyObjects.Scripts.ObjectPool
{
    public class ObjectPool : MonoBehaviour
    {
        public static ObjectPool Instance;

        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private int poolSize = 10;

        private readonly Queue<GameObject> _bulletPool = new Queue<GameObject>();

        private void Awake()
        {
            Instance = this;
            InitializePool();
        }

        private void InitializePool()
        {
            for (var i = 0; i < poolSize; i++)
            {
                var bullet = Instantiate(bulletPrefab);
                bullet.SetActive(false);
                _bulletPool.Enqueue(bullet);
            }
        }

        public GameObject GetBullet(Vector3 position, Quaternion rotation)
        {
            if (_bulletPool.Count == 0)
            {
                ExpandPool();
            }

            var bullet = _bulletPool.Dequeue();
            bullet.transform.position = position;
            bullet.transform.rotation = rotation;
            bullet.SetActive(true);

            return bullet;
        }

        public void ReturnBullet(GameObject bullet)
        {
            bullet.SetActive(false);
            _bulletPool.Enqueue(bullet);
        }

        private void ExpandPool()
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            _bulletPool.Enqueue(bullet);
        }
    }
}