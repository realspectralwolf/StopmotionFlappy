using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    [SerializeField] GameSettings settings;

    private void OnEnable()
    {
        // choose random variant
        List<string> exisitingVariants = new();
        for (int i = 1; i < settings.maxVariants; i++)
        {
            string path = $"Mirror (128x512)/Variant {i}";
            if (Tools.CheckIfFolderExists(path))
            {
                exisitingVariants.Add(path);
            }
        }
        string variantPath = exisitingVariants[Random.Range(0, exisitingVariants.Count)];

        GetComponent<FramesRenderer>().SetAnimTo(variantPath, settings.portalAnimSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.CollectedMirrorObject();
        }
    }
}
