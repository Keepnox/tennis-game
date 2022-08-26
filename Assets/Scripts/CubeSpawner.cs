using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(cubePrefab, new Vector3(-0.44f, 3.66f, -2.616f), Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
