using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractSystem_AmmoBase : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;


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
