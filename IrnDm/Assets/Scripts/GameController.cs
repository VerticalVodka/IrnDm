using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { MENU, PLAYING, PAUSED, ENDED }
public class GameController : MonoBehaviour {


    public float BaseSpeedms = 1000.0f;
    public int Score;
    public TargetSpawner targetSpawner;

    private GameState gameState = GameState.MENU;

	// Use this for initialization
	void Start () {
        
        targetSpawner.SpawnSpeed = BaseSpeedms/1000;
        StartGame();
	}

    // Update is called once per frame
    void Update () {
		
	}

    public void StartGame() {
        FindObjectOfType<MenuController>().HideMenu();
        targetSpawner.StartSpawning();
        this.gameState = GameState.PLAYING;
    }

    public void PauseGame() {
        FindObjectOfType<MenuController>().ShowMenu();
        targetSpawner.StopSpawning();
        //Show pause screen (e.g. HUD) with possibility to go to Menu
        this.gameState = GameState.PAUSED;
    }

    public void EndGame() {
        FindObjectOfType<MenuController>().ShowMenu();
        targetSpawner.StopSpawning();
        //Show result screen (e.g. HUD) with possibility to go to Menu
        this.gameState = GameState.ENDED;
    }

    public void OnMenu()
    {
        this.gameState = GameState.MENU;
    }

    public void IncScore() {
        Score++;
        Debug.Log(Score);
    }

    public void DecScore()
    {
        Score--;
    }
}
