using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Image LeftSprite;
    public Image MiddleSprite;
    public Image RightSprite;

    public Image BackLeftSprite;
    public Image BackMiddleSprite;
    public Image BackRightSprite;

    private Health _target;
    private RectTransform _transform;
    private Coroutine backSpriteChangingCoroutine;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        if (!_target) return;

        var targetPos = Camera.main.WorldToScreenPoint(_target.transform.position + Vector3.forward * .5f);
        _transform.position = targetPos;
    }

    public void SetTarget(Health targetHealth)
    {
        _target = targetHealth;
        _target.OnHealthChange += ChangeHealth;
        FollowTarget();
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

        RightSprite.fillAmount = percent - 2f;
        MiddleSprite.fillAmount = percent - 1f;
        LeftSprite.fillAmount = percent;

        if (backSpriteChangingCoroutine != null) StopCoroutine(backSpriteChangingCoroutine);
        
        backSpriteChangingCoroutine = StartCoroutine(BackSpriteChanging(percent));
    }

    private IEnumerator BackSpriteChanging(float targetPercent)
    {
        float percentToDraw;
        float currentPercent = -1f;

        while (!Mathf.Approximately(targetPercent, currentPercent))
        {
            currentPercent = BackRightSprite.fillAmount + BackMiddleSprite.fillAmount + BackLeftSprite.fillAmount;
            percentToDraw = Mathf.MoveTowards(currentPercent, targetPercent, .02f);
            
            BackRightSprite.fillAmount = percentToDraw - 2f;
            BackMiddleSprite.fillAmount = percentToDraw - 1f;
            BackLeftSprite.fillAmount = percentToDraw;

            yield return new WaitForSeconds(.05f);
        }
    }
}