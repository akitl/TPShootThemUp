using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

// Variable "public" directement editable depuis l'editeur 
    // le Texte de score
    public Text scoreText;
    // Les interface de game over
    public GameObject gameOverPanel;
    // socre du jeu
    public int score = 0;
    //  etat du jeu 
    public bool gameOver = false;

    void Start()
    {
        // on lie la methode replay a l'evenement clikc du boutton 
         gameOverPanel.GetComponentInChildren<Button>().onClick.AddListener(Replay);
    }

    // Update is called once per frame
    void Update()
    {
        //  on met a jour le score ( concaténation entre un string "" et l'int du score )
        scoreText.text = ""+score;
        // si le jeu est en game Over
        if (gameOver){
            // on rend actif l'interface de game over
            gameOverPanel.SetActive(true);
            // on affiche le score final en récupéré le 2em texte du panel
            gameOverPanel.GetComponentsInChildren<Text>()[1].text = "Score final : "+score;
        }
    }

    public void Replay(){
          // on load la scéne du jeu a nouveaux 
          SceneManager.LoadScene("SampleScene");
    }
}
