using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

// Variable "public" directement editable depuis l'editeur
    // vitesse de deplacement du laser
    public float speed = 5.0f;
    // temps de vie restant en secondde
    public float lifeTime = 2;
    // ennemie ou non 
    public bool ennemi = false;
    // nombre de dommage 
    public int damage = 1;

// variable visible depuis la classe uniquement 
    Rigidbody2D rb2d;

    void Start()
    {
        // on récupére le rigidbody du laser
        rb2d = GetComponent<Rigidbody2D>();
        // on définie la destruction du laser au bout du temps définie dans lifetime
        Destroy(gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        // si ce n'est pas un ennemie
        if (!ennemi)
        {
            // on applique au rigidbody du laser une force ver la droite
            rb2d.AddForce(new Vector2(speed, 0));
        }
        else
        {
            // on applique au rigidbody du laser une force ver la gauche
            rb2d.AddForce(new Vector2(-speed, 0));
        }

    }
}
