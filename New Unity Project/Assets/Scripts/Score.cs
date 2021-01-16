using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Score : MonoBehaviour
{
    private float score = 0.0f;

    private int difficulty_level = 1;
    private int max_difficulty_level = 10;
    private int score_to_next_level = 10;

    public Text score_text;
    public DeathMenu deathMenu;

    private bool isDead = false;

    void Start()
    {
        score_text.text = "Score: 00";
    }


    void Update()
    {
        if (isDead)
        {
            return;
        }

        if (score >= score_to_next_level)
        {
            LevelUp();
        }
        score += Time.deltaTime*difficulty_level;
        score_text.text = "Score: "+((int)score).ToString();
    }

    void LevelUp()
    {
        if (difficulty_level == max_difficulty_level)
        {
            return;
        }

        
        score_to_next_level *= 2;
        difficulty_level++;

        GetComponent<PlayerMotor>().SetSpeed(difficulty_level);
    }

    public void OnDeath()
    {
        isDead = true;
        deathMenu.ToggleEndMenu(score);
    }
}

