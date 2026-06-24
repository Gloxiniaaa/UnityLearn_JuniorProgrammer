using UnityEngine;

namespace Assets.Unit4.Scripts
{ 
    public class RotateCamera : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 150f;
        private InputSystem_Actions _controls;

        private void Awake()
        {
            _controls = new();
        }

        void OnEnable()
        {
            _controls.Player.Enable();
        }
        void OnDisable()
        {
            _controls.Player.Disable();
        }

        void Update()
        {
            Vector2 moveInput = _controls.Player.Move.ReadValue<Vector2>();
            transform.Rotate(Vector3.up, moveInput.x * Time.deltaTime * _rotationSpeed);
        }
    }
}