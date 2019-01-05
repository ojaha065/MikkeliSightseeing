using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Script_triggerKohde : MonoBehaviour
{
    public GameObject puhekupla;
    public GameObject tehoste;
    public Material twilight;
    public int kohdeID = -1;

    private Transform marker;
    private Text teksti;
    private Script_controller controller;
    private AudioSource[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        marker = this.transform.GetChild(1);
        teksti = puhekupla.transform.GetChild(0).GetComponent<Text>();
        controller = GameObject.Find("Controller").GetComponent<Script_controller>();
        sounds = GameObject.FindGameObjectWithTag("Player").GetComponents<AudioSource>();
        if(kohdeID != 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        marker.Rotate(1f,1f,1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            //Debug.Log("Pelaaja törmäsi triggeriin");
            GameObject apu = Instantiate(tehoste,this.transform.position,Quaternion.Euler(-90f,0f,0f));
            Destroy(apu, 2f);

            switch (kohdeID)
            {
                case 0:
                    //Debug.Log("Tämä on kohde 0");
                    sounds[1].Play();
                    teksti.text = "Mikkelin matkakeskus ja linja-autoasema. Bussini seuraavaan kohteeseen lähtee täältä, mutta minulla on vielä hetki aikaa. Odotellessani voisinkin käydä vaikka torilla.";
                    controller.timer += 50;
                    break;
                case 1:
                    //Debug.Log("Tämä on kohde 1");
                    sounds[1].Play();
                    teksti.text = "Mikkelin tori. Täällä riittää menoa ja tapahtumia ympäri vuoden. Tänään on kuitenkin hiljaista. Kuuluisa Eepin Grillikin muutti toisaalle. Taidampa silti napata vähän hiukopalaa Suomi Grilliltä.";
                    controller.timer += 60;
                    break;
                case 2:
                    //Debug.Log("Tämä on kohde 2");
                    Destroy(apu);
                    sounds[2].Play();
                    teksti.text = "Aah, nyt jaksaa taas. Kaupungintalo onkin ihan tuossa lähellä, käympä katsomassa sitä.";
                    break;
                case 3:
                    //Debug.Log("Tämä on kohde 3");
                    sounds[1].Play();
                    teksti.text = "Mikkelin kaupungintalo. Se on kuulemma rakennettu jo vuonna 1912. Viimeisenä kohteena voisin käydä tuomiokirkossa.";
                    controller.timer += 100;
                    break;
                case 4:
                    //Debug.Log("Tämä on kohde 4");
                    sounds[1].Play();
                    Camera.main.GetComponent<Skybox>().material = twilight;
                    GameObject.Find("Directional Light").GetComponent<Light>().intensity = 0.15f;
                    teksti.text = "On se näyttävä. Nyt pitääkin ottaa selfie...\n\nKylläpä aika rientää. Nyt tuli kiire! Äkkiä takaisin linja-autoasemalle!";
                    controller.timer = 95;
                    sounds[3].Play();
                    break;
                case 5:
                    //Debug.Log("Tämä on maali");
                    teksti.text = "Huh!";
                    SceneManager.LoadScene("Scene_youWin");
                    break;
                default:
                    //Debug.LogWarning("Pelaaja törmäsi kohteeseen jolla ei ole käsittelijää");
                    break;
            }

            puhekupla.SetActive(true);
            int next = (kohdeID <= 4) ? 1 : 0;
            this.transform.parent.transform.GetChild(this.kohdeID + next).gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
