using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
   private void onCollisionEnter(Collision collision)
   {
   if (collision.gameObject.CompareTag("server"))
   {
   Die();
   }
   if (collision.gameObject.CompareTag("screen"))
   {
   SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
   }
   void Die()
   {
   GetComponent<MeshRenderer>().enabled = false;
   GetComponent<Rigidbody>().isKinematic = true;
  // GetComponent<PlayerMovement>().enabled = false;
   Invoke(nameof (ReloadLevel), 1.3f);
   }
   void ReloadLevel()  
   {
   SceneManager.LoadScene (SceneManager.GetActiveScene().name);
   }
}
