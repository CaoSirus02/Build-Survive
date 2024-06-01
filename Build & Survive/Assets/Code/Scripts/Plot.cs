using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Events;

public class Plot : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    [SerializeField] private LayerMask groundMask;

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

    private void Update()
    {
    }

    private void OnMouseEnter()
    {

        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }
    public void OnMouseDown()
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

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange,
            (Vector2)transform.position, 0f, groundMask);
        if (hits.Length > 0)
        {
            targetPlayer = hits[0].transform;
        }
    }

    
}
