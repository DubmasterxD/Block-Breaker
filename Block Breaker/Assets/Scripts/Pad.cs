using UnityEngine;

public class Pad : MonoBehaviour
{
    float screenWidthInUnits = 16f;
    float padWidth = 3f;
    Ball ball;
    GameStatus gameStatus;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<Ball>();
    }

    private void Update()
    {
        Vector2 currPadPos = new Vector2(transform.position.x, transform.position.y);
        currPadPos.x = Mathf.Clamp(GetXPos(), (padWidth - screenWidthInUnits) / 2, (screenWidthInUnits - padWidth) / 2);
        transform.position = currPadPos;
    }

    private float GetXPos()
    {
        if(gameStatus.IsAutoPlayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits - screenWidthInUnits / 2;
        }
    }
}
