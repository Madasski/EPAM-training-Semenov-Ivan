using Composition;
using UnityEngine;

public class HealthBar : MonoBehaviour, IHealthBar
{
    private IHealthBarView _view;
    private Health _target;

    private void Awake()
    {
        var viewFactory = CompositionRoot.GetViewFactory();
        _view = viewFactory.CreateHealthBar();
    }

    private void Update()
    {
        if (!_target) return;

        var targetPos = Camera.main.WorldToScreenPoint(_target.transform.position + Vector3.forward * .5f);
        _view.UpdatePosition(targetPos);
    }

    private void SetHealth(float newHealth, float maxHealth)
    {
        _view.SetHealth(newHealth, maxHealth);
    }

    public void SetTarget(Health targetHealth)
    {
        _target = targetHealth;
        _target.OnHealthChange += SetHealth;
    }

    private void OnDestroy()
    {
        _target.OnHealthChange -= SetHealth;
    }

    public void DestroyItself()
    {
        _view.DestroyItself();
        Destroy(gameObject);
    }
}