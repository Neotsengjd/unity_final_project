using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class safeHouseController : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource safeDoorAudio;

    public Text endGameText;
    public restartGame theGameController;

    bool insafe = false;

    void Start()
    {
        safeDoorAudio = GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && insafe == false)
        {
            safeDoorAudio.Play();
            Animator endGameAnim = endGameText.GetComponent<Animator>();
            endGameText.text = "Safe House";
            endGameAnim.SetTrigger("endGame");
            theGameController.restartTheGame();
            insafe = true;
        }
    }
}
