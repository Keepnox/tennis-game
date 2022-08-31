using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public Cube cubePrefab;
    private GameObject generatedCube;
    public MeshRenderer cubeColor;
    private List<Cube> cubeList = new List<Cube>();


    // Start is called before the first frame update
    void Awake()
    {
     
        for (var i = 0; i < 5; i++)
        {
            Cube generatedCube = Instantiate(cubePrefab, new Vector3(-0.44f, 1.8f + i + (i*0.1f), -2.616f), Quaternion.identity, transform);
            int selectColor = Random.Range(0, 2);
            generatedCube.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = selectColor == 0 ? Color.red : Color.blue;
            cubeList.Add(generatedCube);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        GenerateCube();
    }

    void GenerateCube()
    {
        if (GameManager.Instance.currentBoxScore == 0)
        {
            DestroyImmediate(cubeList[0].gameObject, true);
            cubeList.Remove(cubeList[0]);
            GameManager.Instance.currentBoxScore = Random.Range(1, 4);
        }
    }
}
