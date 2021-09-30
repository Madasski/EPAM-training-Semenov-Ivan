using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Image LeftSprite;
    public Image MiddleSprite;
    public Image RightSprite;

    private Health _target;
    private RectTransform _transform;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        var targetPos = Camera.main.WorldToScreenPoint(_target.transform.position + Vector3.forward * .5f);
        _transform.position = targetPos;
    }

    public void SetTarget(Health targetHealth)
    {
        _target = targetHealth;
        _target.OnHealthChange += ChangeHealth;
        var targetPos = Camera.main.WorldToScreenPoint(_target.transform.position + Vector3.forward * .5f);
        _transform.position = targetPos;
    }

    private void OnDisable()
    {
        if (_target)
        {
            _target.OnHealthChange -= ChangeHealth;
        }
    }

    private void ChangeHealth(int newHealth, int maxHealth)
    {
        var percent = (float) newHealth / (float) maxHealth * 3f;

        RightSprite.fillAmount = percent-2f;
        MiddleSprite.fillAmount = percent-1f;
        LeftSprite.fillAmount = percent;
    }
}