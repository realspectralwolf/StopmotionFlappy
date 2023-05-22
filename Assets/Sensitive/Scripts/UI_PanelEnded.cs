using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UI_PanelEnded : MonoBehaviour
{
    [SerializeField] Transform[] thingsToAnimate;
    [SerializeField] Transform buttonToAnimate;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AnimateThings());
    }

    IEnumerator AnimateThings()
    {
        Vector3[] initialScales = new Vector3[thingsToAnimate.Length];

        for (int i = 0; i < thingsToAnimate.Length; i++)
        {
            initialScales[i] = thingsToAnimate[i].localScale;
            thingsToAnimate[i].localScale = Vector3.zero;
        }

        for (int i = 0; i < thingsToAnimate.Length; i++)
        {
            thingsToAnimate[i].DOScale(initialScales[i], 0.2f);
            yield return new WaitForSeconds(0.1f);
        }

        if (buttonToAnimate == null) yield break;

        buttonToAnimate.DOScale(Vector3.one * 0.9f, 0.34f).SetLoops(-1, LoopType.Yoyo);
    }
}
