using UnityEngine;

namespace Assets.Unit2.Scripts
{
    public class MoveForward : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _topBound = 30;
        [SerializeField] private float _lowerBound = -10;


        void Update()
        {
            transform.Translate(_speed * Time.deltaTime * Vector3.forward);

            if (transform.position.z > _topBound || transform.position.z < _lowerBound)
            {
                Destroy(gameObject);
            }
        }
    }
}