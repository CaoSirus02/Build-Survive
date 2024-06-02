using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoBase : MonoBehaviour
{
    public static AmmoBase main;

    [Header("References")]
    [SerializeField] public int ammoCountPlayer = 0;
    [SerializeField] private int ammoCountBase = 10;
    [SerializeField] private TextMeshProUGUI ammoTXT;

    float createAmmoTime = 4f;
    float currentTime = 0f;
    bool isThereHaveSpace = false;

    private void Awake()
    {
        main = this;
    }

    private void Update()
    {
        StartCreateMaterial();
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

    private void AmmoCreatingCount()
    {
        ammoCountBase += 1;
    }

    private void OnGUI()
    {
        ammoTXT.text = ammoCountPlayer.ToString();
    }

}

