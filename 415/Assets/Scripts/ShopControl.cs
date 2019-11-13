using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControl : MonoBehaviour
{

    int moneyAmount;
    int isCrossSold;

    public Text moneyAmountText;
    public Text crossPrice;


    public Button buyButton;

    // Start is called before the first frame update
    void Start()
    {
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
    }

    // Update is called once per frame
    void Update()
    {
        moneyAmountText.text = "Money: " + moneyAmount.ToString() + "$";
        isCrossSold = PlayerPrefs.GetInt("IsCrossSold");

        if (moneyAmount >= 5 && isCrossSold == 0)
        {
            buyButton.interactable = true;
        } else
        {
            buyButton.interactable = false;
        }

         void buyCross()
        {
            moneyAmount -= 5;
            PlayerPrefs.SetInt("IsCrossSold", 1);
            crossPrice.text = "Sold!";
            buyButton.gameObject.SetActive(false);
        }

        void exitShop()
        {
            PlayerPrefs.SetInt("MoneyAmount", moneyAmount);
            SceneManager.LoadScene("GameScene");
        }

        void resetPlayerPrefs()
        {
            moneyAmount = 0;
            buyButton.gameObject.SetActive(true);
            crossPrice.text = "Price: 5$";
            PlayerPrefs.DeleteAll();
        }

    }
}
