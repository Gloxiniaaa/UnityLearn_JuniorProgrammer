using UnityEngine;

namespace Assets.Unit3.Scripts
{
    public class MoveLeft : MonoBehaviour
    {
        [SerializeField] private float _leftBound = -15;
        [SerializeField] private float _speed = 30;
        private bool _isGameOver = false;
        void Update()
        {
            if (_isGameOver)
                return;
            transform.Translate(_speed * Time.deltaTime * Vector3.left);

            if (transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }
        }

        void OnEnable()
        {
            PlayerController.OnGameOver += OnGameOver;
        }

        private void OnGameOver()
        {
            _isGameOver = true;
        }

        void OnDisable()
        {
            PlayerController.OnGameOver -= OnGameOver;
        }
    }
}