using UnityEngine;

namespace Assets.Unit5.Challenge5.Scripts
{
    public class DestroyObjectX : MonoBehaviour
    {
        void Start()
        {
            Destroy(gameObject, 2); // destroy particle after 2 seconds
        }

    }

}
