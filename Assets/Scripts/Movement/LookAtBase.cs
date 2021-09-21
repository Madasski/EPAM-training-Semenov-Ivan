using UnityEngine;

public abstract class LookAtBase : MonoBehaviour
{
    private void Update()
    {
        var directionToLook = GetDirectionToLook();
        if (directionToLook == null) return;

        ApplyRotation((Vector3) directionToLook);
    }

    private void ApplyRotation(Vector3 directionToLook)
    {
        var targetRotation = Mathf.Atan2(directionToLook.z, directionToLook.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, -targetRotation, 0));
    }

    protected abstract Vector3? GetDirectionToLook();
}