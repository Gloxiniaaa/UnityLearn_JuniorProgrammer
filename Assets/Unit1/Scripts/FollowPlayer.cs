using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset = new Vector3(0, 5, -7);
    void LateUpdate()
    {
        transform.position = _target.position + _offset;
    }
}