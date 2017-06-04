using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuItemType {StartGame, Difficulty, Exit}

public class MenuController : MonoBehaviour {

    int difficulty = 0;
    private string[] difficulties = new string[] { "Easy", "Normal", "Bring it on", "Hard", "Thou shalt be ripped" };
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MenuItemHit(MenuItemType itemType) {
        switch (itemType)
        {
            case MenuItemType.StartGame:
                FindObjectOfType<GameController>().StartGame();
                break;
            case MenuItemType.Difficulty:
                difficulty = difficulty < 5 ? difficulty + 1 : 0;
                foreach (var item in GetComponentsInChildren<MenuBrick>())
                {
                    if (item.itemType == MenuItemType.Difficulty)
                    {
                        item.ChangeDisplayText("Difficulty:\n" + difficulties[difficulty]);
                    }
                }
                break;
            case MenuItemType.Exit:
                Debug.Log("EXIT"); //TODO swapped out with halt command
                break;
        }
    }

    public void HideMenu() {
        //Hide all children
    }

    public void ShowMenu()
    {
        //Show children
    }

    
}
