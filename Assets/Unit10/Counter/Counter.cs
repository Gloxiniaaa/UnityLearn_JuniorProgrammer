using UnityEngine;
using UnityEngine.UI;

namespace Assets.Unit10.Counter
{
    [SelectionBase]
    public class Counter : MonoBehaviour
    {
        public Text CounterText;

        private int count = 0;

        private void Start()
        {
            count = 0;
        }

        private void OnTriggerEnter(Collider other)
        {
            count += 1;
            CounterText.text = "Count : " + count;
        }
    }
}
