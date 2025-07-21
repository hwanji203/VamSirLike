using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update()
    {
        PlayerMoveInput();
    }

    private void PlayerMoveInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) == true)
        {
            transform.position += Vector3.up * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) == true)
        {
            transform.position += Vector3.down * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
        {
            transform.position += Vector3.left * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) == true)
        {
            transform.position += Vector3.right * Time.deltaTime;
        }
    }
}
