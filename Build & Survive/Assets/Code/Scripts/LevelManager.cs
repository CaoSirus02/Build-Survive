using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager main;

    [Header("References")]
    [SerializeField] public Transform startPoint;
    [SerializeField] public Transform[] path;

    public int bulletLv = 1;


    public int currency;


    private void Awake()
    {
        main = this;
    }

    void Start()
    {
        currency = 100;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            currency = 100000;
        }
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if(amount <= currency) 
        {
            //Buy item
            currency -= amount;
            return true;
        }
        else
        {
            Debug.Log("You Cant Afford It");
            return false; 
        }
    }


}
