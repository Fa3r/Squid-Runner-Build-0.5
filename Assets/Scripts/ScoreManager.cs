using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] public float currentScore;      //Current score during the run
    [SerializeField] private float sprintMultiplier = 1;      //Increments the score received
    [SerializeField] private float multiplierIncrease;      // Increases the sprintMultiplier when the player moves
    [SerializeField] private float multiplierDecrease;      // Decreases the sprintMultiplier when the player doesn't move
    [SerializeField] private float incrementValue;       //Amount of points earned every fixed amount of time
    [SerializeField] private float increaseFrequency;       //Once clock will reach this number it will increase the current score acording to a formula
    [SerializeField] private float clock;

    public CharacterControl characterControl;
    public GameManager gameManager;


    void Awake()
    {
        Assert.AreEqual(1, sprintMultiplier);
        Assert.IsTrue(multiplierIncrease>0);
        Assert.IsTrue(multiplierDecrease>0);
        Assert.IsTrue(incrementValue>0);
        Assert.IsTrue(increaseFrequency>0);
    }

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); 
    }

    void FixedUpdate()
    {
        clock += Time.deltaTime;
        gettingScore();
        multiplierHandler();

    }

    private void gettingScore()     //increase score if the speed is > than 0
    {
        if (characterControl.speed > 0 && clock > increaseFrequency)
        {
            currentScore += incrementValue * sprintMultiplier;
            clock = 0;
        }
    }

    private void multiplierHandler() //increase multiplier if the speed is > than 0
    {
        if(characterControl.speed>0)
            sprintMultiplier += multiplierIncrease;
        else if(sprintMultiplier>1)
            sprintMultiplier -= multiplierDecrease;
    }

    public void AddToTotalScore()       // ads the run score to the total score
    {
        gameManager.NormalCurrency +=  (int)currentScore;
        RestartScore();
    }

    public void RestartScore()      // resets the current score and sprint multiplier
    {
        currentScore = 0;
        sprintMultiplier = 1;
        clock = 0;
    }
}
