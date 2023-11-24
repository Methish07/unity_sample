using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReachComp : MonoBehaviour
{
    public void OnCollisionEnter(Collider other)
    {
        if (other.gameObject.name == "PlayerArmature")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
