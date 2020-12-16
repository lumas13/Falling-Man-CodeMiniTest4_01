using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DPlatOb : MonoBehaviour
{
    private float countDownTimer = 0.1f;
    public GameObject dPlat;
    
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
                Destroy(dPlat);
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
