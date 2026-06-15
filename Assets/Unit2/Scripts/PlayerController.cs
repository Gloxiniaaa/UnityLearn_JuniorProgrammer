using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Unit2.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _boundX = 10f;
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private InputAction _moveAction;
        [SerializeField] private InputAction _fireAction;

        private Vector2 _moveInput;


        void OnEnable()
        {
            _moveAction.Enable();
            _fireAction.Enable();
        }


        void Update()
        {
            _moveInput = _moveAction.ReadValue<Vector2>();
            transform.Translate(_speed * _moveInput.x * Time.deltaTime * Vector3.right);
            Vector3 pos = transform.position;
            if (transform.position.x > _boundX)
            {
                pos.x = _boundX;
            }
            else if (transform.position.x < -_boundX)
            {
                pos.x = -_boundX;
            }
            transform.position = pos;


            if (_fireAction.triggered)
            {
                Instantiate(_projectilePrefab, transform.position, _projectilePrefab.transform.rotation);
            }
        }
    }
}