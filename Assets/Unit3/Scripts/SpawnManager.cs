using UnityEngine;

namespace Assets.Unit3.Scripts
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject _obstaclePrefab;

        [SerializeField] private Vector3 _spawnPos = new Vector3(25, 0, 0);
        [SerializeField] private float _startDelay = 2;
        [SerializeField] private float _repeatRate = 2;

        void OnEnable()
        {
            PlayerController.OnGameOver += StopSpawning;
        }
        void OnDisable()
        {
            PlayerController.OnGameOver -= StopSpawning;
        }

        private void Start()
        {
            InvokeRepeating(nameof(SpawnObstacle), _startDelay, _repeatRate);
        }

        private void SpawnObstacle()
        {
            Instantiate(_obstaclePrefab, _spawnPos, _obstaclePrefab.transform.rotation);
        }

        private void StopSpawning()
        {
            // stop the invoking method
            CancelInvoke(nameof(SpawnObstacle));
        }
    }
}