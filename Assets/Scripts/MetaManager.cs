using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaManager : MonoBehaviour
{
    public static MetaManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void LaunchGame()
    {
        MMSceneLoadingManager.LoadScene("Area1");
        //TO-DO: Detectar cuando termina la carga y lanzar una corutina que haga cosas?
        //Engancharme al GameManager, LevelManager, etc.
        //NO spawnear el personaje sino llamarlo desde el LevelManager cuando yo quiera
    }
}
