using UnityEngine;
using UnityEngine.Events;

namespace Assets.Unit5.Scripts
{
    public class Target : MonoBehaviour, ITarget
    {
        [SerializeField] private ParticleSystem _explosionVfx;
        [SerializeField] private int _pointValue;
        [SerializeField] private float _minSpeed = 12;
        [SerializeField] private float _maxSpeed = 16;
        [SerializeField] private float _maxTorque = 10;
        [SerializeField] private float _xRange = 4;
        [SerializeField] private float _ySpawnPos = -6;
        public static event UnityAction<int> OnTargetClicked = delegate { };


        private Rigidbody _rb;

        void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        void Start()
        {
            transform.position = RandomSpawnPos();
            _rb.AddForce(RandomForce(), ForceMode.Impulse);
            _rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
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
            OnTargetClicked.Invoke(_pointValue);
            Instantiate(_explosionVfx, transform.position, _explosionVfx.transform.rotation);
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