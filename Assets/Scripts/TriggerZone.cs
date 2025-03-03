using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerZone : MonoBehaviour
{
    // Set this reference in the inspector
    public TMP_Text output;

    // Enter the text you want to display in the inspector
    public string textToDisplay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
	// Debug.Log("Trigger by: " + collision);

	if(collision.gameObject.tag == "Player")
	{
	    // Display "You win!"
	    output.text = textToDisplay;
	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
