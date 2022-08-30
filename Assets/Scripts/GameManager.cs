using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static GameState State;
    public static int currentBoxScore;
    public static int GAMESPEED = 15;
    void Start()
    {
        Instance = this;
        currentBoxScore = Random.Range(1, 4);
        // Debug.Log("selam");
    }

    public static void gameOver()
    {
        State = GameState.GameOver;
    }
    public static void decreaseCurrentBoxScore()
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
