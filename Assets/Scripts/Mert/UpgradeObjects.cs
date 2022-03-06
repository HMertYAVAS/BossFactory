using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeObjects : MonoBehaviour
{
    public int value;
    public GameObject upgradeObj;
    public GameObject upgradedObj;
    public ParticleSystem upgradeEffect;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UpgradeControl();
        }
    }


    public void UpgradeControl()
    {
        if (value <= MoneyController.instance.money)
        {
            MoneyController.instance.BuyItem(value);
            upgradeObj.SetActive(false);
            upgradedObj.SetActive(true);
            upgradeEffect.Play();
        }
    }
<<<<<<< HEAD
=======

>>>>>>> parent of 16b1b80 (Money)
}
