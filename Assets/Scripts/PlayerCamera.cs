using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _offset;

    private void Awake()
    {
        _offset = transform.position - _player.position;
    }

    private void LateUpdate()
    {
        transform.position = _player.position + _offset;
    }
}