using Composition;
using UnityEngine;

public class HealthBar : MonoBehaviour, IHealthBar
{
    private IHealthBarView _view;
    private IHealth _targetHealth;
    private IMover _targetMover;

    private void Awake()
    {
        var viewFactory = CompositionRoot.GetViewFactory();
        _view = viewFactory.CreateHealthBar();
    }

    private void Update()
    {
        if (_targetHealth == null) return;

        var targetPos = Camera.main.WorldToScreenPoint(_targetMover.Transform.position + Vector3.forward * .5f);
        _view.UpdatePosition(targetPos);
    }

    private void SetHealth(float newHealth, float maxHealth)
    {
        _view.SetHealth(newHealth, maxHealth);
    }

    public void SetTarget(IHealth targetHealth, IMover targetMover)
    {
        _targetHealth = targetHealth;
        _targetMover = targetMover;
        _targetHealth.OnHealthChange += SetHealth;
    }

    private void OnDestroy()
    {
        _targetHealth.OnHealthChange -= SetHealth;
    }

    public void DestroyItself()
    {
        _view.DestroyItself();
        Destroy(gameObject);
    }
}