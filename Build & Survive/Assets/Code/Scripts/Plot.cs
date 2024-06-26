using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Events;

public class Plot : MonoBehaviour
{
    private GameObject towerObj;
    public Turret turret;
    public Turret2 turret2;
    public Turret3 turret3;

    [Header("References")]
    public AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
    }

    public void BuildTower()
    {

        Tower towerToBuild = BuildManager.main.GetSelectedTower();
        if ((towerToBuild.cost>MaterialBase.main.materialCountOnPlayer))
        {
            Debug.Log("You Cant Affod This Tower");
            return;
        }

        MaterialBase.main.SpendMaterial();

        audioManager.PlaySFX(audioManager.buildSFX);

        towerObj = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
        turret = towerObj.GetComponent<Turret>();
        turret2 = towerObj.GetComponent<Turret2>();
        turret3 = towerObj.GetComponent<Turret3>();

    }


}
