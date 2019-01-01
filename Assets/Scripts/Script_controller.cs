using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_controller : MonoBehaviour
{
    private GameObject FPS_laskuri;

    // Start is called before the first frame update
    void Start()
    {
        FPS_laskuri = GameObject.Find("FPS-laskuri");
        FPS_laskuri.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FPS_laskuri.SetActive(!FPS_laskuri.activeSelf);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
#if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE)
    Application.Quit();
#elif (UNITY_WEBGL)
        Application.OpenURL("about:blank");
#endif
        }
#if (UNITY_EDITOR)
        else if (Input.GetKey(KeyCode.P))
        {
            UnityEditor.EditorApplication.isPaused = true;
        }
#endif
    }
}
