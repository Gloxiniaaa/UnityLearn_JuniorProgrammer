using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Unit10.Counter
{
    public class Prob : MonoBehaviour
    {
        void OnMouseDrag()
        {
            var cam = Camera.main;
            if (cam == null) return;

            Vector2 mousePos = Mouse.current.position.ReadValue();
            float screenZ = cam.WorldToScreenPoint(transform.position).z;
            Vector3 mouseScreenPos = new Vector3(mousePos.x, mousePos.y, screenZ);
            Vector3 mouseWorldPos = cam.ScreenToWorldPoint(mouseScreenPos);

            Vector3 newProbPos = transform.position;
            newProbPos.x = mouseWorldPos.x;
            transform.position = newProbPos;
        }
    }
}