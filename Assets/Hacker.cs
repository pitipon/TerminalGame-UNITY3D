using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

	// Use this for initialization
	void Start () {
        
        ShowMainMenu();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShowMainMenu() {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Salmon World");
        Terminal.WriteLine("What would you like to Hack into");

        Terminal.WriteLine("Press 1 : Go to Basement");
        Terminal.WriteLine("Press 2 : Go to Laboratory");
        Terminal.WriteLine("Press 3 : Go to Weapon Storage");

        Terminal.WriteLine("Enter your selection >");
    }

    void OnUserInput(string input) {
        if (input == "menu") { // we can always go to MainMenu
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }



    }

    void CheckPassword(string input)
    {
        if (input == "salmon"){
            currentScreen = Screen.Win;
            Terminal.WriteLine("Welcome to Salmon Game");
        } else {
            Terminal.WriteLine("Incorrect Password");
        }
    }

    void RunMainMenu(string input)
    {
        if (input == "007")
        {
            Terminal.WriteLine("Hi Mr.bond ..");
        }
        else if (input == "1" || input == "2")
        {
            level = Int32.Parse(input);
            StartGame();
        }
        else if (input == "clear")
        {
            Terminal.ClearScreen();
        }
        else
        {
            Terminal.WriteLine("Please put sth ..");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Enter passoword >");
    }
}
