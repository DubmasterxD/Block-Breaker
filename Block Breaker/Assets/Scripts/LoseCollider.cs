using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        sceneLoader.LoadScene("Scoreboard");
    }
}
