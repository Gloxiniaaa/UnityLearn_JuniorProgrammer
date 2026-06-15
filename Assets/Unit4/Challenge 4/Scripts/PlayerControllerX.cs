using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Unit4.Challenge4.Scripts
{
    public class PlayerControllerX : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _boostVfx;
        private Rigidbody playerRb;
        private float normalSpeed = 500;
        private float boostSpeed = 800;
        private float currentSpeed = 500;
        private GameObject focalPoint;

        public bool hasPowerup;
        public GameObject powerupIndicator;
        public int powerUpDuration = 5;

        private float normalStrength = 10; // how hard to hit enemy without powerup
        private float powerupStrength = 25; // how hard to hit enemy with powerup

        private InputSystem_Actions controls;

        void Awake()
        {
            controls = new InputSystem_Actions();
        }

        void OnEnable()
        {
            controls.Player.Enable();
        }

        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
            focalPoint = GameObject.Find("Focal Point");
        }

        void Update()
        {
            // Add force to player in direction of the focal point (and camera)
            float verticalInput = controls.Player.Move.ReadValue<Vector2>().y;

            // Set powerup indicator position to beneath player
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.6f, 0);


            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                currentSpeed = boostSpeed;

                _boostVfx.Play();

            }
            else if (Keyboard.current.spaceKey.wasReleasedThisFrame)
            {
                currentSpeed = normalSpeed;
                _boostVfx.Stop();

            }
            playerRb.AddForce(focalPoint.transform.forward * verticalInput * currentSpeed * Time.deltaTime);


        }

        // If Player collides with powerup, activate powerup
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Powerup"))
            {
                Destroy(other.gameObject);
                hasPowerup = true;
                powerupIndicator.SetActive(true);
                StartCoroutine(PowerupCooldown());
            }
        }

        // Coroutine to count down powerup duration
        IEnumerator PowerupCooldown()
        {
            yield return new WaitForSeconds(powerUpDuration);
            hasPowerup = false;
            powerupIndicator.SetActive(false);
        }

        // If Player collides with enemy
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer = other.gameObject.transform.position - transform.position;

                if (hasPowerup) // if have powerup hit enemy with powerup force
                {
                    enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
                }
                else // if no powerup, hit enemy with normal strength
                {
                    enemyRigidbody.AddForce(awayFromPlayer * normalStrength, ForceMode.Impulse);
                }
            }
        }


    }
}
