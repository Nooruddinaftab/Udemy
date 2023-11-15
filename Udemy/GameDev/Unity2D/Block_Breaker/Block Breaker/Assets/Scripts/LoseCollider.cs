using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoseCollider : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // avoid using load scene with string names
        SceneManager.LoadScene("GameOver");
    }
}
