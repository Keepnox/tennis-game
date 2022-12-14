using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random; 

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static GameState State;
    public int currentBoxScore;
    public float GAMESPEED = 25;
    public float timeSpeed = 1;
    public bool isRaketRed = true;
    public bool isBallRed = true;
    public bool currentCubeIsRed = true;
    public List<Cube> cubeList = new List<Cube>();
    public Cube cubePrefab;
    public Transform spawnerTransformController;
    public GameObject generatedCube;
    private float cubeXPos = 0f;
    private float gameTime = 0f;

    public float newCubePosition;
    // public MeshRenderer cubeColor;
    void Start()
    {
        Instance = this;
        currentBoxScore = Random.Range(1, 4);
        gameTime = Time.time;
    }

    
    private void Update()
    {
        Time.timeScale = timeSpeed;
        if (Time.time > gameTime)
        {
            gameTime = Time.time + 1;
            GAMESPEED += (gameTime * .07f);
        }
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
            newCubePosition = 6.5f + i + (i * 0.007f);
            OneCubeSpawn(spawnerTransform, newCubePosition);
        }
    }
    private void OneCubeSpawn(Transform spawnerTransform, float ncb)
    {
        Cube generatedCube = Instantiate(cubePrefab, new Vector3(cubeXPos, ncb, 0),
            Quaternion.identity, spawnerTransform);

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
                    new Vector3(cubeXPos, cubes.gameObject.transform.position.y - 1.1f, 0f), 0.5f);
                 
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
