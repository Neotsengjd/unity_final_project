using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class twoToWin : MonoBehaviour
{
    // Start is called before the first frame update
    private bool insafe = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && insafe == false)
        {
            SceneManager.LoadScene(4);
            insafe = true;
        }
    }
}
