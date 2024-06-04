using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoBase : MonoBehaviour
{
    public static AmmoBase main;

    [Header("References")]
    [SerializeField] private TextMeshProUGUI ammoTXT;
    [Header("Attributes")]
    [SerializeField] public int ammoBaseLV = 1;
    [SerializeField] public int ammoCountPlayer = 0;
    [SerializeField] private int ammoCountBase = 10;


    float createAmmoTime = 8f;
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
            ammoCountPlayer = 100000;
        }
    }

    public void TakeAmmo()
    {
        if(ammoCountBase  > 0)
        {
            ammoCountBase--;
            ammoCountPlayer++;
        }
    }

    public void StartCreateMaterial()
    {
        currentTime += Time.deltaTime;
        if (ammoCountBase != 10)
        {
            if (currentTime > createAmmoTime)
            {
                currentTime = 0f;
                AmmoCreatingCount();
            }
        }
    }

    public void UpgradeAmmoBaseLV()
    {
        if (ammoBaseLV < 5 && LevelManager.main.currency > (ammoBaseLV * 150))
        {
            ammoBaseLV++;
            createAmmoTime--;
            Debug.Log("Ammo Base Lv: " + ammoBaseLV);
            LevelManager.main.SpendCurrency(ammoBaseLV * 150);
        }
    }

    private void AmmoCreatingCount()
    {
        ammoCountBase += 1;
    }

    private void OnGUI()
    {
        ammoTXT.text = ammoCountPlayer.ToString();
    }

}

