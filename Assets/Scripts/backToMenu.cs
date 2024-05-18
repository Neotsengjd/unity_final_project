using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void restartGame()
    {
        SceneManager.LoadScene(0);
    }
}

