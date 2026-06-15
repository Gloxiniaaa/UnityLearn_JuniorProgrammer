using UnityEngine;

namespace Assets.Unit5.Scripts
{
    public class Target : MonoBehaviour, ITarget
    {
        [SerializeField] private float _minSpeed = 12;
        [SerializeField] private float _maxSpeed = 16;
        [SerializeField] private float _maxTorque = 10;
        [SerializeField] private float _xRange = 4;
        [SerializeField] private float _ySpawnPos = -6;


        private Rigidbody _rb;

        void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        void Start()
        {
            transform.position = new Vector3(Random.Range(-4, 4), 6);
            _rb.AddForce(Vector3.up * Random.Range(10, 16), ForceMode.Impulse);
            _rb.AddTorque(Random.Range(-10, 16), Random.Range(-10, 16), Random.Range(10, 16), ForceMode.Impulse);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("DestroyZone"))
            {
                Destroy(gameObject);
            }
        }

        public void OnClick()
        {
            Destroy(gameObject);
        }


        private Vector3 RandomForce()
        {
            return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
        }
        private float RandomTorque()
        {
            return Random.Range(-_maxTorque, _maxTorque);
        }
        private Vector3 RandomSpawnPos()
        {
            return new Vector3(Random.Range(-_xRange, _xRange), _ySpawnPos);

        }

    }
}