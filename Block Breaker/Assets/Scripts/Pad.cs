using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{

    [SerializeField] private float screenWidthInUnits = 16f;
    private float padWidth = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseXPosition = Input.mousePosition.x / Screen.width * screenWidthInUnits - screenWidthInUnits / 2;
        Vector2 PadPos = new Vector2(transform.position.x, transform.position.y);
        PadPos.x = Mathf.Clamp(mouseXPosition, (padWidth - screenWidthInUnits) / 2, (screenWidthInUnits - padWidth) / 2);
        transform.position = PadPos;
    }
}
