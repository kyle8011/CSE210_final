using System;
using System.Collections.Generic;


namespace Unit02.Game
{
    /// <summary>
    /// A person who directs the game. 
    ///
    /// The responsibility of a Director is to control the sequence of play.
    /// </summary>
    public class Director
    {
        List<Die> dice = new List<Die>();
        bool isPlaying = true;
        int score = 0;
        int totalScore = 0;
        //int in_play = 0;

        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {
            for (int i = 0; i < 5; i++)
            {
                Die die = new Die();
                dice.Add(die);
            }
        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            while (isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        /// <summary>
        /// Asks the user if they want to roll.
        /// </summary>
        public void GetInputs()
        {
            Console.Write("Roll dice? [y/n] ");
            string rollDice = Console.ReadLine();
            isPlaying = (rollDice == "y");
        }

        /// <summary>
        /// Updates the player's score.
        /// </summary>
        public void DoUpdates()
        {
            if (!isPlaying)
            {
                return;
            }
            
            score = 0;
            foreach (Die die in dice)
            {
                if (die.in_play == true) {
                die.Roll();
                score += die.points;
                }
            }
            
            totalScore += score;
        }

        /// <summary>
        /// Displays the dice and the score. Also asks the player if they want to roll again. 
        /// </summary>
        public void DoOutputs()
        {
            if (!isPlaying)
            {
                return;
            }

            string kept = "";
            string re_roll = "";
            int used = 0;
            foreach (Die die in dice)
            {
                if (die.in_play == false) {kept += $"{die.value} "; used += 1;}   
                if (die.in_play == true) {re_roll += $"{die.value} ";}
            }

            Console.WriteLine($"Dice kept: {kept}");
            Console.WriteLine($"Re-rolls: {re_roll}");
            Console.WriteLine($"Your score is: {totalScore}\n");
            if (score == 0) {isPlaying = false; Console.WriteLine("Farkle!");}
            if (used == 5) {Console.WriteLine("Re-Roll all dice!");}
        }
    }
}