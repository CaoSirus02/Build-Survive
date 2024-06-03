using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractSystem : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public bool turretPlaced;


    private void Update()
    {
        CheckTargetIsInRange();
    }

    private void CheckTargetIsInRange()
    {
        Tower towerToBuild = BuildManager.main.GetSelectedTower();
        if ((towerToBuild.cost <= MaterialBase.main.materialCountOnPlayer))
        {
            if (isInRange & !turretPlaced)
            {
                if (Input.GetKeyDown(interactKey))
                {
                    interactAction.Invoke();
                    turretPlaced = true;
                }
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player is now in range");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player is not now in range");
        }
    }
}
