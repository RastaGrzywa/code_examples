using UnityEngine;

namespace _2_PullMyObjects.Scripts.Standard
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private float bulletsPerMinute;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform spawnTransform;

        private float _timer;
        private float _spawnTime;

        private void Start()
        {
            _spawnTime = 60f / bulletsPerMinute;
        }

        private void Update()
        {
            if (_timer > _spawnTime)
            {
                _timer = 0;
                SpawnBullet();
            }

            _timer += Time.deltaTime;
        }

        private void SpawnBullet()
        {
            var bullet = Instantiate(bulletPrefab, spawnTransform.position, Quaternion.identity);
            bullet.transform.up = spawnTransform.forward;
            bullet.GetComponent<Rigidbody>().AddForce(spawnTransform.forward * 50, ForceMode.Impulse);
        }
    }
}