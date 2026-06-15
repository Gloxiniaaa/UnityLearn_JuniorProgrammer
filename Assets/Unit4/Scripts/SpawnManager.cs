using UnityEngine;
namespace Assets.Unit4.Scripts
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private float _spawnRange;
        [SerializeField] private GameObject _powerupPrefab;

        public int EnemyCount;
        public int WaveNumber = 1;


        void Start()
        {
            SpawnEnemyWave(WaveNumber);
            Instantiate(_powerupPrefab, GenerateSpawnPos(), _powerupPrefab.transform.rotation);


        }

        void Update()
        {
            EnemyCount = FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
            if (EnemyCount == 0)
            {
                WaveNumber++;
                SpawnEnemyWave(WaveNumber);
                Instantiate(_powerupPrefab, GenerateSpawnPos(), _powerupPrefab.transform.rotation);
            }

        }

        private Vector3 GenerateSpawnPos()
        {
            float spawnX = Random.Range(-_spawnRange, _spawnRange);
            float spawnZ = Random.Range(-_spawnRange, _spawnRange);
            return new Vector3(spawnX, 0, spawnZ);
        }

        private void SpawnEnemyWave(int count)
        {
            for (int i = 0; i < count; i++)
            {

                Instantiate(_enemyPrefab, GenerateSpawnPos(), _enemyPrefab.transform.rotation);

            }
        }
    }
}