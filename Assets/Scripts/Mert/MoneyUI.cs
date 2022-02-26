using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    #region instance Control

    public static MoneyUI instance;

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

    public TMP_Text moneyText;
    private void Update()
    {
        moneyText.text = MoneyController.instance.money.ToString();
    }

    private void Start()
    {
        moneyText.text = MoneyController.instance.money.ToString();
    }


}
