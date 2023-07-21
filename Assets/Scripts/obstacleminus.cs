using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleminus : MonoBehaviour
{
    private Score ScoreText;
    private void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Score>();
    }

    private void Update()
    {
        gameObject.transform.Rotate(0, 0, 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ScoreText.Scoreminusone();
            Destroy(gameObject);
        }
    }
}
