using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour
{
    [SerializeField] Image image1;
    [SerializeField] Image image2;
    [SerializeField] Animator animator;
    public bool isFadeIn = true;
    public bool canFadeIn = true;
    public bool canFadeOut = true;
    public bool isFading = false;
    WaitForSeconds fadeTime;

    public static FadeEffect instance = null;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this; 
        }
    }

    private void Start()
    {
        fadeTime = new WaitForSeconds(1);
        image1.raycastTarget = false;
        image2.raycastTarget = false;
    }

    //Scene이 시작할 때(Title빼고)
    public void FadeIn()
    {
        if (canFadeIn && !isFadeIn) 
        {
            isFading = true;
            animator.SetTrigger("FadeIn");
            StartCoroutine(ResetFadeIn());
            canFadeIn = false;
            image1.raycastTarget = true;
            image2.raycastTarget = true;
        }
    }

    IEnumerator ResetFadeIn()
    {
        yield return fadeTime;
        isFadeIn = true;
        canFadeIn = true;
        image1.raycastTarget = false;
        image2.raycastTarget = false;
        isFading = false;
    }

    public void FadeOut()
    {
        if (canFadeOut && isFadeIn)
        {
            isFading = true;
            animator.SetTrigger("FadeOut");
            StartCoroutine(ResetFadeOut());
            canFadeOut = false;
            image1.raycastTarget = true;
            image2.raycastTarget = true;
        }
    }

    IEnumerator ResetFadeOut()
    {
        yield return fadeTime;
        isFadeIn = false;
        canFadeOut = true;
        image1.raycastTarget = false;
        image2.raycastTarget = false;
        isFading = false;
    }
}
