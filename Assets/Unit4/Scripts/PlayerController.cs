using System.Collections;
using UnityEngine;

namespace Assets.Unit4.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _playerSpeed = 150f;
        [SerializeField] private Transform _focalPoint;
        [SerializeField] private float _powerupStrength;
        [SerializeField] private float _powerupDuration;
        [SerializeField] private GameObject _powerupIndicator;
        private bool _hasPowerup;
        private Rigidbody _rb;
        private InputSystem_Actions _controls;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _controls = new();
        }

        void OnEnable()
        {
            _controls.Player.Enable();
            _powerupIndicator.gameObject.SetActive(false);
        }

        void OnDisable()
        {
            _controls.Player.Disable();
        }

        void Update()
        {
            Vector2 moveInput = _controls.Player.Move.ReadValue<Vector2>();
            // transform.Rotate(Vector3.up, moveInput.y * Time.deltaTime * _playerSpeed);
            _rb.AddForce(moveInput.y * _playerSpeed * Time.deltaTime * _focalPoint.forward);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("PowerUp"))
            {
                _hasPowerup = true;
                Destroy(other.gameObject);
                StartCoroutine(PowerupCountDownRoutine());
                _powerupIndicator.SetActive(true);
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy") && _hasPowerup)
            {
                Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
                enemyRb.AddForce(awayFromPlayer * _powerupStrength, ForceMode.Impulse);
            }
        }

        IEnumerator PowerupCountDownRoutine()
        {
            yield return new WaitForSeconds(_powerupDuration);
            _hasPowerup = false;
            _powerupIndicator.SetActive(false);
        }
    }
}