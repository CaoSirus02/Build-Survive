using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Events;

public class Plot : MonoBehaviour
{
    private GameObject towerObj;
    private Turret turret;

    private void Start()
    {
    }

    public void BuildTower()
    {

        Tower towerToBuild = BuildManager.main.GetSelectedTower();
        if ((towerToBuild.cost>LevelManager.main.currency))
        {
            Debug.Log("You Cant Affod This Tower");
            return;
        }

        LevelManager.main.SpendCurrency(towerToBuild.cost);

        towerObj = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
        turret = towerObj.GetComponent<Turret>();

    }

    
}
