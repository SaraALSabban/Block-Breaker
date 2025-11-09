using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakBloak;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits = 2;
    [SerializeField] int timesHits;
    [SerializeField] Sprite[] spritHit;
    Level level;

      

    private void Start()
    {


        CountBreakableBolcks();



    }


    private void CountBreakableBolcks()
    {

        level = FindObjectOfType<Level>();

        if (level == null)
        {
            Debug.Log("level in block scripts in not find");
        }

        if (tag == "Breakable")
        {
            level.CountsBolcks();

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandelHit();

        }




    }

    private void HandelHit()
    {
        timesHits++;
        int maxHits = spritHit.Length +1;
        if (timesHits >= maxHits)
        {
            DestroyBloack();

        }


        else
        {
            ShowNextHitSprite();
        
        }
    }

    private void ShowNextHitSprite()
    {
        int spritIndex = timesHits - 1;
        if (spritHit[spritIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = spritHit[spritIndex];
        }

        else
        {
            Debug.LogError("Block Sprits is null");
        }
       
    }

    private void DestroyBloack()
    {
        PlayBlockSound();
        Destroy(this.gameObject);
        level.BloackDestroyed();
        TriggerSparklesVFX();
    }



    private void PlayBlockSound()
    {
        FindObjectOfType<GameState>().AddToScore();

        AudioSource.PlayClipAtPoint(breakBloak, Camera.main.transform.position);

    }



    private void TriggerSparklesVFX()
    {

       GameObject sprkles =  Instantiate(blockSparklesVFX, transform.position, Quaternion.identity);
        Destroy(sprkles, 1f);
    }








}
