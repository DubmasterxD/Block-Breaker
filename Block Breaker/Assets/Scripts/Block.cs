using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound = null;
    [SerializeField] int pointsForDestroying = 100;
    [SerializeField] GameObject destroyParticleVFX = null;
    [SerializeField] GameObject nextBlock = null;
    Level level;

    private void Start()
    {
        AddBreakableBlock();
    }

    private void AddBreakableBlock()
    {
        level = FindObjectOfType<Level>();
        if (gameObject.CompareTag("Breakable"))
        {
            level.BlockAdded();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Breakable"))
        {
            BlockHit();
        }
    }

    private void BlockHit()
    {
        if (nextBlock != null)
        {
            DamageBlock();
        }
        else
        {
            DestroyBlock();
        }
    }

    private void DamageBlock()
    {
        GameObject block = Instantiate(nextBlock, transform.position, transform.rotation);
        block.GetComponent<Block>().SetPoints(pointsForDestroying);
        level.BlockDestroyed();
        Destroy(gameObject);
    }

    private void SetPoints(int newPoints)
    {
        pointsForDestroying = newPoints;
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        level.BlockDestroyed();
        TriggerDestroyParticleVFX();
        Destroy(gameObject);
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        FindObjectOfType<GameStatus>().AddToScore(pointsForDestroying);
    }

    private void TriggerDestroyParticleVFX()
    {
        GameObject sparkles = Instantiate(destroyParticleVFX, transform.position, transform.rotation);
        Destroy(sparkles, 0.2f);
    }
}
