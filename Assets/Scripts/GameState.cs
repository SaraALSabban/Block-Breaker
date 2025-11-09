using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameState : MonoBehaviour
{
   [Range(0.1f,10)] [SerializeField] float gameSpeed = 1f;

    [SerializeField] int currentScore = 0;
    [SerializeField] int pointsPerBlockDestroyed =10;


    [SerializeField] TextMeshProUGUI textScore;



    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameState>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(this.gameObject);

        }

        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        textScore.text = currentScore.ToString();
      
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        
    }


    public void AddToScore()
    {


        currentScore +=  pointsPerBlockDestroyed;
        textScore.text = currentScore.ToString();

    }




    public void ResetGame()
    {
        Destroy(gameObject);
        //currentScore = 0;
    }












}
