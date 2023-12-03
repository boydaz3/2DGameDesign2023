using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SC_2DCoin : MonoBehaviour
{
    public static int totalCoins = 0;

    // Reference to the TextMeshProUGUI object for displaying the +1 message
   // public TextMeshProUGUI coinTextPrefab;

    void Awake()
    {
        //Make Collider2D as trigger 
        GetComponent<Collider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        //Destroy the coin if Object tagged Player comes in contact with it
        if (c2d.CompareTag("Player"))
        {
            //Add coin to counter
            totalCoins++;

            // Get Canvas RectTransform to convert world position to screen space
            RectTransform canvasRect = FindObjectOfType<Canvas>().GetComponent<RectTransform>();

            // Convert the coin's position to screen space
            Vector2 screenPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Camera.main.WorldToScreenPoint(transform.position), Camera.main, out screenPos);

            // Instantiate the coinTextPrefab as a child of the Canvas
          //  TextMeshProUGUI coinText = Instantiate(coinTextPrefab, canvasRect.transform);

            // Set the anchored position of the coinText to the calculated screenPos
          //  coinText.rectTransform.anchoredPosition = screenPos;

            // Set the text of the instantiated coinText to "+1"
          //  coinText.text = "+1";

            // Destroy the coinText object after a certain time (e.g., 1 second)
           // Destroy(coinText.gameObject, 1f);

            // Test: Print total number of coins
            //Debug.Log("You currently have " + SC_2DCoin.totalCoins + " Coins.");

            // Destroy the coin
            Destroy(gameObject);
        }
    }
}
