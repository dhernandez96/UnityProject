using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class SceneSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
        {
        	SceneManager.LoadScene(sceneName:"Scene 1");
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene(sceneName: "Scene 2");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene(sceneName: "Credits");
        }
    }
}
