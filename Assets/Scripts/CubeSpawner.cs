using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab;
    private GameObject generatedCube;
    public MeshRenderer cubeColor;

    
    // Start is called before the first frame update
    void Start()
    {
        generatedCube = Instantiate(cubePrefab, new Vector3(-0.44f, 3.66f, -2.616f), Quaternion.identity, transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     GenerateCube();  
    }

    void GenerateCube()
    {
        if (GameManager.currentBoxScore == 0)
        {
            int selectColor = Random.Range(0, 2);
            generatedCube.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = selectColor == 0 ? Color.red : Color.blue;
            GameManager.currentBoxScore =  Random.Range(1, 4);
        }
    }
}
