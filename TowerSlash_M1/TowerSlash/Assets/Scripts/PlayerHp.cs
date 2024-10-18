using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public static PlayerHP instance;
    private int playerHp = 0;
    public bool isCharacterSpeed = false;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public int GetHP()
    {
        return playerHp;
    }
    public void SetHP(int setThisHP)
    {
        playerHp = setThisHP;
    }
    public bool GetIsCharacterSpeed()
    {
        return isCharacterSpeed;
    }
    public void SetIsCharacterSpeed(bool setThisSpeed)
    {
        isCharacterSpeed = setThisSpeed;
    }
}