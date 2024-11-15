using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemDisplay : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private Sprite itemOverview;

    [SerializeField] private int normalPrice;
    [SerializeField] private int premiumPrice;

    [SerializeField] private Text normalPriceDisplay;
    [SerializeField] private Text premiumPriceDisplay;

    [SerializeField] private bool bought;
    [SerializeField] private bool usedCurrently;

    [SerializeField] protected GameObject Check;
    [SerializeField] protected GameObject Cross;

    [SerializeField] private GameObject Locked;
    [SerializeField] private GameObject Unlocked;

    private GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Start()
    {
        this.gameObject.GetComponent<Image>().sprite = itemOverview;
        normalPriceDisplay.text = normalPrice.ToString();
        premiumPriceDisplay.text = premiumPrice.ToString();
        Unlocked.SetActive(false);
        Check.SetActive(false);

        if (bought)
        {
            normalPriceDisplay.text = null;
            premiumPriceDisplay.text = null;
        }
    }

    void FixedUpdate()
    {
        if(gameManager.currentArena||gameManager.currentBall||gameManager.currentCharacter||gameManager.currentWatcher == item)
        {
            Check.SetActive(true);
            Cross.SetActive(false);
        }
        else
        {
            Check.SetActive(false);
            Cross.SetActive(true);
        }
    }

    private int BuyItem(int currency, int price) 
    {
        if (currency >= price)
        {
            currency -= price;           
            bought = true;
            normalPriceDisplay.text = null;
            premiumPriceDisplay.text = null;
            Unlocked.SetActive(true);
            Locked.SetActive(false);
            return currency;
        }
        else
        {
            Debug.Log("BIEDAK!");
            return currency;
        }
    }

    public void BuyItemPremium()        //Buys the item for premium currency
    {
        if(!bought)
            gameManager.PremiumCurrency = BuyItem(gameManager.PremiumCurrency, premiumPrice);
        else
            Debug.Log("Posiadane");
    }
    public void BuyItemNormal()         //Buys the item for in game currency
    {
        if (!bought)
            gameManager.NormalCurrency = BuyItem(gameManager.NormalCurrency, normalPrice);
        else
            Debug.Log("Posiadane");
        Debug.Log(this.transform.parent.parent.name);
    }

    public void ItemReplacement()
    {
        if (bought)
        {
            if (transform.parent.parent.name == "CharacterPage")
            {
                Destroy(gameManager.currentCharacter);
                gameManager.currentCharacter = Instantiate(item);
            }
            else if (transform.parent.parent.name == "ArenaPage")
            {
                Destroy(gameManager.currentArena);
                gameManager.currentArena = Instantiate(item);
            }
            else if (transform.parent.parent.name == "WatcherPage")
            {
                Destroy(gameManager.currentWatcher);
                gameManager.currentWatcher = Instantiate(item);
            }
            else if (transform.parent.parent.name == "BallPage")
            {
                gameManager.currentBall = item;
            }
        }
        else
        {
            Debug.Log("Najpierw Kup");
        }
    }
}
