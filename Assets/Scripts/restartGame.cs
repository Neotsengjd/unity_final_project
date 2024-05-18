using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restartGame : MonoBehaviour
{
    // Start is called before the first frame update

    public float restartTime;
    bool resetNow = false;
    float resetTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (resetNow && resetTime <= Time.time)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void restartTheGame()
    {
        resetNow = true;
        resetTime = restartTime + Time.time;
    }
}
