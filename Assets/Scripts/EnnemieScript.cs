using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieScript : MonoBehaviour
{

// Variable "public" directement editable depuis l'editeur
    public GameObject thePrefab;  // le prefab du laser ennemie

    public Vector2 speed = new Vector2(1, 1); // la vitesse du vesseaux en horizontal et lateral 

    public Vector2 direction = new Vector2(-1, 0); // la direction dans la quelle va le vesseaux
    public float shootingRate = 3f; // la fréquence en seconde a la quelle va le vesseaux 


// variable visible depuis la classe uniquement 
    Rigidbody2D rb2d; // le rigidbody2d de l'ennemie

    private Vector2 movement; // le vector qui sert au deplacement de l'ennemie

    private float shootCooldown; // le temps de récupération entre deux tir

    private bool isOnScreen = false; // l'ennemie est il présent a la camera
    private bool enterScreen = false; // l'ennemie est il rentré dans la camera
    ScoreManager script; // une reference vers le score manager

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        shootCooldown = 0f;
        script = GameObject.Find("Scripts").GetComponent<ScoreManager>();

    }

    void Update()
    {
        // le jeu est il perdu ?
        if (script.gameOver)
        {
            //si oui on detruit l'ennemie
            Destroy(gameObject);
        }

        // recuperation de la position de l'ennemie par raport a la camera
        Vector2 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        // verification si l'ennemie est dans la camera
        isOnScreen = screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        // iniitialisation du deplacement du joueur
        movement = new Vector2(speed.x * direction.x, speed.y * direction.y);

        // si il reste encore du temps de récupération
        if (shootCooldown > 0)
        {
            // on décompte le temps de récupération
            shootCooldown -= Time.deltaTime;
        }

        // si dans la camera
        if (isOnScreen)
        {
            //on attaque
            Attack();
            // on indique qu'on est entrer dans la camera
            enterScreen = true;
        }

        // si on et entré dans la camera et qu'on est plus sur la camera
        if (enterScreen && !isOnScreen)
        {
            // on detruit l'ennemie 
            Destroy(gameObject);
        }


    }

    void FixedUpdate()
    {
        // on deplace l'ennemie
        rb2d.velocity = movement;

    }


    public void Attack()
    {
        // si le temps de récupération est a 0
        if (shootCooldown <= 0f)
        {
            // on met le temps de récupération a la fréquance de tire
            shootCooldown = shootingRate;
            // on créé un position pour le laser
            var pos = transform.position;
            // on le positionne devant l'ennemie
            pos.x -= 1f;
            // on instancie le laser     prefab    position      roataion
            var instance = Instantiate(thePrefab, pos, thePrefab.transform.rotation);
            // on définie que le laser est un laser ennemie 
            instance.GetComponent<LaserScript>().ennemi = true;
        }
    }



}
