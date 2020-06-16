using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] List<GameObject> spotLightTanks;
    int spotlightTankIndex;

    private void Start()
    {
        transform.position = new Vector3(-20, 9, 0);
        transform.DORotate(new Vector3(0, -90, 0), 0f);

        //transform.DOMoveY(1, 15f).OnComplete(() => {
        //    transform.DOMoveX(-20f, 10f);
        //});
        //transform.DORotate(new Vector3(0, -90, 0), 20f);

        StartCoroutine(ligthUp());

        transform.DOMoveX(25f, 10f).SetEase(Ease.Linear).OnComplete(() =>
        {
            transform.DOMoveY(20, 10f);
            transform.DORotate(new Vector3(30, -90, 0), 10f).OnComplete(() =>
            {
                transform.DOMove(new Vector3(-8, 34.4f, -22.8f), 5f);
                transform.DORotate(new Vector3(30, 0, 0), 5f).OnComplete(()=> {
                    transform.DOMove(new Vector3(-8, 16.4f, 6.7f), 5f);
                    transform.DORotate(new Vector3(0, 0, 0), 5f).OnComplete(()=> {
                        WarLigthsOn.instance.TurnOnTheLights();
                    });
                });
            });
        });

    }

    IEnumerator ligthUp()
    {
        yield return new WaitForSeconds(2f);
        spotLightTanks[spotlightTankIndex].GetComponent<Light>().enabled = true;
        spotlightTankIndex++;
        if(spotlightTankIndex < spotLightTanks.Count)
        {
            StartCoroutine(ligthUp());
        }
    }
}
