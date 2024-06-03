using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TextMeshProUGUI currencyUI;
    [SerializeField] TextMeshProUGUI AmmoBaseLV;
    [SerializeField] TextMeshProUGUI MaterialBaseLV;
    [SerializeField] GameObject infoPanel;
    [SerializeField] GameObject infoPanelINFO;
    [SerializeField] TextMeshProUGUI playerHealth;


    private void OnGUI()
    {
        currencyUI.text = LevelManager.main.currency.ToString();
        AmmoBaseLV.text = AmmoBase.main.ammoBaseLV.ToString();
        MaterialBaseLV.text = MaterialBase.main.materialBaseLV.ToString();
        playerHealth.text = GameManager.main.playerHealth.ToString();
    }

    private void Update()
    {
        ToggleInfoPanel();
    }

    public void ToggleInfoPanel()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            infoPanel.SetActive(false);
            infoPanelINFO.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            infoPanel.SetActive(true) ;
            infoPanelINFO.SetActive(false) ;
        }
    }
}
