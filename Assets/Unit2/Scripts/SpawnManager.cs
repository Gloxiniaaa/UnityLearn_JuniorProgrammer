using UnityEngine;

namespace Assets.Unit2.Scripts
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] _prefabs;
        [SerializeField] private float _spawnZ = 10;
        [SerializeField] private float _spawnRangeX = 20;
        [SerializeField] private float _startDelay = 2f;
        [SerializeField] private float _spawnInterval = 1.5f;


        void Start()
        {
            InvokeRepeating(nameof(SpawnRandom), _startDelay, _spawnInterval);
        }

        private void SpawnRandom()
        {
            int index = Random.Range(0, _prefabs.Length);
            GameObject prefab = _prefabs[index];
            Vector3 spawnPos = new Vector3(Random.Range(-_spawnRangeX, _spawnRangeX), 0, _spawnZ);
            Instantiate(prefab, spawnPos, prefab.transform.rotation);
        }
    }
}