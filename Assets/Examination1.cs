using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examination1 : MonoBehaviour {

    public float rotationspeed = 10; // rotations hastigheten
    public float shipspeed = 3f; // skeppets hastighet
    public SpriteRenderer rend; // skeppets färg
    // timern räknar upp med ett varje sekund
    public float number = 1; // nummer så att timern bara printas en gång i sekunden
    public float timer; //timern
    public float random; // en variabel som blir ett random nummer i början av spelet
    public float positionX;

	// Use this for initialization
	void Start ()
    {
        float random = (Random.Range(1f, 10f));
        shipspeed = (random); // bestämmer hastigheten på skeppet
	}
	
	// Update is called once per frame
	void Update ()
    {
     
        float positionX = transform.position.x;
        float positiony = transform.position.y;


        timer = timer + Time.deltaTime;
        if (timer >= number)
        {
        print(string.Format("Timer:{0}",(int)timer)); // printar timern (int)timer gör så att det blir en int så att det inte finns decimaler
            number = number + 1;
        }
       
        transform.Translate(shipspeed * Time.deltaTime, 0, 0); // skeppet åker konstant framåt

        if (Input.GetKey(KeyCode.Space))
        {
            rend.color = new Color (Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f)); 
        } // bestämmer random färg när space hålls in

		if (Input.GetKey(KeyCode.D)) // när D knappen trycks ned roterar den till höger och byter färg till blå
        {
            transform.Rotate(0, 0, -rotationspeed * 2); // D går dubbelt så snabbt som A

            rend.color = Color.blue;
        }

        if (Input.GetKey(KeyCode.A)) // när A knappen trycks ned roterar den till vänster och byter färg till blå
        {
            transform.Rotate(0, 0, rotationspeed);
            rend.color = Color.green;
        }

        if (Input.GetKey(KeyCode.S)) // när S knappen trycks ned halveras skeppets hastighet
        {
            transform.Translate(-shipspeed / 2 * Time.deltaTime, 0, 0, Space.Self);
        }

        if (positionX > 12.5)
        {
            transform.position = new Vector2(-12.5f, transform.position.y);
         
           
        }
        if (positionX < -12.5)
        {
            transform.position = new Vector2(12.5f, transform.position.y);

           
        }


        if (positiony > 7)
        {
            transform.position = new Vector2(transform.position.x, -7f);
          
           
        }
        if (positiony < -7)
        {
            transform.position = new Vector2(transform.position.x, 7f);
           
           
        }


    }

       
}
