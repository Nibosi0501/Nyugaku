using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Todohuken : MonoBehaviour
{
    [SerializeField] private Material todohukenMaterial1;
    [SerializeField] private Material todohukenMaterial2;
    [SerializeField] private Material todohukenMaterial3;
    [SerializeField] private Material todohukenMaterial4;
    [SerializeField] private Material todohukenMaterial5;
    [SerializeField] private Material todohukenMaterial6;
    [SerializeField] private Material todohukenMaterial7;
    [SerializeField] private Material todohukenMaterial8;
    [SerializeField] private Material todohukenMaterial9;

    private MeshRenderer meshRenderer;

    [SerializeField] private ChangeScene changeScene;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void ChangeMaterial(int todohukenNumber)
    {
        switch (todohukenNumber)
        {
            case 0:
                meshRenderer.material = todohukenMaterial1;
                break;
            case 1:
                meshRenderer.material = todohukenMaterial2;
                break;
            case 2:
                meshRenderer.material = todohukenMaterial3;
                break;
            case 3:
                meshRenderer.material = todohukenMaterial4;
                break;
            case 4:
                meshRenderer.material = todohukenMaterial5;
                break;
            case 5:
                meshRenderer.material = todohukenMaterial6;
                break;
            case 6:
                meshRenderer.material = todohukenMaterial7;
                break;
            case 7:
                meshRenderer.material = todohukenMaterial8;
                break;
            case 8:
                meshRenderer.material = todohukenMaterial9;
                break;
            case 9:
                changeScene.NextScene();
                break;
            default:
                Debug.LogWarning("todohukenNumberが不正です");
                break;
        }
    }
}
