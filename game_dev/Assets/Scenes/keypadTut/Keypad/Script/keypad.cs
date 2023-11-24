using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keypad : MonoBehaviour
{
    
    [Header("Objects to Hide/Show")]
    public GameObject objectToDisable;
    public GameObject objectToDisable2;

    
    public GameObject objectToEnable;

   

    [Header("Keypad Settings")]
    public string curPassword = "234";
    public string input;
    public Text displayText;
    public AudioSource audioData;

    
    private bool keypadScreen;
    private float btnClicked = 0;
    private float numOfGuesses;

    
    void Start()
    {
        btnClicked = 0; // No of times the button was clicked
        numOfGuesses = curPassword.Length; // Set the password length.
    }


    void Update()
    {
        if (btnClicked == numOfGuesses)
        {
            if (input == "234")
            {
                //Load the next scene
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    
                
                Debug.Log("Correct Password!");
                input = ""; 
                btnClicked = 0;

            }
            else
            {
                
                input = "";
                displayText.text = input.ToString();
                audioData.Play();
                btnClicked = 0;
            }

        }

    }

    void OnGUI()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                var selection = hit.transform;

                if (selection.CompareTag("keypad")) // Tag on the gameobject - Note the gameobject also needs a box collider
                {
                    keypadScreen = true;

                    var selectionRender = selection.GetComponent<Renderer>();
                    if (selectionRender != null)
                    {
                        keypadScreen = true;
                    }
                }

            }
        }

        // Disable sections when keypadScreen is set to true
        if (keypadScreen)
        {
            objectToDisable.SetActive(false);
            objectToDisable2.SetActive(false);
            objectToEnable.SetActive(true);
        }

    }

    public void ValueEntered(string valueEntered)
    {
        switch (valueEntered)
        {
            case "Q": // QUIT
                objectToDisable.SetActive(true);
                objectToDisable2.SetActive(true);
                objectToEnable.SetActive(false);
                btnClicked = 0;
                keypadScreen = false;
                input = "";
                displayText.text = input.ToString();
                break;

            case "C": //CLEAR
                input = "";
                btnClicked = 0;// Clear Guess Count
                displayText.text = input.ToString();
                break;

            default: // Buton clicked add a variable
                btnClicked++; // Add a guess
                input += valueEntered;
                displayText.text = input.ToString();
                break;
        }


    }
}
