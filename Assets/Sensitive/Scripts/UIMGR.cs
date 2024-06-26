using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIMGR : MonoBehaviour
{
    [SerializeField] GameObject panelMenu;
    [SerializeField] GameObject panelGameplay;
    [SerializeField] GameObject panelEnded;

    public static UIMGR instance;

    private void Awake()
    {
        instance = this;
        SetPanelToMenu();
    }

    private void OnEnable()
    {
        GameManager.OnGameEnded += SetPanelToEnded;
        GameManager.OnGameplayStartAction += SetPanelToGameplay;
    }

    private void OnDisable()
    {
        GameManager.OnGameEnded -= SetPanelToEnded;
        GameManager.OnGameplayStartAction -= SetPanelToGameplay;
    }

    private void SetPanelToMenu()
    {
        panelMenu.SetActive(true);
        panelGameplay.SetActive(false);
        panelEnded.SetActive(false);
    }

    private void SetPanelToGameplay()
    {
        panelMenu.SetActive(false);
        panelGameplay.SetActive(true);
        panelEnded.SetActive(false);
    }

    private void SetPanelToEnded()
    {
        panelMenu.SetActive(false);
        panelGameplay.SetActive(false);
        panelEnded.SetActive(true);
    }
}
