using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Script_controller : MonoBehaviour
{
    public GameObject puhekupla;
    public float timer;

    private GameObject FPS_laskuri;
    private GameObject minimap;
    private GameObject player;
    private GameObject kartta_help;
    private Text timerText;

    // Äänet
    private AudioSource minimapSound;

    // Start is called before the first frame update
    void Start()
    {
        FPS_laskuri = GameObject.Find("FPS-laskuri_panel");
        FPS_laskuri.SetActive(false);
        minimap = GameObject.Find("Minimap");
        minimap.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        timerText = GameObject.Find("Timer").GetComponent<Text>();
        minimapSound = this.GetComponents<AudioSource>()[1];
        kartta_help = GameObject.Find("kartta_help");
    }

    // Update is called once per frame
    void Update()
    {
        // Ajastin
        timer -= Time.deltaTime;
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");
        timerText.text = string.Format("Aikaa jäljellä: {0}:{1}",minutes,seconds);

        if (Input.GetKeyDown(KeyCode.X))
        {
            puhekupla.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            minimapSound.Play();
            kartta_help.SetActive(false);
            minimap.SetActive(!minimap.activeSelf);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            FPS_laskuri.SetActive(!FPS_laskuri.activeSelf);
        }
    }

    private void FixedUpdate()
    {
        if(timer <= 0)
        {
            SceneManager.LoadScene("Scene_youLose");
        }

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
        else if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("Scene_main");
        }
#if (UNITY_EDITOR)
        else if (Input.GetKey(KeyCode.P))
        {
            UnityEditor.EditorApplication.isPaused = true;
        }
#endif

        minimap.transform.position = new Vector3(player.transform.position.x,200f,player.transform.position.z);
        Quaternion q = Quaternion.Euler(90f,player.transform.rotation.eulerAngles.y,player.transform.rotation.eulerAngles.z);
        minimap.transform.rotation = q;
    }
}
