using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakBloccks;
    SceneLoader sceneLader;


    private void Start()
    {
        sceneLader = FindObjectOfType<SceneLoader>();
    }
    public void CountsBolcks()
    {
        breakBloccks++;
       
    
    }






    public void BloackDestroyed()
    {

        breakBloccks--;
        if (breakBloccks == 0)
        {
            sceneLader.LoadNextScene();
        }
    
    
    
    }





}
