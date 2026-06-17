using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Unit10.Counter
{
    public class ProbSelector : MonoBehaviour
    {
        void Update()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Vector2 mousePos = Mouse.current.position.ReadValue();
                Ray ray = Camera.main.ScreenPointToRay(mousePos);
                Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 2f);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.TryGetComponent<Prob>(out var target))
                    {
                        Vector3 mouseWorldPos = Camera.main.ScreenToViewportPoint(mousePos);
                        Vector3 newProbPos = target.transform.position;
                        newProbPos.x = mouseWorldPos.x;
                        target.transform.position = newProbPos;
                    }
                }
            }
        }
    }
}