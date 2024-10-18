using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boost : MonoBehaviour
{
    public void IsPressed()
    {
        PlayerStats.instance.BoostButtonPressed();
    }
}
