using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyController : MonoBehaviour
{
    #region instance Control

    public static MoneyController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }
    #endregion

    public int money;

    void Start()
    {
        //If we earn money, should delete this line
        PlayerPrefs.SetInt("money",money);
        
        
        money = PlayerPrefs.GetInt("money");
    }

    public void BuyItem()
    {
        //StartCoroutine(BuyItemNumerator(buyValue));
        money -= 1;
        PlayerPrefs.SetInt("money",money);
    }

    public void SellItem(int sellValue)
    {
        StartCoroutine(SellItemNumerator(sellValue));
    }

    // IEnumerator BuyItemNumerator(int buyValueNum)
    // {
    //     for (int i = 1; i <= buyValueNum; i++)
    //     {
    //         yield return new WaitForSeconds(0.01f);
    //         money -= 1;
    //     }
    // }

    IEnumerator SellItemNumerator(int sellValueNum)
    {
        for (int i = 1; i <= sellValueNum; i++)
        {
            yield return new WaitForSeconds(0.01f);
            money += 1;
        }
    }


}
