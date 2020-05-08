using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipProject
{
    class Program
    {
        // This code is hard to read, sorry in advance.
        // Having multiple functions makes this much easier for me. 
        // As a python developer i'm used to this. I understand if it's not the right way to do things.
        // I also understand I could be doing alot of this more efficiently, but I have close to no experience with C#
        // Initialize gameplay variables etc...
        static int difficulty = 1;
        static int purchasedEagle = 0;
        static int purchasedBinoculars = 0;
        static int purchasedArtillery = 0;
        static int playerCurrency;
        static int playerPoints = 0;
        static int debugMode;
        static int xCoords;
        static int yCoords;
        static Random tileGen = new Random();
        static string name;
        static int cannonBalls = 10;
        static List<int> enemyTilesX = new List<int>();
        static List<int> enemyTilesY = new List<int>();
        // Difficulty stuff, not finished.
        static Random shipNumber = new Random();
        static int easyDifficulty = 3;
        static int mediumDifficulty = 4;
        static int hardDifficulty = 5;
        static int shipNumberEasy = easyDifficulty;
        static int shipNumberMedium = mediumDifficulty;
        static int shipNumberHard = hardDifficulty;
        static int healthPointsEasy = easyDifficulty + 3;
        static int healthPointsMedium = mediumDifficulty + 2;
        static int healthPointsHard = hardDifficulty + 1;
        // Saving user inputs **WHEN STARTING A NEW GAME RESET THESE ANTHONY**
        static List<int> userInputX = new List<int>();
        static List<int> userInputY = new List<int>();

        static void Main(string[] args)
        {
            
            Console.WriteLine("Would you like to enable debug mode? \n [1] Yes \n [2] No \n : ");
            debugMode = Int32.Parse(Console.ReadLine());
            if (debugMode == 1)
            {
                startGame();
            }
            else if( debugMode == 2)
            {
                startGame();
            }
            else
            {
                startGame();
            }
        }

        static void generateEnemyTiles()
        {
            //Self explanatory

            if (difficulty == 1)
            {
                for (int i = 0; i <= easyDifficulty - 1; i++)
                {

                    enemyTilesX.Add(tileGen.Next(1, 11));
                    enemyTilesY.Add(tileGen.Next(1, 6));

                }
            }
            else if (difficulty == 2)
            {
                for (int i = 0; i <= mediumDifficulty - 1; i++)
                {

                    enemyTilesX.Add(tileGen.Next(1, 11));
                    enemyTilesY.Add(tileGen.Next(1, 6));

                }
            }
            else if (difficulty == 3)
            {
                for (int i = 0; i <= hardDifficulty - 1; i++)
                {

                    enemyTilesX.Add(tileGen.Next(1, 11));
                    enemyTilesY.Add(tileGen.Next(1, 6));

                }
            }

        }

        static void startGame()
        {
            //Restoring defaults
            shipNumberEasy = easyDifficulty;
            shipNumberMedium = mediumDifficulty;
            shipNumberHard = hardDifficulty;
            healthPointsEasy = easyDifficulty + 3;
            healthPointsMedium = mediumDifficulty + 3;
            healthPointsHard = hardDifficulty + 3;
            if (debugMode == 1)
            {
                cannonBalls = 9999999;
            }
            else if (debugMode == 2)
            {
                if (difficulty == 1)
                {
                    // Easy cannon loadout
                    cannonBalls = 20;
                }
                else if (difficulty == 2)
                {
                    // Medium cannon loadout
                    cannonBalls = 23;
                }
                else if (difficulty == 3)
                {
                    // Hard cannon loadout
                    cannonBalls = 26;
                }
            }
            enemyTilesX.Clear();
            enemyTilesY.Clear();
            userInputX.Clear();
            userInputY.Clear();

            Console.Clear();
            // Calls the function to generate the enemy tiles.
            generateEnemyTiles();

            if(difficulty <= 1)
            {
                Console.WriteLine("Please Enter Your Name: ");
                name = Console.ReadLine();
                if (name == "")
                {
                    Console.WriteLine("You need to enter something as your name!");
                    System.Threading.Thread.Sleep(2000);
                    startGame();
                }
            }
            Console.Clear();
            Console.WriteLine("Hello " + name + "!" + " Welcome to battleship! \n");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("How to play:");
            Console.WriteLine("You must choose co-ordinates within (X: 10,Y: 5) \n e.g (3,4)");
            if (difficulty == 1)
            { 
                Console.WriteLine("There are " + easyDifficulty + " pirate ships approaching on the horizon!");
                Console.WriteLine("[+] You are playing EASY difficulty!");
            }
            else if (difficulty == 2)
            {
                Console.WriteLine("There are " + mediumDifficulty + " pirate ships approaching on the horizon!");
                Console.WriteLine("[+] You are playing MEDIUM difficulty!");
            }
            else if (difficulty == 3)
            {
                Console.WriteLine("There are " + hardDifficulty + " pirate ships approaching on the horizon!");
                Console.WriteLine("[+] You are playing HARD difficulty!");
            }
            Console.WriteLine("Take them out before they eliminate you!");
            if (debugMode == 1)
            {
                Console.WriteLine("[+] Debug mode enabled!");
                Console.WriteLine("Debug " + shipNumberEasy);
                Console.WriteLine(String.Join("; ", enemyTilesX));
                Console.WriteLine(String.Join("; ", enemyTilesY));
            }
            else
            {
            }
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            // The chooseXCord & chooseYCord functions are my loopholes to errors I couldn't fix.
            chooseXCoord();

        }


        static void chooseXCoord()
        {
            // I encountered this error so many times and couldn't figure out how to fix it, so I just made an exception handler.
            try
            {
                // Asks the player for their X Co-Ordinates
                Console.WriteLine("Please enter X Co-ordinates: ");
                xCoords = Int32.Parse(Console.ReadLine());
                // Basic handling to make sure that we get the right values
                if (xCoords > 10 || xCoords <= 0)
                {
                    Console.WriteLine("[!] Your Y Co-ordinates must be under 5!");
                    chooseXCoord();
                }

                else if (xCoords <= 10)
                {
                    Console.WriteLine("Your X Co-ordinate is " + xCoords);
                    // Saves value and goes to the Y Co-Ordinate selector
                    chooseYCoord();
                }
            }
            catch(System.FormatException)
            {
                // Stupid Error!!!!!!!!!!
                Console.Clear();
                Console.WriteLine("[+] Eeek! \n Encountered an error!");
                Console.WriteLine("[+] This happened because you either didn't type a value before pressing enter, or you entered an invalid number.");
                Console.WriteLine("[+] You will have to restart the program.");
                Console.WriteLine("[+] Press Enter to exit.");
                Console.ReadLine();
            }


        }
        static void chooseYCoord()
        {
            // I encountered this error so many times and couldn't figure out how to fix it, so I just made an exception handler.
            try
            {
                // Asks the player for their Y Co-Ordinates
                Console.WriteLine("Please enter Y Co-ordinates: ");
                yCoords = Int32.Parse(Console.ReadLine());
                // More basic handling to make sure that we get the right values
                if (yCoords > 5 || yCoords <= 0)
                {
                    Console.WriteLine("[!] Your Y Co-ordinates must be under 5!");
                    chooseYCoord();
                }

                else if (yCoords <= 5)
                {
                    Console.WriteLine("Your Y Co-ordinate is " + yCoords);
                    // Goes to gameplay function
                    mainGame();
                }
            }

            catch (System.FormatException)
            {
                // Stupid Error!!!!!!!!!!
                Console.Clear();
                Console.WriteLine("[+] Eeek! \n [+] You encountered an error!");
                Console.WriteLine("[+] This happened because you either didn't type a value before pressing enter, or entered an inavlid number.");
                Console.WriteLine("[+] You will have to restart the program.");
                Console.WriteLine("[+] Press Enter to exit.");
                Console.ReadLine();
            }

        }

        static void saveUserInput()
        {
            // Easy cannon loadout
            if (cannonBalls <= 20)
            {
                userInputX.Add(xCoords);
                userInputY.Add(yCoords);
            }

        }
       

        static void mainGame()
        {
            Console.Clear();
            // Calls the dumb function to save the X & Y coords.
            saveUserInput();

            // Defining variables for use
            Random rnd = new Random();
            string shotChoice = xCoords + "" + yCoords;
            int shopChoice;
            // Removes one cannon ball! :)
            cannonBalls--;

            // Setting ship number on board
            // Checking for list count to avoid System.ArgumentOutOfRange error that was occuring previously.
            if (enemyTilesX.Count == 3)
            {
                if (shotChoice == enemyTilesX.First() + "" + enemyTilesY.First() ||
                shotChoice == enemyTilesX.ElementAt(1) + "" + enemyTilesY.ElementAt(1) ||
                 shotChoice == enemyTilesX.ElementAt(2) + "" + enemyTilesY.ElementAt(2))
                {
                    shipNumberEasy--;
                }
                else
                {
                }
            }
            else if (enemyTilesX.Count == 2)
            {
                if (shotChoice == enemyTilesX.First() + "" + enemyTilesY.First() ||
                shotChoice == enemyTilesX.ElementAt(1) + "" + enemyTilesY.ElementAt(1))
                {
                    shipNumberEasy--;
                }
                else
                {
                }
            }
            else if (enemyTilesX.Count <= 1)
            {
                if (shotChoice == enemyTilesX.First() + "" + enemyTilesY.First())
                {
                    shipNumberEasy--;
                }
                else
                {
                }
            }

            // Checks if we're out of cannon balls to call end game method.
            if (cannonBalls <= 0)
            {
                gameOver(1);
            }
            else
            {
            }


            Console.Clear();
            // Gameplay function here. 
            int shipsShootBackEasy = rnd.Next(1, 9);
            int shipsShootBackMedium = rnd.Next(1, 7);
            int shipsShootBackHard = rnd.Next(1, 6);
            // Enemies shoot you!!! >:)
            if (difficulty == 1)
            {
                if (shipsShootBackEasy == 4)
                {
                    Console.WriteLine("*CRASH* A cannon ball has gone through your ship! \n You have been hit by an enemy pirate! \n Your health decreases by 1");
                    Console.WriteLine("[+] Press ENTER to continue...");
                    healthPointsEasy--;
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("*CRACK* You see a cannon ball fly past your ship! \n The enemy pirates have missed you this turn!");
                    Console.WriteLine();
                }
            }
            else if (difficulty == 2)
            {
                if (shipsShootBackMedium == 4)
                {
                    Console.WriteLine("*CRASH* A cannon ball has gone through your ship! \n You have been hit by an enemy pirate! \n Your health decreases by 1");
                    Console.WriteLine("[+] Press ENTER to continue...");
                    healthPointsEasy--;
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("*CRACK* You see a cannon ball fly past your ship! \n The enemy pirates have missed you this turn!");
                    Console.WriteLine();
                }
            }
            else if (difficulty == 3)
            {
                if (shipsShootBackHard == 4)
                {
                    Console.WriteLine("*CRASH* A cannon ball has gone through your ship! \n You have been hit by an enemy pirate! \n Your health decreases by 1");
                    Console.WriteLine("[+] Press ENTER to continue...");
                    healthPointsEasy--;
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("*CRACK* You see a cannon ball fly past your ship! \n The enemy pirates have missed you this turn!");
                    Console.WriteLine();
                }
            }
            if(difficulty == 1)
            {
                if (cannonBalls == 10)
                {
                    Console.WriteLine("[+] You see the smoke from an enemy's cannon on the horizon! You record it as X:" + enemyTilesX.First());
                }
                else if (cannonBalls == 1 )
                {
                    Console.WriteLine("[+] You see the smoke from an enemy's cannon on the horizon! You record it as X:" + enemyTilesX.First());
                }
                else if (cannonBalls == 2)
                {
                    Console.WriteLine("[+] You see the smoke from an enemy's cannon on the horizon! You record it as X:" + enemyTilesX.First());
                }
            }
            else if (difficulty == 2)
            {
                if (cannonBalls == 11)
                {
                    Console.WriteLine("[+] You see the smoke from an enemy's cannon on the horizon! You record it as X:" + enemyTilesX.First());
                }
                else if (cannonBalls == 1)
                {
                    Console.WriteLine("[+] You see the smoke from an enemy's cannon on the horizon! You record it as X:" + enemyTilesX.First());
                }
                else if (cannonBalls == 2)
                {
                    Console.WriteLine("[+] You see the smoke from an enemy's cannon on the horizon! You record it as X:" + enemyTilesX.First());
                }
            }
            else if (difficulty == 3)
            {
                if (cannonBalls == 13)
                {
                    Console.WriteLine("[+] You see the smoke from an enemy's cannon on the horizon! You record it as X:" + enemyTilesX.First());
                }
                else if (cannonBalls == 1)
                {
                    Console.WriteLine("[+] You see the smoke from an enemy's cannon on the horizon! You record it as X:" + enemyTilesX.First());
                }
                else if (cannonBalls == 2)
                {
                    Console.WriteLine("[+] You see the smoke from an enemy's cannon on the horizon! You record it as X:" + enemyTilesX.First());
                }
            }
            // Check if HP is empty to end game
            if (healthPointsEasy <= 0)
            {
                gameOver(2);
            }
            
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            if (xCoords == 1 + enemyTilesX.First() || 1 - xCoords == enemyTilesX.First())
            {
                Console.WriteLine("Your shot on the X Co-Ordinates almost hit an enemy ship! ");
            }
            if (yCoords == 1 + enemyTilesY.First() || 1 - yCoords == enemyTilesY.First())
            {
                Console.WriteLine("Your shot on the Y Co-Ordinates almost hit an enemy ship! ");
            }
            Console.WriteLine("You shot at (" + xCoords + "," + yCoords + ")!");
            // Grammar 
            if (purchasedEagle == 1)
            {
                Console.WriteLine("*SCREECH* Your eagle has come back to you with the X co-ordinates of one pirate!");
                Console.WriteLine("The X-Coordinates are: " + enemyTilesX.First());
                purchasedEagle--;
            }
            if (purchasedBinoculars == 1) 
            {
                Console.WriteLine("[+] You spot an enemy's position with your binoculars!");
                Console.WriteLine("[+] It seems they are at: " + enemyTilesX.ElementAt(2) + "," + enemyTilesY.ElementAt(2) + "!");
                purchasedBinoculars--;
            }
            if (purchasedArtillery == 1)
            {
                Console.WriteLine("[+] You see a large splash in the horizon!");
                Console.WriteLine("[+] It seems your artillery has destroyed a ship at:" + enemyTilesX.First() + "," + enemyTilesY.First() + "!");
                enemyTilesX.RemoveRange(0,1); enemyTilesY.RemoveRange(0,1);
                purchasedArtillery--;
            }   
            if (cannonBalls > 1)
            {
                Console.WriteLine("You have " + cannonBalls + " Cannon Balls left!");
            }
            else if (cannonBalls <= 1)
            {
                Console.WriteLine("You have " + cannonBalls + " Cannon Ball left!");
            }
            if (playerCurrency > 1 || playerCurrency < 1)
            {
                Console.WriteLine("You have " + playerCurrency + " doubloons!");
            }
            else if (playerCurrency == 1)
            {
                Console.WriteLine("You have " + playerCurrency + " doubloon!");
            }
            if (difficulty == 1)
            {
                Console.WriteLine("You have " + healthPointsEasy + " Health Points left!");
                Console.WriteLine("There are " + shipNumberEasy + "/" + easyDifficulty + " enemies left!");
            }
            else if (difficulty == 2)
            {
                Console.WriteLine("You have " + healthPointsMedium + " Health Points left!");
                Console.WriteLine("There are " + shipNumberMedium + "/" + mediumDifficulty + " enemies left!");
            }
            else if (difficulty == 3)
            {
                Console.WriteLine("You have " + healthPointsHard + " Health Points left!");
                Console.WriteLine("There are " + shipNumberHard + "/" + hardDifficulty + " enemies left!");
            }
            if (debugMode == 1)
            {
                Console.WriteLine("[+] When Debug mode is enabled, previous shots won't be added to the board.");
            }
            Console.WriteLine("Previous shots:");
            Console.WriteLine(String.Join("; ", userInputX));
            Console.WriteLine(String.Join("; ", userInputY));
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            if (playerCurrency >= 2)
            {
                Console.WriteLine("You have enough doubloons! Would you like to go to the item shop? \n[1] Yes \n[2] No");
                shopChoice = Int32.Parse(Console.ReadLine());
                if (shopChoice == 1)
                {
                    itemShop();
                }
                else
                {
                }
            }
            if (shipNumberEasy == 0)
            {
                gameOver(3);
            }
            // Find out if we hit the ships or not!
            // Checking for list count to avoid System.ArgumentOutOfRange error that was occuring previously.
            
            if (enemyTilesX.Count == 3)
            {
                if (shotChoice == enemyTilesX.First() + "" + enemyTilesY.First())
                {
                    enemyTilesX.RemoveRange(0, 1);
                    enemyTilesY.RemoveRange(0, 1);
                    Console.WriteLine("*BANG* You hit an enemy pirate!");
                    Console.WriteLine("You gain a cannonball!");
                    cannonBalls++;
                    Console.WriteLine("+1 Doubloon!");
                    playerCurrency++;
                    playerPoints++;
                    Console.WriteLine("Press ENTER to take another shot...");
                    Console.ReadLine();
                    chooseXCoord();
                }
                else if (shotChoice == enemyTilesX.ElementAt(1) + "" + enemyTilesY.ElementAt(1))
                {
                    enemyTilesX.RemoveRange(1, 1);
                    enemyTilesY.RemoveRange(1, 1);
                    Console.WriteLine("*BANG* You hit an enemy pirate!");
                    Console.WriteLine("You gain a cannonball!");
                    cannonBalls++;
                    Console.WriteLine("+1 Doubloon!");
                    playerCurrency++;
                    playerPoints++;
                    Console.WriteLine("Press ENTER to take another shot...");
                    Console.ReadLine();
                    chooseXCoord();
                }
                else if (shotChoice == enemyTilesX.ElementAt(2) + "" + enemyTilesY.ElementAt(2))
                {
                    enemyTilesX.RemoveRange(2, 1);
                    enemyTilesY.RemoveRange(2, 1);
                    Console.WriteLine("*BANG* You hit an enemy pirate!");
                    Console.WriteLine("You gain a cannonball!");
                    cannonBalls++;
                    Console.WriteLine("+1 Doubloon!");
                    playerCurrency++;
                    playerPoints++;
                    Console.WriteLine("Press ENTER to take another shot...");
                    Console.ReadLine();
                    chooseXCoord();
                }
                else
                {
                    Console.WriteLine("*SPLASH* You missed :(");
                    Console.WriteLine("press ENTER to take another shot...");
                    Console.ReadLine();
                    chooseXCoord();
                }
            }
            else if (enemyTilesX.Count == 4)
            {
                if (shotChoice == enemyTilesX.First() + "" + enemyTilesY.First())
                {
                    enemyTilesX.RemoveRange(0, 1);
                    enemyTilesY.RemoveRange(0, 1);
                    Console.WriteLine("*BANG* You hit an enemy pirate!");
                    Console.WriteLine("You gain a cannonball!");
                    cannonBalls++;
                    Console.WriteLine("+1 Doubloon!");
                    playerCurrency++;
                    playerPoints++;
                    Console.WriteLine("Press ENTER to take another shot...");
                    Console.ReadLine();
                    chooseXCoord();
                }
                else if (shotChoice == enemyTilesX.ElementAt(1) + "" + enemyTilesY.ElementAt(1))
                {
                    enemyTilesX.RemoveRange(1, 1);
                    enemyTilesY.RemoveRange(1, 1);
                    Console.WriteLine("*BANG* You hit an enemy pirate!");
                    Console.WriteLine("You gain a cannonball!");
                    cannonBalls++;
                    Console.WriteLine("+1 Doubloon!");
                    playerPoints++;
                    playerCurrency++;
                    Console.WriteLine("Press ENTER to take another shot...");
                    Console.ReadLine();
                    chooseXCoord();
                }
                else if (shotChoice == enemyTilesX.ElementAt(1) + "" + enemyTilesY.ElementAt(2))
                {
                    enemyTilesX.RemoveRange(1, 1);
                    enemyTilesY.RemoveRange(1, 1);
                    Console.WriteLine("*BANG* You hit an enemy pirate!");
                    Console.WriteLine("You gain a cannonball!");
                    cannonBalls++;
                    Console.WriteLine("+1 Doubloon!");
                    playerCurrency++;
                    playerPoints++;
                    Console.WriteLine("Press ENTER to take another shot...");
                    Console.ReadLine();
                    chooseXCoord();
                }
                else if (shotChoice == enemyTilesX.ElementAt(1) + "" + enemyTilesY.ElementAt(3))
                {
                    enemyTilesX.RemoveRange(1, 1);
                    enemyTilesY.RemoveRange(1, 1);
                    Console.WriteLine("*BANG* You hit an enemy pirate!");
                    Console.WriteLine("You gain a cannonball!");
                    cannonBalls++;
                    Console.WriteLine("+1 Doubloon!");
                    playerCurrency++;
                    playerPoints++;
                    Console.WriteLine("Press ENTER to take another shot...");
                    Console.ReadLine();
                    chooseXCoord();
                }
                else
                {
                    Console.WriteLine("*SPLASH* You missed :(");
                    Console.WriteLine("press ENTER to take another shot...");
                    Console.ReadLine();
                    chooseXCoord();
                }
            }
            else if (enemyTilesX.Count == 5)
            {
                if (shotChoice == enemyTilesX.First() + "" + enemyTilesY.First())
                {
                    enemyTilesX.RemoveRange(0, 1);
                    enemyTilesY.RemoveRange(0, 1);
                    Console.WriteLine("*BANG* You hit an enemy pirate!");
                    Console.WriteLine("You gain a cannonball!");
                    cannonBalls++;
                    Console.WriteLine("+1 Doubloon!");
                    playerCurrency++;
                    playerPoints++;
                    Console.WriteLine("Press ENTER to take another shot...");
                    Console.ReadLine();
                    chooseXCoord();
                }
                else if (shotChoice == enemyTilesX.ElementAt(1) + "" + enemyTilesY.ElementAt(1))
                {
                    enemyTilesX.RemoveRange(1, 1);
                    enemyTilesY.RemoveRange(1, 1);
                    Console.WriteLine("*BANG* You hit an enemy pirate!");
                    Console.WriteLine("You gain a cannonball!");
                    cannonBalls++;
                    Console.WriteLine("+1 Doubloon!");
                    playerCurrency++;
                    playerPoints++;
                    Console.WriteLine("Press ENTER to take another shot...");
                    Console.ReadLine();
                    chooseXCoord();
                }
                else if (shotChoice == enemyTilesX.ElementAt(1) + "" + enemyTilesY.ElementAt(2))
                {
                    enemyTilesX.RemoveRange(1, 1);
                    enemyTilesY.RemoveRange(1, 1);
                    Console.WriteLine("*BANG* You hit an enemy pirate!");
                    Console.WriteLine("You gain a cannonball!");
                    cannonBalls++;
                    Console.WriteLine("+1 Doubloon!");
                    playerCurrency++;
                    playerPoints++;
                    Console.WriteLine("Press ENTER to take another shot...");
                    Console.ReadLine();
                    chooseXCoord();
                }
                else if (shotChoice == enemyTilesX.ElementAt(1) + "" + enemyTilesY.ElementAt(3))
                {
                    enemyTilesX.RemoveRange(1, 1);
                    enemyTilesY.RemoveRange(1, 1);
                    Console.WriteLine("*BANG* You hit an enemy pirate!");
                    Console.WriteLine("You gain a cannonball!");
                    cannonBalls++;
                    Console.WriteLine("+1 Doubloon!");
                    playerCurrency++;
                    playerPoints++;
                    Console.WriteLine("Press ENTER to take another shot...");
                    Console.ReadLine();
                    chooseXCoord();
                }
                else if (shotChoice == enemyTilesX.ElementAt(1) + "" + enemyTilesY.ElementAt(4))
                {
                    enemyTilesX.RemoveRange(1, 1);
                    enemyTilesY.RemoveRange(1, 1);
                    Console.WriteLine("*BANG* You hit an enemy pirate!");
                    Console.WriteLine("You gain a cannonball!");
                    cannonBalls++;
                    Console.WriteLine("+1 Doubloon!");
                    playerCurrency++;
                    playerPoints++;
                    Console.WriteLine("Press ENTER to take another shot...");
                    Console.ReadLine();
                    chooseXCoord();
                }
                else
                {
                    Console.WriteLine("*SPLASH* You missed :(");
                    Console.WriteLine("press ENTER to take another shot...");
                    Console.ReadLine();
                    chooseXCoord();
                }
            }
            else if (enemyTilesX.Count == 2)
            {
                if (shotChoice == enemyTilesX.First() + "" + enemyTilesY.First())
                {
                    enemyTilesX.RemoveRange(0, 1);
                    enemyTilesY.RemoveRange(0, 1);
                    Console.WriteLine("*BANG* You hit an enemy pirate!");
                    Console.WriteLine("You gain a cannonball!");
                    cannonBalls++;
                    Console.WriteLine("+1 Doubloon!");
                    playerCurrency++;
                    playerPoints++;
                    Console.WriteLine("Press ENTER to take another shot...");
                    Console.ReadLine();
                    chooseXCoord();
                }
                else if (shotChoice == enemyTilesX.ElementAt(1) + "" + enemyTilesY.ElementAt(1))
                {
                    enemyTilesX.RemoveRange(1, 1);
                    enemyTilesY.RemoveRange(1, 1);
                    Console.WriteLine("*BANG* You hit an enemy pirate!");
                    Console.WriteLine("You gain a cannonball!");
                    cannonBalls++;
                    Console.WriteLine("+1 Doubloon!");
                    playerCurrency++;
                    playerPoints++;
                    Console.WriteLine("Press ENTER to take another shot...");
                    Console.ReadLine();
                    chooseXCoord();
                }
                else
                {
                    Console.WriteLine("*SPLASH* You missed :(");
                    Console.WriteLine("press ENTER to take another shot...");
                    Console.ReadLine();
                    chooseXCoord();
                }
            }
            else if (enemyTilesX.Count <= 1)
            {
                if (shotChoice == enemyTilesX.First() + "" + enemyTilesY.First())
                {
                    enemyTilesX.RemoveRange(0, 1);
                    enemyTilesY.RemoveRange(0, 1);
                    Console.WriteLine("*BANG* You hit an enemy pirate!");
                    Console.WriteLine("You gain a cannonball!");
                    cannonBalls++;
                    Console.WriteLine("+1 Doubloon!");
                    playerCurrency++;
                    playerPoints++;
                    Console.WriteLine("Press ENTER to take another shot...");
                    Console.ReadLine();
                    chooseXCoord();
                }
                else
                {
                    Console.WriteLine("*SPLASH* You missed :(");
                    Console.WriteLine("press ENTER to take another shot...");
                    Console.ReadLine();
                    chooseXCoord();
                }
            }



            
        }

        // Use points to buy things!
        static void itemShop ()
        {
            int shopChoice;
            Console.Clear();
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("Welcome to the floating item shop " + name + "!");
            if (playerCurrency > 1 || playerCurrency < 1)
            {
                Console.WriteLine("You have " + playerCurrency + " doubloons!");
            }
            else if (playerCurrency == 1)
            {
                Console.WriteLine("You have " + playerCurrency + " doubloon!");
            }
            Console.WriteLine("This is our current stock:");
            Console.WriteLine("[+] 2 Doubloons - Eagle");
            Console.WriteLine("[+] 3 Doubloons - Binoculars");
            Console.WriteLine("[+] 4 Doubloons - Artillery Strike");
            Console.WriteLine("[1] Buy Items [2] Learn about items [3] Return ");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
            Console.WriteLine("Make your choice:");
            shopChoice = Int32.Parse(Console.ReadLine());
            if(shopChoice == 1)
            {
                int itemChoice;
                Console.WriteLine("[+] Which item would you like to purchase? \n[1] Eagle - 2 Doubloons" +
                    " \n[2] Binoculars - 3 Doubloons \n[3]Artillery - 4 Doubloons \n: ");
                itemChoice = Int32.Parse(Console.ReadLine());
                if (itemChoice == 1)
                {
                    if(playerCurrency >= 2)
                    {
                        playerCurrency--;
                        Console.WriteLine("[*] Purchased Eagle");
                        Console.WriteLine("[+] Wait a turn for your eagle to return with some co-ordinates.");
                        purchasedEagle++;
                        mainGame();

                    }
                    else if(playerCurrency < 2)
                    {
                        Console.WriteLine("Sorry matey! You don't have enough doubloons!");
                        Console.WriteLine("Press ENTER to continue...");
                        Console.ReadLine();
                        itemShop();
                    }
                }
                else if (itemChoice == 2)
                {
                    if (playerCurrency >= 3)
                    {
                        Console.WriteLine("[*] Purchased binoculars!");
                        Console.WriteLine("[*] You will be able to see the co-ordinates of one pirate ship!");
                        purchasedBinoculars++;
                        mainGame();
                    }
                    else if (playerCurrency < 3) 
                    {
                        Console.WriteLine("Sorry matey! You don't have enough doubloons!");
                        Console.WriteLine("Press ENTER to continue...");
                        Console.ReadLine();
                        itemShop();
                    }
                }
                else if (itemChoice == 3)
                {
                    if (playerCurrency >= 4)
                    {
                        Console.WriteLine("[*] Purchased Artillery!");
                        purchasedArtillery++;
                        mainGame();
                    }
                    else if (playerCurrency < 4)
                    {
                        Console.WriteLine("Sorry matey! You don't have enough doubloons!");
                        Console.WriteLine("Press ENTER to continue...");
                        Console.ReadLine();
                        itemShop();
                    }
                }
            }
            else if (shopChoice == 2)
            {
                int learnChoice;
                Console.WriteLine("[+] So you want to know about my items! Which item would you like to learn about? \n [1] Eagle \n [2] Binoculars \n [3] Artillery Strike");
                learnChoice = Int32.Parse(Console.ReadLine());
                if (learnChoice == 1)
                {
                    Console.WriteLine("So you want to know about me' eagle!! arrrr!!!");
                    Console.WriteLine("This eagle right here will spot an enemies' X Co-ordinates all by itself and report back to you with 100% accuracy.");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadLine();
                }
                else if (learnChoice == 2)
                {
                    Console.WriteLine("So you want to know about me' binoculars!! arrrr!!!");
                    Console.WriteLine("These binoculars right here are the pinnacle of pirate technology! I've taken me' old monoculars and put em' together!! These puppies can spot an enemies X & Y Positions from anywhere!");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadLine();
                }
                else if (learnChoice == 3)
                {
                    Console.WriteLine("So you want to know about me' artillery strike!! arrrr!!!");
                    Console.WriteLine("I've taken a whole lot of cannons and arranged them in a circle pointing at the sky!! These puppies are bound to destroy a ship or two! It's also fitted with an eagle that will spot any enemies left after the ol' artillery strike! \n Neat technology hey? I have a feeling they will be using this for a long time!");
                    Console.WriteLine("Press ENTER to continue...");
                    Console.ReadLine();
                }
                else
                {

                }
            }
            else if (shopChoice == 3)
            {
                Console.WriteLine("return");
            }
        }

        static void gameOver(int state)
        {

            int choice;

            if (state == 1)
            {
                // Add other game over states later, things like running out of HP etc..
                Console.Clear();
                Console.WriteLine("Game over. You have run out of cannon balls.");
                Console.WriteLine("Would you like to play again? \n [1] Yes \n [2] No \n : ");
                choice = Int32.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    startGame();
                }
                else if (choice == 2)
                {
                    Environment.Exit(-1);
                }
                else
                {
                    Environment.Exit(-1);
                }
            }


            else if (state == 2)
            {
                // Add other game over states later, things like running out of HP etc..
                Console.Clear();
                Console.WriteLine("Game over. You have run out of health.");
                Console.WriteLine("Would you like to play again? \n [1] Yes \n [2] No \n : ");
                choice = Int32.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    startGame();
                }
                else if (choice == 2)
                {
                    Environment.Exit(-1);
                }
                else
                {
                    Environment.Exit(-1);
                }
            }

            else if (state == 3)
            {
                Console.Clear();
                Console.WriteLine("You win! You have eliminated all enemy pirate ships.");
                Console.WriteLine("Do you want to \n [1] Exit and save to scoreboard \n [2] Continue w/ a harder difficuty?");
                choice = Int32.Parse(Console.ReadLine());
                string fileSaveData = "scores.txt";
                if (choice == 1)
                {
                    if(debugMode == 1)
                    {
                        System.IO.File.AppendAllText(fileSaveData, System.Environment.NewLine + "-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=" + System.Environment.NewLine + "User: " + name + " Made it past Difficulty #" + difficulty + "\nThey made it out with a total of " + playerCurrency +
                            " doubloons! \nThey had DEBUG mode enabled!  \nThey eliminated a total of " + playerPoints + " ships!" + System.Environment.NewLine + "-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

                    }
                    else
                    {
                        System.IO.File.AppendAllText(fileSaveData, System.Environment.NewLine + "-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=" + System.Environment.NewLine + "User:" + name + " Made it past Difficulty #" + difficulty + "\nThey made it out with a total of " + playerCurrency + 
                            " doubloons! \nTHey had DEBUG mode disabled! \nThey eliminated a total of " + playerPoints + " ships!" + System.Environment.NewLine + "-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");

                    }

                    Console.Clear();
                    Console.WriteLine("~~~~~SCOREBOARD~~~~~ \n");
                    Console.WriteLine(System.IO.File.ReadAllText(fileSaveData));
                    Console.ReadLine();
                    // Implement scoreboard here retard 
                    Environment.Exit(-1);
                }
                else if (choice == 2)
                {
                    if (difficulty == 1)
                    {
                        Console.Clear();
                        difficulty = 2;
                        Console.WriteLine("[+] Congratulations on beating the EASY difficulty!");
                        Console.WriteLine("[+] You are now playing MEDIUM difficulty. Good luck!");
                        Console.WriteLine("[+] Press ENTER to continue...");
                        Console.ReadLine();
                        startGame();
                    }
                    else if (difficulty == 2)
                    {
                        Console.Clear();
                        difficulty = 3;
                        Console.WriteLine("[+] You are now playing HARD difficulty. I'm surprised you made it this far.");
                        Console.WriteLine("[+] Press ENTER to continue...");
                        Console.ReadLine();
                        startGame();
                    }
                    else if (difficulty == 3) 
                    {
                        Console.Clear();
                        Console.WriteLine("[+] I don't know how you got this far, but there are no further difficulty levels.");
                        Console.WriteLine("[+] The game will continue at the same difficulty level. Good luck.");
                        Console.WriteLine("[+] Press ENTER to continue...");
                        Console.ReadLine();
                        startGame();

                    }
                }

            }
        }
    }
}
