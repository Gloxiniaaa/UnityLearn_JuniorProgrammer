using UnityEngine;

namespace Assets.Unit2.Scripts
{
    public class DetectCollisions : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}