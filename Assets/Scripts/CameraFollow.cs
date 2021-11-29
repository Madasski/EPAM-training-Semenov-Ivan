using UnityEngine;

public class CameraFollow : MonoBehaviour, ICameraFollow
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothTime;

    private Vector3 _velocity = Vector3.zero;

    private void FixedUpdate()
    {
        if (!_target) return;
        var targetPosition = _target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothTime);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}