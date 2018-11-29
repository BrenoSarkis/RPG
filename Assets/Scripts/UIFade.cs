using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public static UIFade instance;
    public Image fadeScreen;
    public float fadeSpeed;

    private bool shouldFadeToBlack;
    private bool shouldFadeFromBlack;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            StopsFadingToBlack();
        }

        if (shouldFadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            StopsFadingFromBlack();
        }
    }

    private void StopsFadingFromBlack()
    {
        if (fadeScreen.color.a == 0f)
        {
            shouldFadeFromBlack = false;
        }
    }

    private void StopsFadingToBlack()
    {
        if (fadeScreen.color.a == 1f)
        {
            shouldFadeToBlack = false;
        }
    }

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        shouldFadeFromBlack = true;
        shouldFadeToBlack = false;
    }
}
