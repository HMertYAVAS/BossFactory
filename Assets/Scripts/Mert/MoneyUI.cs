using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public static MoneyUI instance;


    public TMP_Text moneyText;
    public int money;

    private void Awake()
    {
        #region instance Control
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        #endregion

    }
    private void Update()
    {
        moneyText.text = money.ToString();
    }

    private void Start()
    {
        moneyText.text = money.ToString();
    }


}
