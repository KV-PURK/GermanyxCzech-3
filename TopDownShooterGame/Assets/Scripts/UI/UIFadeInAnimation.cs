using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UIFadeInAnimation : MonoBehaviour
{
    private CanvasGroup group;
    [SerializeField] private bool playOnEnable = true;
    [SerializeField] private float animationDuration = 0.5f;
    [SerializeField] private AnimationCurve curve;

    private void Awake()
    {
        group = GetComponent<CanvasGroup>();
    }

    public void OnEnable()
    {
        if (playOnEnable)
        {
            OpenAnimation();
        }
    }

    public void OpenAnimation()
    {
        StopAllCoroutines();
        StartCoroutine(DoOpenAnimation());
    }

    public void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator DoOpenAnimation()
    {
        float timeElapsed = 0.0f;
        while (timeElapsed < animationDuration)
        {
            group.alpha = Mathf.Lerp(0.2f, 1.0f, curve.Evaluate(timeElapsed / animationDuration));
            timeElapsed += Time.unscaledDeltaTime;
            yield return null;
        }
    }
}
