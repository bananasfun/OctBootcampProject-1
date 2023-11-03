using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Pin[] pins;

    private int totalScore;
    public int currentThrow { get; private set; } 

    public int currentFrame { get; private set; } 


    private int[] frames = new int[10]; // set the length of the array (array goes from 0-9 if array is set at 10, e.g.
    private bool isSpare = false;
    private bool isStrike = false;

    private void Start()
    {
        ResetScore();
    }

    //Set value for our frame score each time we throw the ball
    public void SetFrameScore(int score)
    {
        // Ball 1
        if(currentThrow == 1)
        {
            frames[currentFrame - 1] += score; // Setting the right frame index and adding the score value from the parameter passed
            //Parallel process ro check spare
            if(isSpare)
            {
                frames[currentFrame - 2] += score;
                isSpare = false;
            }
            // -----------------------------------

            if(score == 10)
            {
                if(currentFrame == 10)
                {
                    currentThrow++; // Wait for BALL 2 // CurrentThrow: number of times you are throwing within a frame
                }
                else
                {
                    isStrike = true;
                    currentFrame++;
                    //Move to next frame since full marks obtained (strike)
                    //Currentframe: each frame that you are scoring a user for
                }

                //TODO: GameManager to Reset Pins
                gameManager.ResetAllPins();

            }

            else
            {
                currentThrow++; //previous code was just to check for a strike, and we should continue with the game. Wait for BALL 2
            }

            return;
        }

        // BALL 2
        if(currentThrow == 2)
        {
            frames[currentFrame] += score;
            //Parallel process to check strike

            if (isStrike)
            {
                frames[currentFrame - 2] += frames[currentFrame - 1 ];
                isStrike = false;
            }

            // ----------------------------------

            if (frames[currentFrame - 1] == 10) //Is total frame score 10? 

            {
                if(currentFrame ==10)
                {
                    currentThrow++; // Wait for BALL 3
                }
                else
                {
                    isSpare = true;
                    currentFrame++;
                    currentThrow = 1;
                }
            }
            else
            {
                if (currentFrame == 10) 
                {
                    // End of all throws
                    currentThrow = 0;
                    currentFrame = 0;
                }
                else
                {
                    currentFrame++;
                    currentThrow = 1; 
                }
            }

            //TODO: GameManager to Reset All Pins
            gameManager.ResetAllPins();


            return;
        }

        //BALL 3 ONLY FRAME 10
        if(currentThrow == 3 && currentFrame == 10)
        {
            frames[currentFrame - 1] += score;

            //End of all throws
            currentThrow = 0;
            currentFrame = 0;

            return;
        }

    }

    public int CalculateTotalScore()
    {
        totalScore = 0;
        foreach (var item in frames)
        {

           totalScore += item; //compounds score
        }

        return totalScore;
    }

    private void ResetScore()
    {
        totalScore = 0;
        currentThrow = 1;
        currentFrame = 1;
        frames = new int[10]; 
    }
}
