using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI textim;
    // Start is called before the first frame update
    void Start()
    {
       
        textim = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        textim.text = GameManager.Instance.currentBoxScore.ToString();
    }
}
