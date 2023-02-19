using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WritingEffects : MonoBehaviour
{
    [SerializeField] int letterPerSeconds;
    [SerializeField] public TextMeshProUGUI dialogText;

    [TextArea]
    [SerializeField] string Text;
    //public bool begintoWrite = false;

    void Start()
    {
       // StartCoroutine(WritingDown(Text));
    }

 
  public void BegintoWrite()
    {
        StartCoroutine(WritingDown(Text));
    }

    public IEnumerator WritingDown(string dialog)
    {
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSeconds);
        }
    }
}
