using UnityEngine;

public class paddleBehaviour : MonoBehaviour
{
    public float Speed;
    public float LimitLeft = -9.2f; //I guessed these values. could be cleaner. ended up being smaller than 9.2
    public float LimitRight = 9.2f;
    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;

    void Update()
    {
        float movement = 0.0f;
        if (Input.GetKey(Left))
        {
            movement -= Speed;
        }

        if (Input.GetKey(Right))
        {
            movement += Speed;
        }
        //the variable movement is affecting the left axis
        transform.Translate(new Vector3(movement, 0.0f, 0.0f)*Time.deltaTime); 
        // clampedX establishes a perimeter in the x-based on the LimitLeft and LimitRight floats
        //its restricting the x axis basically
        float clampedX = Mathf.Clamp(transform.position.x , LimitLeft, LimitRight );
        Vector3 pos = transform.position; //ref to paddle's position
        pos.x = clampedX; //the x position is limited by clampedX
        transform.position = pos; //the position of the paddle is limited within the clampedX equation

}
