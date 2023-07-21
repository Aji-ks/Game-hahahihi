using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int ScoreInt;
    public Text ScoreText;

    public void ScorePlusOne()
    {
        ScoreInt++;
    }

    public void Scoreminusone()
    {
        ScoreInt--;
    }

    private void Update()
    {
        ScoreText.text = ScoreInt.ToString();
    }
}
