using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLightSystem : MonoBehaviour
{
    List<GameObject> lightsOn = new List<GameObject>();
    List<GameObject> lights = new List<GameObject>();
    [SerializeField] float switchTime;

    private void Start()
    {
        for(int i =0; i < transform.childCount; i++)
        {
            lights.Add(transform.GetChild(i).gameObject);
            transform.GetChild(i).gameObject.GetComponent<Light>().enabled = false;
        }

        StartCoroutine(switchLights(switchTime));
    }

    IEnumerator switchLights(float time)
    {
        yield return new WaitForSeconds(time);
        foreach(GameObject g in lightsOn)
        {
            g.GetComponent<Light>().enabled = false;
        }
        lightsOn.Clear();

        foreach(GameObject g in lights)
        {
            int aux = Random.Range(0, 2);

            if(aux == 0)
            {
                g.GetComponent<Light>().enabled = true;
                lightsOn.Add(g);
            }
        }

        StartCoroutine(switchLights(switchTime));

    }
}
