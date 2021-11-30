using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : SimpleView, IHealthBarView
{
    public Image LeftSprite;
    public Image MiddleSprite;
    public Image RightSprite;

    public Image BackLeftSprite;
    public Image BackMiddleSprite;
    public Image BackRightSprite;

    private Coroutine backSpriteChangingCoroutine;

    public void UpdatePosition(Vector2 position)
    {
        transform.position = position;
    }

    public void DestroyItself()
    {
        Destroy(gameObject);
    }

    public void RemoveItself()
    {
        Destroy(gameObject);
    }

    public void SetHealth(float newHealth, float maxHealth)
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