using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_credits : MonoBehaviour
{
    private GameObject rullaa;

    // Start is called before the first frame update
    void Start()
    {
        rullaa = GameObject.Find("rullaa");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if (UNITY_EDITOR)
            UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE)
            Application.Quit();
#elif (UNITY_WEBGL)
            Application.OpenURL("about:blank");
#endif
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            rullaa.transform.Translate(0f, 3f, 0f);
        }
        else
        {
            rullaa.transform.Translate(0f, 1f, 0f);
        }
    }
}
