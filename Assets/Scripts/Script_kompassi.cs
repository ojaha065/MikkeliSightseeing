using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_kompassi : MonoBehaviour
{
    private GameObject[] targets;

    // Start is called before the first frame update
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Kohde");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        GameObject target;
        for(int i = 0;i < targets.Length; i++)
        {
            if (targets[i].activeSelf)
            {
                target = targets[i];
                transform.LookAt(target.transform);
                transform.rotation = Quaternion.Euler(0f, transform.rotation.eulerAngles.y, 0f);
                break;
            }
        }
    }
}
