using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinningScript : MonoBehaviour

{
    public PlayerScript playerScript;

    public int topScore = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.GetScore() >= topScore)
        {
            SceneManager.LoadScene("Winning");
        }
    }
}
