
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration data
    string[] level1Passwords = { "books", "aisle", "self", "password", "font", "borrow" };
    string[] level2Passwords = { "salmon", "group", "cream", "sushi", "unity", "meimei" };

    // Game state
    public int level, randomIndex;
    public string password;
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
        if (input == password){
            currentScreen = Screen.Win;
            Terminal.WriteLine("Well Done!");
        } else {
            Terminal.WriteLine("Incorrect Password");
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber) 
        {
            level = int.Parse(input);
            //password = level1Passwords[2];
            StartGame();
        }

        else if (input == "007")
        {
            Terminal.WriteLine("Hi Mr.bond ..");
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
        Terminal.ClearScreen();
        switch(level)
        {
            case 1:
                randomIndex = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[randomIndex];
                break;
            case 2:
                randomIndex = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[randomIndex];
                break;
            default:
                Debug.LogError("Invalid Level Number");
                break;
        }
        Terminal.WriteLine("Enter passoword >");
    }
}
