using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gerenciador : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj;
    public Image profile;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float tyoingSpeed;
    private string[] sentence;
    private int index;

    public void Speech(Sprite p, string[] txt, string actorName)
    {
        dialogueObj.SetActive(true);
        profile.sprite = p;
        sentence = txt;
        actorNameText.text = actorName;
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence()
    {

        foreach(char letter in sentence[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(tyoingSpeed);
        }
    }

    public void NextSentence()
    {
        if(speechText.text == sentence[index])
        {
            //ainda a texto
            if(index < sentence.Length -1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                index =  0;
                dialogueObj.SetActive(false);
            }
        }
    }
   

}
