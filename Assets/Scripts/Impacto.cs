using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Impacto : MonoBehaviour
{
    AudioSource audi;
    public AudioClip sonido;

    GameObject panel;
    private bool bandera;
    private float contador;
    private int contador2;
    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        audi = GetComponent<AudioSource>();
        panel = GameObject.FindGameObjectWithTag("Panelito");
        bandera = false;
        contador = 0f;
        contador2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (bandera && contador < 2f)
        {
            contador = contador + Time.deltaTime;
            float proporcion = contador / 2f;
            image = panel.GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = proporcion;
            image.color = tempColor;
            panel.GetComponent<Image>().color = image.color;
        }

        if (contador > 2f)
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Choque>() && contador2 < 1)
        {
            contador = 1;
            audi.PlayOneShot(sonido, 1F);
            bandera = true;
            
        }
    }
}
