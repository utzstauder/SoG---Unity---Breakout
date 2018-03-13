using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldspaceLabelUI : MonoBehaviour {

    [SerializeField] Text textComponent;
    CanvasGroup canvasGroup;

    [SerializeField] float fadeInDuration  = 0.2f;
    [SerializeField] Vector3 fadeInOffset;

    [SerializeField] float fadeOutDuration = 1.0f;
    [SerializeField] Vector3 fadeOutOffset;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Init(Vector3 position, string text)
    {
        transform.position = position;
        textComponent.text = text;

        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        yield return StartCoroutine(FadeIn(fadeInDuration));
        // wait for x seconds
        yield return StartCoroutine(FadeOut(fadeOutDuration));
        Destroy(gameObject);
    }

    IEnumerator FadeIn(float duration)
    {
        Debug.Log("FadeIn start");

        Vector3 fromPosition   = transform.position;
        Vector3 targetPosition = transform.position + fadeInOffset;

        canvasGroup.alpha = 0;

        // fade in animation...
        for(float t = 0; t < duration; t += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(fromPosition, targetPosition, t / duration);
            canvasGroup.alpha = t / duration;
            yield return new WaitForEndOfFrame();
            // yield return null;
        }

        transform.position = targetPosition;
        canvasGroup.alpha = 1f;

        Debug.Log("FadeIn end");
    }

    IEnumerator FadeOut(float duration)
    {
        Debug.Log("FadeOut start");

        Vector3 fromPosition = transform.position;
        Vector3 targetPosition = transform.position + fadeOutOffset;

        canvasGroup.alpha = 1f;

        // fade out animation
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            transform.position = Vector3.Lerp(fromPosition, targetPosition, t / duration);
            canvasGroup.alpha = 1f - (t / duration);
            yield return new WaitForEndOfFrame();
            // yield return null;
        }

        transform.position = targetPosition;
        canvasGroup.alpha = 0;


        Debug.Log("FadeOut end");
    }
}
