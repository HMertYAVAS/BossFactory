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


    public void BuyItem(int buyValue)
    {
        StartCoroutine(BuyItemNumerator(buyValue));
    }

    public void SellItem(int sellValue)
    {
        StartCoroutine(SellItemNumerator(sellValue));
    }

    IEnumerator BuyItemNumerator(int buyValueNum)
    {
        for (int i = 1; i <= buyValueNum; i++)
        {
            yield return new WaitForSeconds(0.01f);
            money -= 1;
        }
    }
    IEnumerator SellItemNumerator(int sellValueNum)
    {
        for (int i = 1; i <= sellValueNum; i++)
        {
            yield return new WaitForSeconds(0.01f);
            money += 1;
        }
    }


}
