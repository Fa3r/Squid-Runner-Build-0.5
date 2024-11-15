using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private GameManager gameManager;
    private ScoreManager scoreManager;
    private CharacterControl characterControl;
    
    private GameObject canvas;

    #region UIobjects
    [SerializeField] private GameObject gameCurrency;
    [SerializeField] private GameObject premiumCurrency;
    [SerializeField] private GameObject currentCurrency;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject optionsButton;
    [SerializeField] private GameObject shopButton;
    [SerializeField] private GameObject adBlock;
    [SerializeField] private GameObject title;
    [SerializeField] private GameObject toMenu;

    [SerializeField] private GameObject shopCharacterPage;
    [SerializeField] private GameObject shopArenaPage;
    [SerializeField] private GameObject shopWatcherPage;
    [SerializeField] private GameObject shopBallPage;

    [SerializeField] private GameObject shopArenaPageButton;
    [SerializeField] private GameObject shopBallPageButton;
    [SerializeField] private GameObject shopCharacterPageButton;
    [SerializeField] private GameObject shopWatcherPageButton;
    #endregion
    private Text currentCurrencyText;
    private Text gameCurrencyText;
    private Text premiumCurrencyText;

    public int UIState = 0;


    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        characterControl = FindObjectOfType<CharacterControl>();
        canvas = this.gameObject;
        currentCurrencyText = currentCurrency.GetComponentInChildren<Text>();
        gameCurrencyText = gameCurrency.GetComponentInChildren<Text>();
        premiumCurrencyText = premiumCurrency.GetComponentInChildren<Text>();
    }


    void Update()
    {
        switch (UIState)
        {
            case 0:     //Main Menu
                mainMenuDisplayUI();
                break;
            case 1:     //Gameplay
                gameplayDisplayUI();
                break;
            case 2:
                shopDisplayUI();    //Shop
                break;
        }

        currentCurrencyText.text = ((int)scoreManager.currentScore).ToString();     //Displaying the current score on the screen
        gameCurrencyText.text = gameManager.NormalCurrency.ToString();               // Displaying current normal currency
        premiumCurrencyText.text = gameManager.PremiumCurrency.ToString();          // Displaying current premium currency

    }

    private void mainMenuDisplayUI()                        // There have to be another way. Find an optiomal way to do the UI system
    {
        gameCurrency.gameObject.SetActive(true);
        premiumCurrency.gameObject.SetActive(true);
        playButton.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
        shopButton.gameObject.SetActive(true);
        adBlock.gameObject.SetActive(true);
        title.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
        currentCurrency.gameObject.SetActive(false);
        toMenu.gameObject.SetActive(false);

        shopCharacterPage.gameObject.SetActive(false);
        shopArenaPage.gameObject.SetActive(false);
        shopWatcherPage.gameObject.SetActive(false);
        shopBallPage.gameObject.SetActive(false);

        shopArenaPageButton.gameObject.SetActive(false);
        shopBallPageButton.gameObject.SetActive(false);
        shopCharacterPageButton.gameObject.SetActive(false);
        shopWatcherPageButton.gameObject.SetActive(false);
    }

    private void gameplayDisplayUI()
    {
        gameCurrency.gameObject.SetActive(true);
        premiumCurrency.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        shopButton.gameObject.SetActive(false);
        adBlock.gameObject.SetActive(true);
        title.gameObject.SetActive(false);
        currentCurrency.gameObject.SetActive(true);

        shopCharacterPage.gameObject.SetActive(false);
        shopArenaPage.gameObject.SetActive(false);
        shopWatcherPage.gameObject.SetActive(false);
        shopBallPage.gameObject.SetActive(false);

        shopArenaPageButton.gameObject.SetActive(false);
        shopBallPageButton.gameObject.SetActive(false);
        shopCharacterPageButton.gameObject.SetActive(false);
        shopWatcherPageButton.gameObject.SetActive(false);

        if (gameManager.defeat || gameManager.finish)
        {
            restartButton.gameObject.SetActive(true);
            toMenu.gameObject.SetActive(true);
        }
        else
        {
            restartButton.gameObject.SetActive(false);
            toMenu.gameObject.SetActive(false);
        }
    }

    private void shopDisplayUI()
    {
        gameCurrency.gameObject.SetActive(true);
        premiumCurrency.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        shopButton.gameObject.SetActive(false);
        adBlock.gameObject.SetActive(true);
        title.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        currentCurrency.gameObject.SetActive(false);
        toMenu.gameObject.SetActive(true);

        shopArenaPageButton.gameObject.SetActive(true);
        shopBallPageButton.gameObject.SetActive(true);
        shopCharacterPageButton.gameObject.SetActive(true);
        shopWatcherPageButton.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        UIState = 1; 
        gameManager.restart();
    }       //Button function for starting the game

    public void RestartGame()
    {
        UIState = 1;
        gameManager.restart();
    }       //Button function for restarting the game

    public void EnterShop()
    {
        UIState = 2;
    }

    public void EnterMenu()
    {
        UIState = 0;
        gameManager.restart();
    }

    public void EnterArenaPage()
    {
        shopArenaPage.gameObject.SetActive(true);
        shopBallPage.gameObject.SetActive(false);
        shopCharacterPage.gameObject.SetActive(false);
        shopWatcherPage.gameObject.SetActive(false);
    }
    public void EnterBallPage()
    {
        shopArenaPage.gameObject.SetActive(false);
        shopBallPage.gameObject.SetActive(true);
        shopCharacterPage.gameObject.SetActive(false);
        shopWatcherPage.gameObject.SetActive(false);
    }
    public void EnterCharacterPage()
    {
        shopArenaPage.gameObject.SetActive(false);
        shopBallPage.gameObject.SetActive(false);
        shopCharacterPage.gameObject.SetActive(true);
        shopWatcherPage.gameObject.SetActive(false);
    }
    public void EnterWatcherPage()
    {
        shopArenaPage.gameObject.SetActive(false);
        shopBallPage.gameObject.SetActive(false);
        shopCharacterPage.gameObject.SetActive(false);
        shopWatcherPage.gameObject.SetActive(true);
    }

}
