using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMenuHandler : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            GameManager.instance.OpenMenu();
        }
    }
}
