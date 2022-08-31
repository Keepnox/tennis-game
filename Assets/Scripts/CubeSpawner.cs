using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    


    // Start is called before the first frame update
    void Start()
    {

        GameManager.Instance.FirstCubeSpawner(transform);

    }

   

    
}
