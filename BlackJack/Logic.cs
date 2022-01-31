using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Logic
    {

        //Win-Lose System
        string quitKey = "";
        int userPoint = 20;
        int aiPoint = 20;

        //Bankcruptcy check
        bool userBankcrupted = false;
        bool aiBankcrupted = false;

        //Our random class
        Random random = new Random();

        //Sum of card that player hold in that moment
        public int userCurrent = 0;
        public int aiCurrent = 0;

        //Rnd possibility
        public int possibility;

        //Do we want to pick a card ?
        public string desicion = "y";

        //Ai difficulty
        string difficulty = "";
        public Logic()
        {
            Start(); //I created that ctor only for not type more code in Program.cs
        }

        public void Start() //Program.cs ye fırlatılacak metot
        {
            //Difficulty selection
            Console.Write("Choose your diffiulty of ai (easy,medium,hard (default:medium)): ");
            difficulty = Console.ReadLine();
            
            UPlay();

        }

        public void UPlay()
        {
            while (userPoint > 0 && aiPoint > 0 && quitKey != "q")
            {
                Console.WriteLine("You : {0}, Ai : {1}", userPoint, aiPoint);
                aiCurrent = 0;
                userCurrent = 0;
                desicion = "y";
                aiBankcrupted = false;
                userBankcrupted = false;


                //Pick loop (we are getting in this loop)
                while (desicion == "y" && userCurrent < 21)
                {
                    Console.Write("y or n : ");
                    desicion = Console.ReadLine();
                    if (desicion == "y")
                    {
                        userCurrent += random.Next(1, 10);
                    }
                    Console.WriteLine("Your current number is {0}", userCurrent);
                }
                if (userCurrent > 21)
                {
                    Console.WriteLine("You reached the valid number");
                    userBankcrupted = true;
                }
                else
                {
                    Console.WriteLine("You're stopped picking, Ai is playing...");
                }

                //Ai starts playing... (whenever we stop picking, the ai start playing...) TODO: It's a sync, turn it to async????
                switch (difficulty)
                {
                    case "easy":
                        Play(Difficulty.easy);
                        break;
                    case "medium":
                        Play(Difficulty.medium);
                        break;
                    case "hard":
                        Play(Difficulty.hard);
                        break;
                    default:
                        Play(Difficulty.medium);
                        break;
                }


                if (userBankcrupted != true && aiBankcrupted == true || userBankcrupted != true && userCurrent > aiCurrent) //User got the point
                {
                    Console.WriteLine("You won this turn!");
                    userPoint += 2;
                    aiPoint -= 2;
                    if (userPoint == 0 || aiPoint == 0)
                    {
                        //TODO: if one of the each point lower than 0  DO SOMTHNG (throw a method that restart the whole game or env.exit)
                    }
                }
                else if (aiBankcrupted != true && userBankcrupted == true || aiBankcrupted != true && aiCurrent > userCurrent) //Ai got the point
                {
                    Console.WriteLine("Ai won this turn");
                    userPoint -= 2;
                    aiPoint += 2;
                    if (userPoint == 0 || aiPoint == 0)
                    {
                        //TODO: if one of the each point lower than 0 DO SMTHNG
                    }
                }
                else if (userBankcrupted == true && aiBankcrupted == true)
                {
                    Console.WriteLine("You both bankcrupted!");
                }
                else
                {
                    Console.WriteLine("Draw!");
                }

                Console.WriteLine("Press any key to continiou or type 'q' for quit");
                quitKey = Console.ReadLine();
            }
        }

        //Ai logic method
        public void Play(Difficulty difficulty)
        {
            if (difficulty == Difficulty.easy)
            {
                

                possibility = random.Next(0, 100); //Possibility between 0% and 100%


                #region RNG session
                //We don't have to point it in if statement but it makes the code more readable in order to train ourselves about the possblty field...

                if (possibility < 100 && aiCurrent < 21) //first draw 1
                {
                    aiCurrent += random.Next(1, 10);
                }

                //It takes a new number
                possibility = random.Next(0, 100);

                if (possibility < 95 && aiCurrent < 21) //2
                {
                    aiCurrent += random.Next(1, 10);
                }

                possibility = random.Next(0, 100);

                if (possibility < 85 && aiCurrent < 21) //3
                {
                    aiCurrent += random.Next(1, 10);
                }

                possibility = random.Next(0, 100);

                if (possibility < 75 && aiCurrent < 21) //4
                {
                    aiCurrent += random.Next(1, 10);
                }

                possibility = random.Next(0, 100);

                if (possibility < 65 && aiCurrent < 21) //5 
                {
                    aiCurrent += random.Next(1, 10);
                }

                possibility = random.Next(0, 100);

                if (possibility < 55 && aiCurrent < 21) //6
                {
                    aiCurrent += random.Next(1, 10);
                }

                possibility = random.Next(0, 100);

                if (possibility < 45 && aiCurrent < 21) //7
                {
                    aiCurrent += random.Next(1, 10);
                }
                #endregion

                if (aiCurrent <= 21)
                {
                    Console.WriteLine("Ai's number is {0}", aiCurrent);
                }
                else
                {
                    Console.WriteLine("Ai bankrupted, ({0})", aiCurrent);
                }
                

            }
            if (difficulty == Difficulty.medium)
            {
                possibility = random.Next(0, 100); //Possibility between 0% and 100%


                #region RNG session
                //We don't have to point it in if statement but it makes the code more readable in order to train ourselves about the possblty field...

                if (possibility < 100 && aiCurrent < 21) //first draw 1
                {
                    aiCurrent += random.Next(1, 10);
                }

                //It takes a new number
                possibility = random.Next(0, 100);

                if (possibility < 90 && aiCurrent < 21) //2
                {
                    aiCurrent += random.Next(1, 10);
                }

                possibility = random.Next(0, 100);

                if (possibility < 80 && aiCurrent < 21) //3
                {
                    aiCurrent += random.Next(1, 10);
                }

                possibility = random.Next(0, 100);

                if (possibility < 70 && aiCurrent < 21) //4
                {
                    aiCurrent += random.Next(1, 10);
                }

                possibility = random.Next(0, 100);

                if (possibility < 60 && aiCurrent < 21) //5 
                {
                    aiCurrent += random.Next(1, 10);
                }

                possibility = random.Next(0, 100);

                if (possibility < 50 && aiCurrent < 21) //6
                {
                    aiCurrent += random.Next(1, 10);
                }

                possibility = random.Next(0, 100);

                if (possibility < 40 && aiCurrent < 21) //7
                {
                    aiCurrent += random.Next(1, 10);
                }
                #endregion

                if (aiCurrent <= 21)
                {
                    Console.WriteLine("Ai's number is {0}", aiCurrent);
                }
                else
                {
                    Console.WriteLine("Ai bankrupted, ({0})", aiCurrent);
                }

            }
            if (difficulty == Difficulty.hard)
            {
                possibility = random.Next(0, 100); //Possibility between 0% and 100%


                #region RNG session
                //We don't have to point it in if statement but it makes the code more readable.

                if (possibility < 100 && aiCurrent < 21) //first draw 1
                {
                    aiCurrent += random.Next(1, 10);
                }

                //It takes a new number
                possibility = random.Next(0, 100);

                if (possibility < 88 && aiCurrent < 21) //2
                {
                    aiCurrent += random.Next(1, 10);
                }

                possibility = random.Next(0, 100);

                if (possibility < 68 && aiCurrent < 21) //3
                {
                    aiCurrent += random.Next(1, 10);
                }

                possibility = random.Next(0, 100);

                if (possibility < 58 && aiCurrent < 21) //4
                {
                    aiCurrent += random.Next(1, 10);
                }

                possibility = random.Next(0, 100);

                if (possibility < 51 && aiCurrent < 21) //5 
                {
                    aiCurrent += random.Next(1, 10);
                }

                possibility = random.Next(0, 100);

                if (possibility < 44 && aiCurrent < 21) //6
                {
                    aiCurrent += random.Next(1, 10);
                }

                possibility = random.Next(0, 100);

                if (possibility < 32 && aiCurrent < 21) //7
                {
                    aiCurrent += random.Next(1, 10);
                }
                #endregion

                if (aiCurrent <= 21)
                {
                    Console.WriteLine("Ai's number is {0}", aiCurrent);
                }
                else
                {
                    Console.WriteLine("Ai bankrupted, ({0})", aiCurrent);
                    aiBankcrupted = true;
                }

            }
        }
        
    }
    public enum Difficulty : byte
    {
        easy, medium, hard
    }
}
