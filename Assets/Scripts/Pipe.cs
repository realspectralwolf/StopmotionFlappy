using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [HideInInspector] private PipesManager pipesMgr;

    [SerializeField] FramesRenderer topRenderer;
    [SerializeField] FramesRenderer bottomRender;
    [SerializeField] Collectible collectible;
    [SerializeField] GameSettings settings;
    [SerializeField] float moveUpDownSpeed = 1;

    [SerializeField] bool moveUpDown = false;
    float initialY;

    public void Initialize(PipesManager newpipesMgr)
    {
        this.pipesMgr = newpipesMgr;
        ReInitialize();
    }

    public void EnableCollectible()
    {
        collectible.gameObject.SetActive(true);
    }

    public void ReInitialize()
    {
        Vector3 newPos = transform.position;
        initialY = Random.Range(pipesMgr.minY, pipesMgr.maxY);

        newPos.y = initialY;

        int chanceForMoving = 0 + GameManager.instance.difficulty * 10;

        moveUpDown = Random.Range(0, 100) >= chanceForMoving ? false : true;
        if (moveUpDown)
        {
            moveUpDownSpeed = Random.Range(0, 2) == 0 ? moveUpDownSpeed: -moveUpDownSpeed;
        }

        collectible.gameObject.SetActive(false);

        transform.position = newPos;        

        float holeSize = pipesMgr.openingSize - GameManager.instance.difficulty * 0.3f;
        topRenderer.transform.localPosition = new Vector3(0, holeSize / 2f, 0);
        bottomRender.transform.localPosition = new Vector3(0, -holeSize / 2f, 0);

        // Random variant that exists
        List<int> exisitingVariants = new();
        for (int i = 1; i < settings.maxVariants; i++)
        {
            if (Tools.CheckIfFolderExists($"Pipes (128x1024)/Variant {i}"))
            {
                exisitingVariants.Add(i);
            }
        }

        int r = exisitingVariants[Random.Range(0, exisitingVariants.Count)];

        topRenderer.SetAnimTo($"Pipes (128x1024)/Variant {r}/Top", settings.pipesAnimSpeed);
        bottomRender.SetAnimTo($"Pipes (128x1024)/Variant {r}/Bottom", settings.pipesAnimSpeed);
    }

    float _moveTimer = 0;
    void Update()
    {
        transform.position += Vector3.left * GameManager.instance.moveSpeed * Time.deltaTime;

        if (transform.position.x < pipesMgr.cutoffDistance)
        {
            pipesMgr.ReusePipe(this);
        }

        if (moveUpDown)
        {
            _moveTimer += Time.deltaTime * moveUpDownSpeed;
            float newY = pipesMgr.minY + Mathf.PingPong(initialY - pipesMgr.minY + _moveTimer, pipesMgr.maxY);
            var newPos = transform.position;
            newPos.y = newY;
            transform.position = newPos;
        }
    }
}
