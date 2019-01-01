using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_triggerKohde : MonoBehaviour
{
    public int kohdeID = -1;

    // Start is called before the first frame update
    void Start()
    {
        
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
                    break;
                default:
                    Debug.LogWarning("Pelaaja törmäsi kohteeseen jolla ei ole käsittelijää");
                    break;
            }
        }
    }
}
