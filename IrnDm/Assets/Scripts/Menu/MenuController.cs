using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MenuItemType {StartGame, Difficulty, Exit}

public class MenuController : MonoBehaviour {

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

                break;
            case MenuItemType.Exit:
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
