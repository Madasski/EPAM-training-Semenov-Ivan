using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    private Health target;
    private RectTransform _transform;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        var targetPos = Camera.main.WorldToScreenPoint(target.transform.position + Vector3.forward * .5f);
        _transform.position = targetPos;
    }

    public void SetTarget(Health targetHealth)
    {
        target = targetHealth;
        var targetPos = Camera.main.WorldToScreenPoint(target.transform.position + Vector3.forward * .5f);
        _transform.position = targetPos;
    }
}