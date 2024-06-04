using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager main;

    [SerializeField] public int playerHealth = 10;
    [SerializeField] public GameObject GameOverScreen;

    private void Awake()
    {
        main = this;
    }

    private void Update()
    {
        GameOver();
    }

    private void GameOver()
    {
        if(playerHealth == 0)
        {
            //Game Over
            Time.timeScale = 0f;
            GameOverScreen.SetActive(true);
        }
    }
}
