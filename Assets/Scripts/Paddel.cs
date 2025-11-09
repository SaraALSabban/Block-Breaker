using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddel : MonoBehaviour
{
    [SerializeField] float screenWidthInUnit = 16f;
    float minX =1.07f, maxX=15.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Input.mousePosition.x / Screen.width * screenWidthInUnit);

        float mouesPosInUnit = Input.mousePosition.x / Screen.width * screenWidthInUnit;
        // Vector2 paddelPos = new Vector2(mouesPosInUnit, transform.position.y); // this is true also
        Vector2 paddelPos = new Vector2(transform.position.x, transform.position.y);
        paddelPos.x = Mathf.Clamp(mouesPosInUnit, minX, maxX);//اعطيه قيمه اثبته بين قيمييتين

        transform.position = paddelPos;
    }
}
