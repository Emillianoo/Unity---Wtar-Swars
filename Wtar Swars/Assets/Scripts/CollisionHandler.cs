using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;
    [SerializeField] ParticleSystem crashVFX;

    void OnTriggerEnter(Collider other)
    {
        StartCrashSequence();
        //using VanishShip method after 1 sec
        Invoke("VanishShip", 1f);
    }

    void StartCrashSequence()
    {
        //playing crasfVFX and disabling playercontrol script
        crashVFX.Play();
        GetComponent<PlayerControl>().enabled = false;
        //restarting level after 2sec
        Invoke("ReloadLevel", loadDelay);
    }

    void VanishShip()
    {
        //vanishing ship (for all mesh rendere of children)
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
            r.enabled = false;
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}

