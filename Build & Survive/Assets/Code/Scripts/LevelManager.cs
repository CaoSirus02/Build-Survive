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
        
    }

    void Update()
    {
        
    }
}
