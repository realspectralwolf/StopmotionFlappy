using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesManager : MonoBehaviour
{
    [SerializeField] public float cutoffDistance;
    [SerializeField] public float openingSize = 16;
    [SerializeField] public float minY = -1.6f;
    [SerializeField] public float maxY = 2.6f;

    [SerializeField] Pipe pipePrefab;
    [SerializeField] int poolSize = 10;
    [SerializeField] float spacing = 3;
    [SerializeField] float initialDisantce = 0;

    [HideInInspector] public int mirrorsCreated = 0;
    Transform lastPipeTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        DestroyChildren();
        SpawnPool();
    }

    void DestroyChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    void SpawnPool()
    {
        pipesUntilNextCollectible = Random.Range(0, 2);

        for (int i = 0; i < poolSize; i++)
        {
            Vector3 pos = Vector3.zero;
            pos.x = initialDisantce + spacing * i;

            var newPipe = Instantiate(pipePrefab, pos, Quaternion.identity, transform);
            newPipe.Initialize(this);
            HandleCollectibleSpawn(newPipe);

            if (i == poolSize - 1)
            {
                lastPipeTransform = newPipe.transform;
            }
        }
    }

    public void ReusePipe(Pipe pipeToReuse)
    {
        Vector3 pos = Vector3.zero;
        pos.x = lastPipeTransform.position.x + spacing;
        pipeToReuse.transform.position = pos;
        lastPipeTransform = pipeToReuse.transform;
        pipeToReuse.ReInitialize();
        HandleCollectibleSpawn(pipeToReuse);
    }

    int pipesUntilNextCollectible = 0;
    private void HandleCollectibleSpawn(Pipe pipe)
    {
        pipesUntilNextCollectible--;
        if (pipesUntilNextCollectible < 0)
        {
            pipesUntilNextCollectible = Random.Range(1, 2);
            pipe.ToggleCollectible(true);
        }
        else if (mirrorsCreated < GameManager.instance.difficulty)
        {
            pipe.ToggleMirror(true);
            mirrorsCreated++;
        }
    }
}
