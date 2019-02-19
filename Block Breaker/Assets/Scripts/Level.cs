using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocksLeft = 0;
    SceneLoader sceneLoader;

    private void Awake()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void BlockAdded()
    {
        breakableBlocksLeft++;
    }

    public void BlockDestroyed()
    {
        breakableBlocksLeft--;
        if (breakableBlocksLeft==0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
