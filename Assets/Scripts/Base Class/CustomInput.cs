using UnityEngine;

public class CustomInput
{
    public Vector2 currentAxis;
    public Vector2 savedAxis;

    public Vector2 Get2DInput()
    {
        Vector2 input = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            input.y = 0;
        else
            input.x = 0;

        currentAxis = input;

        if (currentAxis != Vector2.zero && currentAxis != savedAxis)
            savedAxis = currentAxis;

        return input;
    }
}
