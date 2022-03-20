using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeObjects : MonoBehaviour
{
    public int Price;
    public GameObject upgradeObj;
    public GameObject upgradedObj;
    public ParticleSystem upgradeEffect;

    public Text buyObjectText;
    private SoundManager _soundManager;
    [SerializeField]bool buyItemBool = true;

    void Awake()
    {
        buyObjectText.text = Price.ToString();
    }

    private void Start()
    {
        _soundManager = GameObject.FindObjectOfType<SoundManager>();

    }


    void OnTriggerEnter(Collider other)
    {
        buyItemBool = true;
        if (buyItemBool && other.CompareTag("Player"))
        {
            UpgradeControl();
                _soundManager.PlayerCashSound();
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        
        if ( other.CompareTag("Player"))
        {
            buyItemBool = false;
            Debug.Log("Trigger");
        }
    }
    public void UpgradeControl()
    {
        if (Price <= MoneyController.instance.money)
        {
            MoneyController.instance.BuyItem();
            StartCoroutine(UIChanged());

            if (Price == 0)
            {
            upgradeObj.SetActive(false);
            upgradedObj.SetActive(true);
            //gameObject.GetComponent<Collider>().enabled = false;
            //upgradeEffect.Play();
            }
           // buyItemBool = false;
        }
    }

        IEnumerator UIChanged()
    {
        if (buyItemBool == false)
        {
            yield break;
        }
        MoneyController.instance.BuyItem();
            yield return new WaitForSeconds(0.01f);
        if (Price==0)
        {
            UpgradeControl();
            yield break;
        }
       
            Price--;
            buyObjectText.text = Price.ToString();
           // buyItemBool=true;
         StartCoroutine(UIChanged());
    }

}