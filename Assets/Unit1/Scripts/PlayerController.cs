using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Unit1.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _turnSpeed = 25;
        [SerializeField] private InputAction _moveAction;
        private Vector2 _moveInput;

        void OnEnable()
        {
            _moveAction.Enable();
        }


        void Update()
        {
            _moveInput = _moveAction.ReadValue<Vector2>();
            transform.Translate(_moveInput.y * _speed * Time.deltaTime * transform.forward);
            transform.Rotate(Vector3.up, _turnSpeed * Time.deltaTime * _moveInput.x);
        }
    }
}