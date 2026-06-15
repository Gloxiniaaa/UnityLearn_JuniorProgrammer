using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Unit5.Scripts
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _targets;

        [SerializeField] private float _spawnRate;

        private void Start()
        {
            StartCoroutine(SpawnTarget());
        }

        void Update()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 2f);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.TryGetComponent<ITarget>(out var target))
                    {
                        target.OnClick();
                    }
                }
            }
        }

        private IEnumerator SpawnTarget()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnRate);
                int idx = Random.Range(0, _targets.Count);
                Instantiate(_targets[idx]);
            }
        }
    }
}