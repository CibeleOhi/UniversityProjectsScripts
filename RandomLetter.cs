using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomLetter : MonoBehaviour {

    public string[] letter =new string[26] {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
    public int i;
    public Text letterText;
    private bool clicou;
    private int tempoDecorrido;

    public void Start()
    {
        clicou = false;
    }

    public void Clicou()
    {
        if (clicou == false)
        {
            clicou = true;
            StartCoroutine("Espera");    
        }      
    }

    public IEnumerator Espera()
    {        
      while (clicou == true)
        {
            yield return new WaitForSeconds(0.2f);
            tempoDecorrido++;
            i = Random.Range(0, 26);
        }
    }

    public void Update()
    {
        if (tempoDecorrido == 10)
        {
            clicou = false;
            StopCoroutine("Espera");
            tempoDecorrido = 0;
            
        }

        letterText.text = letter[i];
    }
}
