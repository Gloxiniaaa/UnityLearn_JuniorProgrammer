using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Unit2.Challenge2.Scripts
{
    public class DetectCollisionsX : MonoBehaviour
    {

        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }
}