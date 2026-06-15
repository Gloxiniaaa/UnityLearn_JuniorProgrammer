using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Unit2.Challenge2.Scripts
{
    public class PlayerControllerX : MonoBehaviour
    {
        public GameObject dogPrefab;

        private float cooldown = 0;

        // Update is called once per frame
        void Update()
        {
            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space) && cooldown < 0)
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                cooldown = 1;
            }
            cooldown -= Time.deltaTime;
        }
    }
}
