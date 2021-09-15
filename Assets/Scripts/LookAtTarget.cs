using UnityEngine;

public class LookAtTarget : LookAtBase
{
    [SerializeField] protected Transform _target;

    protected override Vector3? GetDirectionToLook()
    {
        if (_target == null)
        {
            return null;
        }

        return _target.position - transform.position;
    }
}