using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

// Variable "public" directement editable depuis l'editeur
    // le laser
    public GameObject thePrefab;
    // la vitesse du du joueur
    public Vector2 speed = new Vector2(5, 5);

// variable visible depuis la classe uniquement 
    // le rigidbody2d du joueur
    Rigidbody2D rb2d;
    // le scoremanager
    ScoreManager script;

    void Start()
    {
        // récupération du rigidbody du joueur
        rb2d = GetComponent<Rigidbody2D>();
        // récupératon du scoreManager
        script = GameObject.Find("Scripts").GetComponent<ScoreManager>();
    }


    void Update()
    {
        // l'orsqu'on appuis sur la touche espace et que le jeu n'est pas en gameover
        if (Input.GetKeyDown("space") && !script.gameOver)
        {
            // on créé un position pour le laser 
            var pos = transform.position;
            // on le positionne devant le joueur
            pos.x += 1f;
            // on instancie le laser     prefab    position      roataion
            var instance = Instantiate(thePrefab, pos, thePrefab.transform.rotation);
            // on définie que le laser est un laser joueur
            instance.GetComponent<LaserScript>().ennemi = false;
        }
    }

    void FixedUpdate()
    {
        //si le jeu n'est pas en mode gameOver
        if (!script.gameOver)
        {
            // on depalce le joueur en récupérant les input Horizontal et Vertical et les multipliant par la vitesse 
            rb2d.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * speed.x, 0.8f),
                                        Mathf.Lerp(0, Input.GetAxis("Vertical") * speed.y, 0.8f));
        }
        else
        {
            // la velocité est initialiser a 0 en cas de gameover
            rb2d.velocity = new Vector2(0f, 0f);
        }

    }
}
