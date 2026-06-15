using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Unit3.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        private bool _isGrounded = true;
        private bool _isGameOver = false;
        private Rigidbody _rb;
        private Animator _animator;
        private AudioSource _audioSource;
        [SerializeField] private AudioClip _jumpSfx;
        [SerializeField] private AudioClip _crashSfx;
        [SerializeField] private InputAction _jumpAction;
        [SerializeField] private float _jumpForce = 10;
        [SerializeField] private float _gravityModifer = 4;
        [SerializeField] private ParticleSystem _explosionVfx;
        [SerializeField] private ParticleSystem _dirtVfx;

        public static event Action OnGameOver = delegate { };


        void Start()
        {
            _jumpAction.Enable();
            _rb = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _audioSource = GetComponent<AudioSource>();
            Physics.gravity *= _gravityModifer;
        }

        void Update()
        {
            if (_jumpAction.triggered && _isGrounded && !_isGameOver)
            {
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _isGrounded = false;
                _animator.SetTrigger("Jump_trig");
                _dirtVfx.Stop();
                _audioSource.PlayOneShot(_jumpSfx);

            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGrounded = true;
                _dirtVfx.Play();
            }
            else if (collision.gameObject.CompareTag("Obstacle"))
            {
                _isGameOver = true;
                Debug.Log("Game Over.");
                _animator.SetInteger("DeathType_int", 1);
                _animator.SetBool("Death_b", true);
                _explosionVfx.Play();
                _dirtVfx.Stop();
                _audioSource.PlayOneShot(_crashSfx);
                OnGameOver.Invoke();
            }
        }
    }
}