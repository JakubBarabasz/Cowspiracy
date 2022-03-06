using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class knifeAmountUI : MonoBehaviour
{

    public Text text;

    public GameObject blueGoalObj;
    public GameObject redGoalObj;

    public string blueGoal;
    public string redGoal;

    public string scoreText;

    public int redScore = 0;
    public int blueScore = 0;


    public void Start()
    {
        text = GetComponent<Text>();
    }

    //Brings OnCollision information from another script to alter score
    public void RaiseScore(string Goal)
    {
        if (Goal == blueGoalObj.name)
        {
            blueScore += 1;
            SetScore();
        }

        else if (Goal == redGoalObj.name)
        {
            redScore += 1;
            SetScore();
        }
    }

    //take the score from RaiseScore() and set it as a String value.  Then use that string to replace the current score on the text feild inside a canvas
    void SetScore()
    {
        string redScoreString = redScore.ToString();
        string blueScoreString = blueScore.ToString();
        string scoreText = redScoreString + " / " + blueScoreString;
        // Debug successfully updates the score on the Console.
        Debug.Log(scoreText);
        //NullReferenceException: Object reference not set to an instance of an object Solution
        text.text = scoreText;
    }
}