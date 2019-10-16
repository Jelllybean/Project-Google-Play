using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

class TextFadeOut : MonoBehaviour
{
    //Fade time in seconds
    public float fadeOutTime;
    public TextMeshPro text;

    private void Awake()
    {
        text = GetComponent<TextMeshPro>();
    }
    private void OnEnable()
    {
        StartCoroutine(FadeOutRoutine());
    }
    public void FadeOut()
    {
        StartCoroutine(FadeOutRoutine());
    }
    private IEnumerator FadeOutRoutine()
    {
        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            text.alpha = Mathf.Lerp(1f, 0f, Mathf.Min(1, t / fadeOutTime));
            text.transform.Translate(Vector3.up * Time.deltaTime);
            Invoke("Disable", 2f);
            yield return null;
        }
    }
    public void Disable()
    {
        text.rectTransform.anchoredPosition = Vector3.zero;
        text.alpha = 1f;
        gameObject.SetActive(false);
    }
}