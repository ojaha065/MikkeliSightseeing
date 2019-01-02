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
                    teksti.text = "Tämä on puhekuplan teksti.";
                    break;
                default:
                    Debug.LogWarning("Pelaaja törmäsi kohteeseen jolla ei ole käsittelijää");
                    break;
            }

            puhekupla.SetActive(true);
        }
    }
}
