using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class Collectible : MonoBehaviour
{
    [SerializeField] GameSettings settings;

    Vector3 initialScale;

    private void Start()
    {
        initialScale = transform.localScale;

        // choose random variant
        List<string> exisitingVariants = new();
        for (int i = 1; i < settings.maxVariants; i++)
        {
            string path = $"Collectible (512x512)/Variant {i}";
            if (Tools.CheckIfFolderExists(path))
            {
                exisitingVariants.Add(path);
            }
        }
        string variantPath = exisitingVariants[Random.Range(0, exisitingVariants.Count)];

        GetComponent<FramesRenderer>().SetAnimTo(variantPath, settings.collectibleAnimSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.PointCollected();

            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(initialScale * 1.45f, 0.1f))
                .Append(transform.DOScale(0f, 0.14f))
                .OnComplete(AnimationComplete);
        }
    }

    void AnimationComplete()
    {
        gameObject.SetActive(false);
        transform.localScale = initialScale;
    }
}
