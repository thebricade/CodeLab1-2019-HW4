using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class ManageDebt : MonoBehaviour
{
    //set score to display on Canvas
    //setup: make Canvas a child of game manager in order to carry it to the next scene
    public Text scoretxt;
    public Text debtTotaltxt;
    const string File_DEBTAMOUNT = "/MyDebtFile.txt";
    private int score = 0; 
    public int Score
    {
        get {return score; }
        set 
        {   
           
            score = value; 
            debtTotaltxt.text = "Debt: " + score;
            string fullPathToFile = Application.dataPath + File_DEBTAMOUNT;
            File.WriteAllText(fullPathToFile, "HighScore: " + score); //(string path, string contents)
            //HighScore = score;
        }
    }
    private int highScore = 5;
    /*
    public int HighScore
    {
        get{return highScore;}
        set
        {
            if(value > highScore)
            {   
                highScore = value;
                debtTotaltxt.text = "Debt: " + highScore;
                //ONE WAY: PlayerPref can store data in between play sessions
                //PlayerPrefs.SetInt(PLAYER_PREFS_HIGHSCORE, highScore); //PlayerPref.SetInt(string key, int data)
                    
                //OR THE OTHER WAY: Save player prefs file to disk
                string fullPathToFile = Application.dataPath + File_DEBTAMOUNT;
                File.WriteAllText(fullPathToFile, "HighScore: " + highScore); //(string path, string contents)
            }
        }
    }
    */

    public static ManageDebt Instance = null; //Set the starting instance to null
    private void Awake()
    {
        //destroy the gameManager object if there's more than one instance
        if (Instance == null)
        {
            Instance = this; // set the instance to this script
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        string highScoreFileText = File.ReadAllText(Application.dataPath + File_DEBTAMOUNT);
        //split the string into 2 parts by the Space
        string[] scoreSplit = highScoreFileText.Split(' ');
        //convert string number to int number
       // HighScore = Int32.Parse(scoreSplit[1]);
    }

}
