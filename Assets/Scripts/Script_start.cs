using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script_start : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.anyKeyDown)
        {
            GameObject.Find("Image").SetActive(false);
            SceneManager.LoadScene("Scene_main");
        }
    }
}
