using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteChanger : MonoBehaviour
{
    [SerializeField] GameSettings settings;
    [SerializeField] PlayerMovement playerMovement;

    int variantIndex = 1;
    FramesRenderer framesRend;

    private void Start()
    {
        // choose random bird variant
        List<int> exisitingVariants = new();
        for (int i = 1; i < settings.maxVariants; i++)
        {
            if (Tools.CheckIfFolderExists($"Player (512x512)/Variant {i}"))
            {
                exisitingVariants.Add(i);
            }
        }

        int variantIndex = exisitingVariants[Random.Range(0, exisitingVariants.Count)];

        framesRend = GetComponent<FramesRenderer>();

        framesRend.SetAnimTo($"Player (512x512)/Variant {variantIndex}/Idle", settings.playerIdleAnimSpeed);
    }

    private void PlayJumpFrames()
    {
        if (framesRend._framesPath == $"Player (512x512)/Variant {variantIndex}/Jump")
        {
            return;
        }

        framesRend.SetAnimTo($"Player (512x512)/Variant {variantIndex}/Jump", settings.playerJumpAnimSpeed);
        framesRend.SetNextAnim($"Player (512x512)/Variant {variantIndex}/Idle", settings.playerIdleAnimSpeed);
    }

    private void SetToDeadAnimation()
    {
        framesRend.SetNextAnim(null, settings.playerIdleAnimSpeed);
        framesRend.SetAnimTo($"Player (512x512)/Variant {variantIndex}/Dead", settings.playerDeadAnimSpeed);
    }

    private void OnEnable()
    {
        playerMovement.OnJumped += PlayJumpFrames;
        GameManager.OnGameEnded += SetToDeadAnimation;
    }

    private void OnDisable()
    {
        playerMovement.OnJumped -= PlayJumpFrames;
        GameManager.OnGameEnded -= SetToDeadAnimation;
    }
}
