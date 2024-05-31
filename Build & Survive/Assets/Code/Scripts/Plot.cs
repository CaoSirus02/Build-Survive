using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Plot : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 3f;

    private GameObject towerObj;
    private Turret turret;
    private Color startColor;
    private Transform targetPlayer;

    private void Start()
    {
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {

        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }
    private void OnMouseDown()
    {

        Tower towerToBuild = BuildManager.main.GetSelectedTower();
        if ((towerToBuild.cost>LevelManager.main.currency))
        {
            Debug.Log("You Cant Affod This Tower");
            return;
        }

        towerObj = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
        turret = towerObj.GetComponent<Turret>();

    }

    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(targetPlayer.position, transform.position) <= targetingRange;
    }
}
