using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Script_triggerKohde : MonoBehaviour
{
    public GameObject puhekupla;
    public int kohdeID = -1;

    private Text teksti;
    private Script_controller controller;

    // Start is called before the first frame update
    void Start()
    {
        teksti = puhekupla.transform.GetChild(0).GetComponent<Text>();
        controller = GameObject.Find("Controller").GetComponent<Script_controller>();
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
        this.transform.Rotate(0f,1f,0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Debug.Log("Pelaaja törmäsi triggeriin");

            switch (kohdeID)
            {
                case 0:
                    Debug.Log("Tämä on kohde 0");
                    teksti.text = "Mikkelin matkakeskus ja linja-autoasema. Bussini seuraavaan kohteeseen lähtee täältä, mutta minulla on vielä hetki aikaa. Ensimmäiseksi voisinkin käydä vaikka torilla.";
                    controller.timer += 50;
                    break;
                case 1:
                    Debug.Log("Tämä on kohde 1");
                    teksti.text = "Mikkelin tori. Täällä riittää menoa ja tapahtumia ympäri vuoden. Tänään on kuitenkin hiljaista. Kuuluisa Eepin Grillikin muutti toisaalle. Taidampa silti napata vähän hiukopalaa Suomi Grilliltä.";
                    controller.timer += 30;
                    break;
                case 2:
                    Debug.Log("Tämä on kohde 2");
                    teksti.text = "Aah, nyt jaksaa taas. Kaupungintalo onkin ihan tuossa lähellä, käympä katsomassa sitä.";
                    break;
                case 3:
                    Debug.Log("Tämä on kohde 3");
                    teksti.text = "Mikkelin kaupungintalo. Se on kuulemma rakennettu jo vuonna 1912. Viimeisenä kohteena voisin käydä tuomiokirkossa.";
                    controller.timer += 50;
                    break;
                case 4:
                    Debug.Log("Tämä on kohde 4");
                    teksti.text = "On sillä kokoa. Nyt pitääkin olla selfie...\n\n Kylläpä aika rientää. Nyt tuli kiire! Äkkiä takaisin linja-autoasemalle!";
                    controller.timer = 80;
                    break;
                case 5:
                    Debug.Log("Tämä on maali");
                    SceneManager.LoadScene("Scene_youWin");
                    break;
                default:
                    Debug.LogWarning("Pelaaja törmäsi kohteeseen jolla ei ole käsittelijää");
                    break;
            }

            puhekupla.SetActive(true);
            this.transform.parent.transform.GetChild(this.kohdeID + 1).gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
