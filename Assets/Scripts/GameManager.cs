using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static GameState State;
    public int currentBoxScore;
    public int GAMESPEED = 25;
    public float timeSpeed = 1;
    public bool isRaketRed = true;
    public bool isBallRed = true;
    public List<Cube> cubeList = new List<Cube>();
    public Cube cubePrefab;
    public Transform spawnerTransformController;
    public GameObject generatedCube;

    public float newCubePosition;
    // public MeshRenderer cubeColor;
    void Start()
    {
        Instance = this;
        currentBoxScore = Random.Range(1, 4);
    }

    
    private void Update()
    {
        Time.timeScale = timeSpeed;
    }

    
    public static void gameOver()
    {
        State = GameState.GameOver;
    }
    public void decreaseCurrentBoxScore()
    {
        
        if (currentBoxScore > 0)
        {
            currentBoxScore -= 1;
        }
        else
        {
            State = GameState.GameOver;
        }
    }

    public void FirstCubeSpawner(Transform spawnerTransform)
    {
        spawnerTransformController = spawnerTransform;
        for (int i = 0; i < 5; i++)
        {
            newCubePosition = 1.8f + i + (i * 0.1f);
            OneCubeSpawn(spawnerTransform, newCubePosition);
        }
    }

    private void OneCubeSpawn(Transform spawnerTransform, float ncb)
    {
        Cube generatedCube = Instantiate(cubePrefab, new Vector3(-0.44f, ncb, -2.616f),
            Quaternion.identity, spawnerTransform);
        int selectColor = Random.Range(0, 2);
        generatedCube.transform.GetChild(0).GetComponent<MeshRenderer>().material.color =
            selectColor == 0 ? Color.red : Color.blue;
        cubeList.Add(generatedCube);
    }

    public void DestroyAndSpawnCube(Cube cube)
    {
        if (currentBoxScore == 0)
        {
            Destroy(cube.gameObject);
            cubeList.Remove(cubeList[0]);            
            OneCubeSpawn(spawnerTransformController, cubeList[cubeList.Count-1].transform.position.y + 1.1f);
            currentBoxScore = Random.Range(1, 4);
            foreach (Cube cubes in cubeList)
            {
                cubes.gameObject.transform.DOMove(
                    new Vector3(-0.44f, cubes.gameObject.transform.position.y - 1.1f, -2.616f), 0.5f);
                 
            }

        }
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;
        switch (newState) 
        {
            case GameState.GameStart:
                break;
            case GameState.GameOver:
                break;
        }
    }
    
    public enum GameState
    {
        GameStart,
        GameOver,

    }
}
