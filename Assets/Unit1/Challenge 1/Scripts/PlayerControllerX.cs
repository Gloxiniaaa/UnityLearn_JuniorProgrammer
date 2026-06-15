using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Unit1.Challenge1.Scripts
{
    public class PlayerControllerX : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;
        private float _verticalInput;

        // Update is called once per frame
        void FixedUpdate()
        {
            // get the user's vertical input
            _verticalInput = Input.GetAxis("Vertical");

            // move the plane forward at a constant rate
            transform.Translate(_speed * Time.deltaTime * Vector3.forward);

            // tilt the plane up/down based on up/down arrow keys
            transform.Rotate(Vector3.left, _rotationSpeed * Time.deltaTime * _verticalInput);
        }
    }
}
