using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static PlayerStats playerStats;

    public void Play()
    {
        SceneManager.LoadScene("Survive.io");
    }
}
