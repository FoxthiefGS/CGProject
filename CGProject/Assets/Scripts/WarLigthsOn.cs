using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class WarLigthsOn : MonoBehaviour
{
    public static WarLigthsOn instance { get; set; }

    [SerializeField] GameObject keyLight, fillLight, backLight, bunny;

    [SerializeField] PostProcessVolume ppVolume;
    [SerializeField] FloatParameter floatParameter;

    private void Start()
    {
        if (instance != null && instance != this)
            Destroy(instance.gameObject);
        instance = this;
    }


    public void TurnOnTheLights()
    {

        ppVolume.gameObject.SetActive(true);
        backLight.GetComponent<Light>().enabled = true;
        transform.DOMove(transform.position, 0.5f).OnComplete(() =>
        {
            fillLight.GetComponent<Light>().enabled = true;
            transform.DOMove(transform.position, 0.5f).OnComplete(() =>
            {
                keyLight.GetComponent<Light>().enabled = true;

                RenderSettings.ambientIntensity = 0f;
                RenderSettings.reflectionIntensity = 0f;

                bunny.GetComponent<Animator>().enabled = true;
            });
        });
    }
    
}
