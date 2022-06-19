using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vidas : MonoBehaviour
{
    // ------------------Variables------------------
        public GameObject panel;
        public GameObject mensajePerdiste;
        private GameObject[] casita = new GameObject[5];
        public static int vidas = 5;
        public Text vidasText;


    // ------------------Start------------------
        void Start()
        {
            vidasText.text = vidas.ToString();
            casita[0] = GameObject.Find("/FinesCasitas/Fin/RanitaCasita");
            casita[1] = GameObject.Find("/FinesCasitas/Fin (1)/RanitaCasita");
            casita[2] = GameObject.Find("/FinesCasitas/Fin (2)/RanitaCasita");
            casita[3] = GameObject.Find("/FinesCasitas/Fin (3)/RanitaCasita");
            casita[4] = GameObject.Find("/FinesCasitas/Fin (4)/RanitaCasita");
        }


    // ------------------Updates------------------
        void FixedUpdate()
        {
            vidasText.text = vidas.ToString();
        }

        void Update()
        {
            // Verificar que ya no se tengan vidas para mostrar que se perdio el juego
            if(vidas == 0 && Frog.stop == false)
            {
                Debug.Log("Perdiste");
                Time.timeScale = 0.1f;
                Frog.stop = true;
                panel.SetActive(true);
                mensajePerdiste.SetActive(true);
                Frog.avance = -6;
            }

            // Verificar si se esta en pausa y se presiono el boton para reiniciar
            if (Frog.stop == true && Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1f;
                Frog.stop = false;
                panel.SetActive(false);
                mensajePerdiste.SetActive(false);
                vidas = 5;
                Score.ranitasCasita = 0;
                Score.score = 0;
                Frog.avance = -6;
            }

            // Forzar la desactivacion del mensaje
            if (Frog.stop == false)
            {
                mensajePerdiste.SetActive(false);
            }

            //Apagar casitas  cuando no se este en pausa y se este en el inicio de la partida
            if (Frog.stop == false && Score.ranitasCasita == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    casita[i].SetActive(false);
                }
            }
        }
}