using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrolingScript : MonoBehaviour
{

// Variable "public" directement editable depuis l'editeur 
    // le multiplicateur de vitesse pour le deplacement de l'image
    public Vector2 parallaxEffectMultiplier;
    
// variable visible depuis la classe uniquement 
    // la position de la camera
    private Transform cameraTransform;
    // la dernier position de la 
    private Vector3 lastCameraPosition;


    void Start()
    {
        // on initialise le transform de la camera
        cameraTransform = Camera.main.transform;
        // on récupére un premier fois la dernier position 
        lastCameraPosition = cameraTransform.position;
    }

    private void FixedUpdate()
    {
        // on définie le delta ( la différance ) entre la position actuelle et la dernier position enregistrer 
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        // on deplace l'image  a la vitesse du multiplieur
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        // on enregistre la nouvelle position comme la dernier possition 
        lastCameraPosition = cameraTransform.position;

    }

}

