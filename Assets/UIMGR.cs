using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMGR : MonoBehaviour
{
    [SerializeField] GameObject panelGameplay;
    [SerializeField] GameObject panelEnded;

    private void OnEnable()
    {
        PlayerLife.OnPlayerDied += SetPanelToEnded;
    }

    private void OnDisable()
    {
        PlayerLife.OnPlayerDied -= SetPanelToEnded;
    }

    private void SetPanelToEnded()
    {
        panelGameplay.SetActive(false);
        panelEnded.SetActive(true);
    }
}
