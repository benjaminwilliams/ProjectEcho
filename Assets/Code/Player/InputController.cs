using System.Collections;
using UnityEngine;

public class InputController : MonoBehaviour {
    public PlayerCharacter playerCharacter;

    public delegate void InputHandler(Vector3 position);

	void Update () {
        if (GetComponent<NetworkView>().isMine)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                playerCharacter.StartMove(Character.Direction.Up);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                playerCharacter.StartMove(Character.Direction.Left);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                playerCharacter.StartMove(Character.Direction.Down);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                playerCharacter.StartMove(Character.Direction.Right);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                playerCharacter.StopMove(Character.Direction.Up);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                playerCharacter.StopMove(Character.Direction.Left);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                playerCharacter.StopMove(Character.Direction.Down);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                playerCharacter.StopMove(Character.Direction.Right);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CalculatePosition(playerCharacter.AbilityOne);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                CalculatePosition(playerCharacter.AbilityTwo);
            }
        }
	}

    private void CalculatePosition(InputHandler inputFunction)
    {
        RaycastHit hit;
        Ray ray;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 endPoint;

            endPoint = hit.point;
            endPoint.z = -1;

            inputFunction(endPoint);
        }
    }
}
