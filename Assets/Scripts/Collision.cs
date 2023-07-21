using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    public float gamespeed = 0.5f;

    private void Start()
    {
        Time.timeScale = gamespeed;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            gamespeed = 0f;
        }
        {
            if (other.gameObject.tag == "ScoreText")
            {
                gamespeed = gamespeed + 0.1f;
            }
            if (other.gameObject.tag == "Scoremin")
            {
                gamespeed = gamespeed - 0.1f;
            }
            Time.timeScale = gamespeed;
            Time.fixedDeltaTime = Time.timeScale * .02f;
        }
    }
}
