using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_triggerKohde : MonoBehaviour
{
    public GameObject puhekupla;
    public int kohdeID = -1;

    private Text teksti;

    // Start is called before the first frame update
    void Start()
    {
        teksti = puhekupla.transform.GetChild(0).GetComponent<Text>();
        if(kohdeID != 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
                    break;
                case 1:
                    Debug.Log("Tämä on kohde 1");
                    teksti.text = "Mikkelin tori. Täällä riittää menoa ja tapahtumia ympäri vuoden. Tänään on kuitenkin hiljaista. Kuuluisa Eepin Grillikin muutti toisaalle. Taidampa silti napata vähän hiukopalaa Suomi Grilliltä.";
                    break;
                case 2:
                    Debug.Log("Tämä on kohde 2");
                    teksti.text = "Aah, nyt jaksaa taas. Kaupungintalo onkin ihan tuossa lähellä.";
                    break;
                case 3:
                    Debug.Log("Tämä on kohde 3");
                    teksti.text = "Mikkelin kaupungintalo. Se kuulemma rakennettu jo vuonna 1912. Viimeisenä kohteena voisin käydä tuomiokirkossa.";
                    break;
                case 4:
                    Debug.Log("Tämä on kohde 4");
                    teksti.text = "On sillä kokoa. Nyt pitääkin olla selfie...\n\n Voihan lorem, kello onkin jo paljon. Nyt tuli kiire! Äkkiä takaisin linja-autoasemalle!";
                    break;
                case 5:
                    Debug.Log("Tämä on kohde maali");
                    teksti.text = "";
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
