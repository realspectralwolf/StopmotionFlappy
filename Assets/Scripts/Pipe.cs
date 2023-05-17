using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [HideInInspector] private PipesManager pipesMgr;

    [SerializeField] FramesRenderer topRenderer;
    [SerializeField] FramesRenderer bottomRender;
    [SerializeField] GameSettings settings;

    public void Initialize(PipesManager newpipesMgr)
    {
        this.pipesMgr = newpipesMgr;
        ReInitialize();
    }

    public void ReInitialize()
    {
        Vector3 newPos = transform.position;
        newPos.y = Random.Range(pipesMgr.minY, pipesMgr.maxY);
        transform.position = newPos;

        topRenderer.transform.localPosition = new Vector3(0, pipesMgr.openingSize / 2f, 0);
        bottomRender.transform.localPosition = new Vector3(0, -pipesMgr.openingSize / 2f, 0);

        topRenderer._framesInterval = settings.pipesInterval;
        bottomRender._framesInterval = settings.pipesInterval;

        // Random variant that exists
        List<int> exisitingVariants = new();
        for (int i = 1; i < settings.maxVariants; i++)
        {
            if (Tools.CheckIfFolderExists($"Pipes/Variant {i}"))
            {
                print("exits");
                exisitingVariants.Add(i);
            }
        }
        
        print(Random.Range(0, exisitingVariants.Count));
        int r = exisitingVariants[Random.Range(0, exisitingVariants.Count)];
        topRenderer._framesPath = $"Pipes/Variant {r}/Top";
        bottomRender._framesPath = $"Pipes/Variant {r}/Bottom";
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * GameManager.instance.moveSpeed * Time.deltaTime;

        if (transform.position.x < pipesMgr.cutoffDistance)
        {
            pipesMgr.ReusePipe(this);
        }
    }
}
