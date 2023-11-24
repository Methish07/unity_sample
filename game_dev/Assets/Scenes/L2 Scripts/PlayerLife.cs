using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
   private Canvas deathCanvas;
    private bool isDead = false;
/*
    private void OnCollisionEnter(Collision collision)
    {
         Debug.Log("DED");
        if (collision.gameObject.tag == "server")
        {
         Debug.Log("double DED");
            Destroy(gameObject);
        }
    }*/


   
   private void Start()
    {
      Cursor.lockState = CursorLockMode.Locked;
        deathCanvas =  GameObject.FindWithTag("deathnote").GetComponent<Canvas>();
        deathCanvas.gameObject.SetActive(false);
    }
   public void OnCollisionEnter(Collision collision)
   {Debug.Log("COllition");
   if (collision.gameObject.CompareTag("server"))
   {
      Debug.Log("DEAD");
      Die();
      // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
   
   if (collision.gameObject.CompareTag("screen"))
   {
      Debug.Log("COMPLETE");
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
   if (collision.gameObject.CompareTag("Enemy"))
   {
      Debug.Log("DEAD");
      Die();
   }

   }
   void Die()
   {
   //GetComponent<MeshRenderer>().enabled = false;
   //GetComponent<Rigidbody>().isKinematic = true;
   //GetComponent<PlayerMovement>().enabled = false;
   isDead = true;
   deathCanvas.gameObject.SetActive(true);
   Invoke(nameof (ReloadLevel), 1.3f);
   }
   void ReloadLevel()  
   {
   SceneManager.LoadScene (SceneManager.GetActiveScene().name);
   }
}
