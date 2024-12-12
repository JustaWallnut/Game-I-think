using System.Numerics;

namespace game
{
    internal class Program
    {
        Player goodGuy = new Player(10, 1, 2, 3,0);
        class Unit
        {
            public int max_health;
            public int health;
            public int damage;
            public int innateDefense;
            public int defense = 0;
        }
        static void Main(string[] args)
        {

            bool GameOn = true;
            int BattleOrder = 1;
            int ArrowPos = 1;
            string GameState = "MainMenu";
            bool LightMode = false;
            while (GameOn)
            {
                Unit player = new Unit();
                player.max_health = 10;
                player.health = player.max_health;
                player.damage = 5;
                player.innateDefense = 2;
                Unit zombie = new Unit();
                zombie.max_health = 10;
                zombie.health = zombie.max_health;
                zombie.damage = 2;
                zombie.innateDefense = 2;
                void MenuButton(int value, string text)
                {
                    if (ArrowPos == value)
                    {
                        Console.Write("> ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    Console.WriteLine(text);
                }
                void ButtonTraversal(string input, int min, int max)
                {
                    if (input == "DownArrow")
                    {
                        ArrowPos += 1;
                    }
                    if (input == "UpArrow")
                    {
                        ArrowPos -= 1;
                    }
                    if (ArrowPos <= min - 1)
                    {
                        ArrowPos = max;
                    }
                    else if (ArrowPos > max)
                    {
                        ArrowPos = min;
                    }
                }
                void DisplayHealth(int health, int maxhealth, string name)
                {
                    Console.WriteLine(name);
                    Console.WriteLine(health + " / " + maxhealth);
                }
                if (GameState == "Battle")
                {
                    while (zombie.health > 0 && player.health > 0)
                    {
                        if (BattleOrder == 1)
                        {
                            DisplayHealth(zombie.health, zombie.max_health, "Zombie, Undead");
                            Console.WriteLine(" ");
                            DisplayHealth(player.health, zombie.max_health, "Player, Main Character");
                            Console.WriteLine(" ");
                            MenuButton(1, "Attack");
                            MenuButton(2, "Defend");
                            MenuButton(3, "Inventory");
                            MenuButton(4, "Give Up");
                            ConsoleKeyInfo input = Console.ReadKey();
                            string inputString = input.Key.ToString();
                            ButtonTraversal(inputString, 1, 4);
                            Console.Clear();
                            if (inputString != "Enter")
                            {
                                continue;
                            }
                        }
                        if (BattleOrder == 1)
                        {
                            player.defense = 0;
                            if (ArrowPos == 1)
                            {
                                Console.WriteLine("You swing your sword at the enemy");
                                Random randum = new Random();
                                int hit = randum.Next(0, 2);
                                if (hit == 1)
                                {
                                    int attack = (player.damage - zombie.defense);
                                    if (attack > 0)
                                    {
                                        Console.WriteLine(attack + " damage!");
                                        zombie.health = zombie.health - attack;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Defense too high! Damage nullified");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Miss!");
                                }
                            }
                            else if (ArrowPos == 2)
                            {
                                Console.WriteLine("You brace yourself.");
                                player.defense = player.innateDefense;
                            }
                            else if (ArrowPos == 3)
                            {
                                Console.WriteLine("You check your inventory, but you literally don't have anything!");
                            }
                            else if (ArrowPos == 4)
                            {
                                Console.WriteLine("Seriously?");
                                Environment.Exit(0);
                            }
                            BattleOrder = 0;
                        }
                        else
                        {
                            zombie.defense = 0;
                            Random randum = new Random();
                            int choice = randum.Next(0, 3);
                            if (choice == 0)
                            {
                                Console.WriteLine("The zombie stares at you blankly");
                            }
                            if (choice == 1)
                            {
                                Console.WriteLine("The zombie swings at you widly");
                                int hit = randum.Next(0, 2);
                                if (hit == 1)
                                {
                                    int attack = (zombie.damage - player.defense);
                                    if (attack > 0)
                                    {
                                        Console.WriteLine(attack + " damage!");
                                        player.health -= attack;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Defense too high! Damage nullified");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Miss!");
                                }
                            }
                            if (choice == 2)
                            {
                                Console.WriteLine("The zombie braces itself");
                                zombie.defense = zombie.innateDefense;
                            }    
                            BattleOrder = 1;
                        }
                        Console.WriteLine(" ");
                    }
                    if (zombie.health <= 0)
                    {
                        Console.WriteLine("Winner!");
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("HAH Loser!");
                        Environment.Exit(0);
                    }
                }
                if (GameState == "MainMenu")
                {
                    Console.WriteLine("------------------");
                    Console.WriteLine("GAME");
                    Console.WriteLine("------------------");
                    MenuButton(1, "New Game");
                    MenuButton(2, "Options");
                    MenuButton(3, "Quit");
                    ConsoleKeyInfo input = Console.ReadKey();
                    string inputString = input.Key.ToString();
                    ButtonTraversal(inputString, 1, 3);
                    if (inputString == "Enter")
                        if (ArrowPos == 1)
                        {
                            ArrowPos = 1;
                            GameState = "Battle";
                        }
                        else if (ArrowPos == 2)
                        {
                            GameState = "Options";
                            ArrowPos = 1;
                        }
                        else if (ArrowPos == 3)
                        {
                            Environment.Exit(0);
                        }
                    Console.Clear();
                }
                if (GameState == "Options")
                {
                    Console.WriteLine("------------------");
                    Console.WriteLine("OPTIONS");
                    Console.WriteLine("------------------");
                    MenuButton(1, "Toggle Light Mode");
                    MenuButton(2, "Back to Main Menu");
                    ConsoleKeyInfo input = Console.ReadKey();
                    string inputString = input.Key.ToString();
                    ButtonTraversal(inputString, 1, 3);
                    if (inputString == "Enter")
                    {
                        if (ArrowPos == 1)
                        {
                            if (!LightMode)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Black;
                                LightMode = true;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.White;
                                LightMode = false;
                            }
                        }
                        if(ArrowPos == 2)
                        {
                            ArrowPos = 1;
                            GameState = "MainMenu";
                        }
                    }
                    Console.Clear();
                }
            }
        }
    }
 }
