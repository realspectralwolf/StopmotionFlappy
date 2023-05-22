using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] GameSettings settings;
    FramesRenderer framesRend;

    private void Start()
    {
        // choose random bird variant
        List<int> exisitingVariants = new();
        for (int i = 1; i < settings.maxVariants; i++)
        {
            if (Tools.CheckIfFolderExists($"Background (1920x1080)/Variant {i}"))
            {
                exisitingVariants.Add(i);
            }
        }

        int variantIndex = exisitingVariants[Random.Range(0, exisitingVariants.Count)];

        framesRend = GetComponent<FramesRenderer>();

        framesRend.SetAnimTo($"Background (1920x1080)/Variant {variantIndex}", settings.backgroundAnimSpeed);
    }
}
