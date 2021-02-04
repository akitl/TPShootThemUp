using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

 // Variable "public" directement editable depuis l'editeur   
    public int hp = 1; // Variable pour les point de vie
    public bool isEnemy = true; // variable pour indiquer si c'est un ennemie ou non 

    // methode de base de unity qui détécte les colision entrante entre des game object qui un collider et un rigidBody
    void OnCollisionEnter2D(Collision2D coll)
    {
        // on unBox notre collider
        var collider = coll.collider;
        // on récupére notre laser script attacher au collider
        LaserScript shot = collider.gameObject.GetComponent<LaserScript>();


        // si le script as bien été récupéré
        if (shot != null)
        {
            // si le laser que l'on reçois et different de ce qu'on ai ( ennemie ou non )
            if (shot.ennemi != isEnemy)
            {
                // le collider est bien activé 
                collider.enabled = true;
                // on réduite les poit de vie par raport au nombre de dommage du laser
                hp -= shot.damage;
                // on détruit le laser
                Destroy(shot.gameObject);

                // si les point de vie sont a 0
                if (hp <= 0)
                {
                    // on récupére le score manager
                    GameObject scoreManager = GameObject.Find("Scripts");
                    //si c'est un ennemie
                    if (isEnemy)
                    {
                        // on augmente le score
                        scoreManager.GetComponent<ScoreManager>().score += 200;
                        // on detruit l'ennemie
                        Destroy(gameObject);
                    }
                    // si c'est un joueur
                    else
                    {
                        // on met le jeu en gameOver
                        scoreManager.GetComponent<ScoreManager>().gameOver = true;
                    }
                }
            }
            else
            {
                // on desactive les colision
                collider.enabled = false;
            }
        }
    }
}
