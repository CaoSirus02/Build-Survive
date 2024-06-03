using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{

    [SerializeField] Animator anim;
    [SerializeField] GameObject tier2;
    [SerializeField] GameObject tier3;
    private bool isMenuOpen = false;

    private void Update()
    {
        ActiveTurret();
    }

    public void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        anim.SetBool("MenuOpen",isMenuOpen);
    }

    public void SetSelected()
    {

    }

    public void ActiveTurret()
    {
        if(MaterialBase.main.materialBaseLV > 2 && AmmoBase.main.ammoBaseLV > 2)
        {
            tier2.SetActive(true);
        }
        if (MaterialBase.main.materialBaseLV == 5 && AmmoBase.main.ammoBaseLV == 5)
        {
            tier3.SetActive(true);
        }
    }
}
