using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject fallingBall;

    float levelTimer = 2f;

    Vector3 position = new Vector3(0, 15, 175);

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (levelTimer > 0)
        {
            levelTimer -= Time.deltaTime;
            Debug.Log((int)levelTimer);
        }
        else
        { 
            levelTimer = 0;
            levelTimer += 2;
            Instantiate(fallingBall, position, Quaternion.identity);
        }
    }
}
