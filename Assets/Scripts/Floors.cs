using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floors : MonoBehaviour
{
    [SerializeField] GameSettings settings;
    [SerializeField] FramesRenderer[] frameRends;
    [SerializeField] float cutoffDistance;

    private void Start()
    {
        // choose random variant
        List<int> exisitingVariants = new();
        for (int i = 1; i < settings.maxVariants; i++)
        {
            if (Tools.CheckIfFolderExists($"Background (1920x1080)/Variant {i}"))
            {
                exisitingVariants.Add(i);
            }
        }

        int variantIndex = exisitingVariants[Random.Range(0, exisitingVariants.Count)];

        for (int i = 0; i < frameRends.Length; i++)
        {
            frameRends[i].SetAnimTo($"Floor (1920x256)/Variant {variantIndex}", settings.backgroundAnimSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < frameRends.Length; i++)
        {
            var target = frameRends[i].transform;
            target.position += Vector3.left * GameManager.instance.moveSpeed * Time.deltaTime;

            if (target.position.x < cutoffDistance)
            {
                Vector3 newPos = target.position;
                newPos.x = -cutoffDistance;
                target.position = newPos;
            }
        }
    }
}
