using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeObjects : MonoBehaviour
{
    public int value;
    public GameObject upgradeObj;
    public GameObject upgradedObj;
    public ParticleSystem upgradeEffect;

    public Text buyObjectText;
    bool buyItemBool = true;

    void Awake()
    {
        buyObjectText.text = value.ToString();
    }
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        if (buyItemBool && other.CompareTag("Player"))
        {
            UpgradeControl();
        }
    }


    public void UpgradeControl()
    {
        if (value <= MoneyController.instance.money)
        {
            MoneyController.instance.BuyItem();
            StartCoroutine(UIChanged());

            if (value == 1)
            {
            upgradeObj.SetActive(false);
            upgradedObj.SetActive(true);
            gameObject.GetComponent<Collider>().enabled = false;
            upgradeEffect.Play();
            }
            buyItemBool = false;
        }
    }

        IEnumerator UIChanged()
    {
            MoneyController.instance.BuyItem();
            yield return new WaitForSeconds(0.01f);
            value--;
            buyObjectText.text = value.ToString();
            buyItemBool=true;
    }

}