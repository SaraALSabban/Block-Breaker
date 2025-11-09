using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
     Rigidbody2D rigidbody2d;
    [SerializeField] Paddel paddel1;
    Vector2 paddelToBallVector;
    private bool hasStart = false;
    [SerializeField] float pushX = 2.0f, pushY=15.0f;
    AudioSource audioBall;
    [SerializeField] AudioClip[] bollSounds;

    [SerializeField] float randomFactor = 0.2f;
   

    // Start is called before the first frame update
    void Start()
    {
        paddelToBallVector = transform.position - paddel1.transform.position;
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioBall = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!hasStart)
        {
            LockBallToPaddel();
            LaunchOnMouesClick();

        }
       
    }

    private void LockBallToPaddel()
    {
        Vector2 paddelPos = new Vector2(paddel1.transform.position.x, paddel1.transform.position.y);
        transform.position = paddelPos + paddelToBallVector;

    }

    private void LaunchOnMouesClick()
    { 
        if (Input.GetMouseButtonDown(0))
        {
            hasStart = true;
            rigidbody2d.velocity = new Vector2(pushX, pushY);
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velociyTweak = new Vector2(Random.Range(0,randomFactor), Random.Range(0,randomFactor));

        if (hasStart)
        {
            AudioClip clip = bollSounds[Random.Range(0,bollSounds.Length)];
            audioBall.PlayOneShot(clip);
            rigidbody2d.velocity += velociyTweak;
        }
       
    }
















}
