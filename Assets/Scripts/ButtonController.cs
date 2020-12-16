using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("InstructionScene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("CreditScene");
    }    

    public void Back()
    {
        SceneManager.LoadScene("MainScene");
    }
}

