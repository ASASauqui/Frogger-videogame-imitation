using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // ------------------Variables------------------
        private GameObject[] casita = new GameObject[5];
        public GameObject panel;
        public GameObject mensajeGanaste;
        public static int score = 0;
        public static int ranitasCasita = 0;
        public Text scoreText;


    // ------------------Start------------------
        void Start()
        {
            scoreText.text = score.ToString();
            casita[0] = GameObject.Find("/FinesCasitas/Fin/RanitaCasita");
            casita[1] = GameObject.Find("/FinesCasitas/Fin (1)/RanitaCasita");
            casita[2] = GameObject.Find("/FinesCasitas/Fin (2)/RanitaCasita");
            casita[3] = GameObject.Find("/FinesCasitas/Fin (3)/RanitaCasita");
            casita[4] = GameObject.Find("/FinesCasitas/Fin (4)/RanitaCasita");
        }


    // ------------------Updates------------------
        void FixedUpdate()
        {
            scoreText.text = score.ToString();
        }

        void Update()
        {
            // Verificar si se consiguieron las 5 ranitas para mostrar que se gano
            if (ranitasCasita == 5 && Frog.stop == false)
            {
                Debug.Log("Ganaste");
                Time.timeScale = 0.1f;
                Frog.stop = true;
                panel.SetActive(true);
                mensajeGanaste.SetActive(true);
                Frog.avance = -6;
            }

            // Verificar si se esta en pausa y se presiono el boton para reiniciar
            if (Frog.stop == true && Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1f;
                Frog.stop = false;
                panel.SetActive(false);
                mensajeGanaste.SetActive(false);
                Vidas.vidas = 5;
                ranitasCasita = 0;
                score = 0;
                Frog.avance = -6;
            }

            //Apagar casitas cuando no se este en pausa y se este en el inicio de la partida
            if (Frog.stop == false && Score.ranitasCasita == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    casita[i].SetActive(false);
                }
            }
        }
}
