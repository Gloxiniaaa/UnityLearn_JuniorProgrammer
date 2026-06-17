using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Conveyor : MonoBehaviour
{
    [SerializeField] private float _wait;
    [SerializeField] private GameObject[] _probPrefabs;
    [SerializeField] private float _speed;
    [SerializeField] private bool _isActive;
    [SerializeField] private Vector3 _spawnProbPos;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private void FixedUpdate()
    {
        Vector3 pos = _rb.position;
        _rb.position += _speed * Time.fixedDeltaTime * transform.forward;
        _rb.MovePosition(pos);
    }

    private IEnumerator SpawnCoroutine()
    {
        WaitForSeconds wait = new WaitForSeconds(_wait);
        while (_isActive)
        {
            SpawnProb();
            yield return wait;
        }
    }

    private void SpawnProb()
    {
        GameObject prefab = _probPrefabs[Random.Range(0, _probPrefabs.Length)];
        Vector3 randomXPos = _spawnProbPos;
        randomXPos.x = Random.Range(-randomXPos.x, randomXPos.x);
        Instantiate(prefab, randomXPos, prefab.transform.rotation);
    }
}