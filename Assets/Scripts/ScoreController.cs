using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;

public class ScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI scoretext;
    private int score = 0;
    private void Awake()
    {
        scoretext = GetComponent<TextMeshProUGUI>();

    }
    public void IncreaseScore(int Increment)
    {
        score += Increment;
        RefreshUI();
    }
    private void RefreshUI()
    {
        scoretext.text = "Score: " + score;
        
    }
    private void Start()
    {
        RefreshUI();
    }





}
