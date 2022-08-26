using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Raket : MonoBehaviour
{
    public GameObject raket;

    public GameObject top;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(raket.transform.position);
    }

    private void OnEnable()
    {
        FingerGestures.OnFingerDown += FingerGestures_OnFingerDown;
    }

    private void FingerGestures_OnFingerDown(int fingerindex, Vector2 fingerpos)
    {
        if (raket.transform.eulerAngles.z != 0)
        {
            raket.transform.DORotate(new Vector3(0, 0, 0), 0.2f);
        }
        else
        {
            raket.transform.DORotate(new Vector3(0, 0, 180), 0.2f);
        }
    }

 

    // Update is called once per frame
    void Update()
    {
        
    }
}
