using UnityEngine;

public class LookAtMouse : LookAtBase
{
    protected override Vector3? GetDirectionToLook()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
            var directionToLook = hit.point - transform.position;
            return directionToLook;
        }
        else
        {
            return null;
        }
    }
}