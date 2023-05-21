using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDelay : MonoBehaviour
{
    [SerializeField] float secondsToWait = 1;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().enabled = false;
        StartCoroutine(EnableButtonAfter(secondsToWait));
    }

    IEnumerator EnableButtonAfter(float sec)
    {   
        yield return new WaitForSeconds(sec);
        GetComponent<Button>().enabled = true;
    }
}
