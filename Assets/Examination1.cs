using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Examination1 : MonoBehaviour {

    public float rotationspeed = 5; // rotations hastigheten

    public float shipspeed; // skeppets hastighet
    public float random; // en variabel som blir ett random nummer i början av spelet för hastigheten

    public SpriteRenderer rend; // skeppets färg
    public SpriteRenderer rend2; // vinge etts färg
    public SpriteRenderer rend3; // vinge tvås färg

    public float number = 1; // nummer så att timern bara printas en gång i sekunden
    public float timer;  // timern räknar upp med ett varje sekund



    // Use this for initialization
    void Start ()
    {
        float random = (Random.Range(1f, 10f));
        shipspeed = (random); // bestämmer hastigheten på skeppet 

        transform.Translate(new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 5f))); // placerar ut skeppet på en random position i början av spelet
	}
	
	// Update is called once per frame
	void Update ()
    {
     

        timer = timer + Time.deltaTime;
        if (timer >= number)
        {
        print(string.Format("Timer: {0}",(int)timer)); // printar timern (int)timer gör så att det blir en int så att det inte finns decimaler
            number = number + 1;
        }
       
        transform.Translate(shipspeed * Time.deltaTime, 0, 0); // skeppet åker konstant framåt

        if (Input.GetKey(KeyCode.Space))
        {
            rend.color = new Color (Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
            rend2.color = new Color (Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
            rend3.color = new Color (Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
        } // bestämmer random färg när space hålls in på alla ship delarna om den hålls in blinkar dens färger

		if (Input.GetKey(KeyCode.D)) // när D knappen trycks ned roterar den till höger och byter färg till blå
        {
            transform.Rotate(0, 0, -rotationspeed * 2); // D går dubbelt så snabbt som A

            rend.color = Color.blue;
            rend2.color = Color.blue;
            rend3.color = Color.blue;

        }

        if (Input.GetKey(KeyCode.A)) // när A knappen trycks ned roterar den till vänster och byter färg till grön
        {
            transform.Rotate(0, 0, rotationspeed);
            rend.color = Color.green;
            rend2.color = Color.green;
            rend3.color = Color.green;
        }

        if (Input.GetKey(KeyCode.S)) // när S knappen trycks ned halveras skeppets hastighet
        {
            transform.Translate(-shipspeed / 2 * Time.deltaTime, 0, 0, Space.Self);
        }

        float positionX = transform.position.x; // skeppets position på x
        float positiony = transform.position.y; // skeppets position på y

        float edgeX = 12.5f; // spel rutans kanter för X
        float edgeY = 7; // spel rutans kanter för Y

        if (positionX > edgeX) // om skeppet går utanför kanten på positiva X
        {
            transform.position = new Vector2(-edgeX, transform.position.y); // skickar då skeppet till motsatta sidan av skärmen
        }
        if (positionX < -edgeX) // om skeppet går utanför kanten på negativa X
        {
            transform.position = new Vector2(edgeX, transform.position.y); // skickar då skeppet till motsatta sidan av skärmen
        }
        if (positiony > edgeY) // om skeppet går utanför kanten på positiva Y
        {
            transform.position = new Vector2(transform.position.x, -edgeY); // skickar då skeppet till motsatta sidan av skärmen
        }
        if (positiony < -edgeY) // om skeppet går utanför kanten på negativa Y
        {
            transform.position = new Vector2(transform.position.x, edgeY); // skickar då skeppet till motsatta sidan av skärmen
        }


    }

       
}
