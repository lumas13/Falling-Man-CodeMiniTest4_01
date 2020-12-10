using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPlatController : MonoBehaviour
{
    private float countDownTimer = 5f;
    public GameObject dPLAT;
    

    bool timerIsRunning;
    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning == true)
        {
            countDownTimer -= Time.deltaTime;
            Debug.Log((int)countDownTimer);
            if (countDownTimer <= 0)
            {
                Destroy(dPLAT);
            }

        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            timerIsRunning = true;
        }
    }
}
