using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GustBehavior : MonoBehaviour
{
    private float gustXValue;
    public float gustSpeed;

    // Start is called before the first frame update
    void Start()
    {
        gustXValue = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //add speed to the X axis position
        gustXValue += gustSpeed;

        //set new X value to position
        gameObject.transform.position = new Vector2(gustXValue, gameObject.transform.position.y);
    }
}
