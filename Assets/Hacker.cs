
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game configuration data
    const string menuHint = "You may type menu at anytime.";
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

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
  /-------/
 /_______/
(_______)
                ");
                break;
            case 2:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
  /-------/////
 /_______/////
(_______)
                ");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }

    }

    void CheckPassword(string input)
    {
        if (input == password){
            currentScreen = Screen.Win;
            DisplayWinScreen();
        } else {
            AskForPassword();
        }
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber) 
        {
            level = int.Parse(input);
            //password = level1Passwords[2];
            AskForPassword();
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
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter passoword, hint: " + password.Anagram() + " >");
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
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
    }
}
