using UnityEngine;
namespace Assets.Unit1.Challenge1.Scripts
{
    public class Propeller : MonoBehaviour
    {
        [SerializeField] private float _rotSpeed;
        void Update()
        {
            transform.Rotate(transform.forward, _rotSpeed * Time.deltaTime);
        }
    }
}