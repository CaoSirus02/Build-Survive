using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractSystem_MaterialBase : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public KeyCode interactKey2;
    public UnityEvent interactAction;
    public UnityEvent interactAction2;

    private void Update()
    {
        CheckTargetIsInRange();
    }

    private void CheckTargetIsInRange()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
            if (Input.GetKeyDown(interactKey2))
            {
                interactAction2.Invoke();
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player is now in range for AmmoBase");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player is not now in range for AmmoBase");
        }
    }
}
