using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rb;
    private GameObject _player;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _player = GameObject.Find("Player");


    }

    void Update()
    {
        Vector3 lookDirection = (_player.transform.position - transform.position).normalized;
        _rb.AddForce(lookDirection * _speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}