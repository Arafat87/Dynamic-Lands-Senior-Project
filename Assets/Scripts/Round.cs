using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Round : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI roundText;
    [SerializeField] public TextMeshProUGUI TimeText;

    public static Round instance;

    public int round = 1;
    public int enemyCount = 0;
    public int allAlive = 1;
    private int difficulty;
    private float playTime;



    private void Update()
    {
        roundText.text = "round: " + round.ToString();

        float t = Time.time - playTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        TimeText.text = minutes.ToString() + ":" + seconds.ToString();

     
    }


        private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;

    }

    public int getRound()
    {
        return this.round;

    }

    public float getTime()
    {
        return this.playTime;

    }

    public int increaseRound()
    {
        this.round = this.round + 1;
        return this.round;

    }

    public int increaseEnemy()
    {
        this.enemyCount = this.enemyCount + 1;
        return this.enemyCount;

    }

    public int decreaseEnemy()
    {
        this.enemyCount = this.enemyCount - 1;
        return this.enemyCount;

    }


    public int getEnemy()
    {
        return this.enemyCount;

    }

    public int getDifficulty()
    {
        return this.difficulty;

    }

    public int setDifficulty(int difficulty)
    {
        this.difficulty = difficulty;
        return difficulty;

    }

    public int changeStatus()
    {
        this.allAlive = 0;
        return this.allAlive;
    }


}
