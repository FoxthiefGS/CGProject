using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class FloorNeonLightsSystem : MonoBehaviour
{
    [SerializeField] List<Light> frontLightLines, backLightLines, leftLightLines, rightLightLines;
    int index;
    public float switchTime;

    private void Start()
    {
        StartCoroutine(switchLights(switchTime));
    }
    IEnumerator switchLights(float time)
    {
        yield return new WaitForSeconds(time);
        index++;
        if(index >= frontLightLines.Count)
        {
            frontLightLines[index - 1].enabled = false;
            backLightLines[index - 1].enabled = false;
            leftLightLines[index - 1].enabled = false;
            rightLightLines[index - 1].enabled = false;

            index = 0;

            frontLightLines[index].enabled = true;
            backLightLines[index].enabled = true;
            leftLightLines[index].enabled = true;
            rightLightLines[index].enabled = true;
        }
        else
        {
            frontLightLines[index - 1].enabled = false;
            backLightLines[index - 1].enabled = false;
            leftLightLines[index - 1].enabled = false;
            rightLightLines[index - 1].enabled = false;

            frontLightLines[index].enabled = true;
            backLightLines[index].enabled = true;
            leftLightLines[index].enabled = true;
            rightLightLines[index].enabled = true;
        }

        StartCoroutine(switchLights(switchTime));
    }

}
