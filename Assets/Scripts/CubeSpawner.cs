using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public Cube cubePrefab;
    private GameObject generatedCube;
    public MeshRenderer cubeColor;
    public Cube[] cubeList;


    // Start is called before the first frame update
    void Awake()
    {
        for (var i = 0; i < cubeList.Length; i++)
        {
            Cube generatedCube = Instantiate(cubeList[i], new Vector3(-0.44f, 1.8f + i, -2.616f), Quaternion.identity, transform);
            int selectColor = Random.Range(0, 2);
            generatedCube.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = selectColor == 0 ? Color.red : Color.blue;
        }

        ((IList)cubeList).Add(cubePrefab);
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
            cubeList.Add(cubeMesh);
            GameManager.currentBoxScore = Random.Range(1, 4);
        }
    }
}
