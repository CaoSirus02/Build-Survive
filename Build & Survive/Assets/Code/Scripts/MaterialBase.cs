using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MaterialBase : MonoBehaviour
{
    public static MaterialBase main;

    [Header("References")]
    [SerializeField] private TextMeshProUGUI materialCountOnPlayerTXT;
    [Header("Attributes")]
    [SerializeField] public int materialCountBase = 100;
    [SerializeField] public int materialCountOnPlayer = 0;
    [SerializeField] public int materialBaseLV = 1;


    float createMaterialTime = 8f;
    float currentTime = 0f;
    bool isThereHaveSpace = false;


    private void Awake()
    {
        main = this;
    }

    private void Update()
    {
        StartCreateMaterial();

        if (Input.GetKeyDown(KeyCode.M))
        {
            materialCountOnPlayer = 100000;
        }
    }

    public void TakeMaterial()
    {
        if(materialCountBase > 0)
        {
            materialCountOnPlayer += 10;
            materialCountBase -= 10;
        }
    }

    public void SpendMaterial()
    {
        Tower towerToBuild = BuildManager.main.GetSelectedTower();
        if (materialCountOnPlayer >= towerToBuild.cost)
        {
            materialCountOnPlayer -= towerToBuild.cost;
        }
        else
        {
            Debug.Log("No material for build");
        }
    }

    public bool UpgradeMaterial(int amount)
    {
        if (amount <= materialCountOnPlayer)
        {
            //Upgrade
            materialCountOnPlayer -= amount;
            return true;
        }
        else
        {
            Debug.Log("Cant Upgraded");
            return false;
        }
    }

    public void LevelUPMaterialBase()
    {
        if (materialBaseLV < 5 && LevelManager.main.currency > (materialBaseLV*150))
        {
            materialBaseLV++;
            createMaterialTime--;
            Debug.Log("Material Base Lv: " + materialBaseLV);
            LevelManager.main.SpendCurrency(materialBaseLV * 150);
        }
    }

    public void StartCreateMaterial()
    {
        currentTime += Time.deltaTime;
        if(materialCountBase != 100)
        {
            if (currentTime > createMaterialTime)
            {
                currentTime = 0f;
                MaterialCreatingCount();
            }
        }
    }

    private void MaterialCreatingCount()
    {
        materialCountBase += 10;
    }

    private void OnGUI()
    {
        materialCountOnPlayerTXT.text= materialCountOnPlayer.ToString();
    }

}
