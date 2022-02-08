using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BantController : MonoBehaviour
{
    public float bantPeriodTime;

    public List<GameObject> bantBoxes;

    int bantCount;
    int bantIndex;

    public TakeOffAreaScript takeOffAreaScript;

    public GameObject takeOffBoxes;

    void Start()
    {
        bantCount = 0;
        bantIndex = 0;
    }

    void Update()
    {

        if (bantPeriodTime >= 0)
            bantPeriodTime -= Time.deltaTime;
        if (bantPeriodTime <= 0f && takeOffAreaScript.takeOffBoxAreaLine > 0)
        {
            bantBoxes[bantCount].gameObject.SetActive(true);
            if (bantCount <= takeOffAreaScript.takeOffBoxAreaLine)
            {
                bantCount++;
            }
            bantPeriodTime = 2f;
            Debug.Log(bantIndex);
            takeOffBoxes.transform.GetChild(bantIndex).transform.gameObject.SetActive(false);
            bantIndex++;
        }

    }
}
