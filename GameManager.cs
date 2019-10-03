using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public  Question[] questions;
    private Question currentQuestion;
    private static List<Question> unansweredQuestions;
    [SerializeField]
    private Text questText;
    [SerializeField]
    private Text atext;
    [SerializeField]
    private Text btext;
   
    private int score;
    [SerializeField]
    private Text scoreText;
   


    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;

        if(unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }
        GetQuestion();
        Debug.Log(currentQuestion.question + "with answer: "+currentQuestion.answer);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            UserSelectA();
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            UserSelectB();
        }
    }


    void GetQuestion()
    {
        if (unansweredQuestions.Count > 0)
        {
            int randQuestIndex = Random.RandomRange(0, unansweredQuestions.Count);
            Debug.Log(randQuestIndex);
            Debug.Log(unansweredQuestions.Count);
            currentQuestion = questions[randQuestIndex];
            questText.text = currentQuestion.question;
            atext.text = currentQuestion.optiona;
            btext.text = currentQuestion.optionb;
            unansweredQuestions.RemoveAt(randQuestIndex);
        }
        else 
        {
            Debug.Log("Quiz Ended");
        }
       
    } 

    

    public void UserSelectA()
    {
        if(currentQuestion.answer == 'a')
        {
            Debug.Log("Correct!");
            score += 10;
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.Log("Incorrect!");
        }
        GetQuestion();


    }
    public void UserSelectB()
    {
        if (currentQuestion.answer == 'b')
        {
            Debug.Log("Correct!");
            score += 10;
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.Log("Incorrect!");
        }
        GetQuestion();


    }





}
