using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PostProcessingCustom : MonoBehaviour
{
    public static PostProcessingCustom instance { get; set; }

    float intensity;
    Material material;

    bool activate;

    private void Awake()
    {
        if (instance != this && instance != null)
            Destroy(instance.gameObject);
        instance = this;

        material = new Material(Shader.Find("Hidden/_Shaderzin"));
    }

    private void Update()
    {
        if (activate)
        {
            intensity += Time.deltaTime;
            if(intensity >= 1f)
            {
                activate = false;
                intensity = 1f;
            }
        }
    }

    public void ActivateShader()
    {
        activate = true;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (intensity == 0)
        {
            Graphics.Blit(source, destination);
            return;
        }

        material.SetFloat("_GrayScale", intensity);

        Graphics.Blit(source, destination, material);
    }

}
