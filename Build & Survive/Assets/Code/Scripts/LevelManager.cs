using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager main;

    [SerializeField] public Transform startPoint;
    [SerializeField] public Transform[] path;

    public int currency;


    private void Awake()
    {
        main = this;
    }

    void Start()
    {
        currency = 100;
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
