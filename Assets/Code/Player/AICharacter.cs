using UnityEngine;
using System.Collections;

public abstract class AICharacter : Character
{
    private Vector3 movePoint;
    public bool isMoving;

    public override void Update()
    {
        if (GetComponent<NetworkView>().isMine)
        {
            //check if the flag for movement is true and the current gameobject position is not same as the clicked / tapped position
            if (isMoving && !Mathf.Approximately(gameObject.transform.position.magnitude, movePoint.magnitude))
            { //&& !(V3Equal(transform.position, endPoint))){
                //move the gameobject to the desired position
                gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, movePoint, 5 / (speed * (Vector3.Distance(gameObject.transform.position, movePoint))));
            }
            //set the movement indicator flag to false if the endPoint and current gameobject position are equal
            else if (isMoving && Mathf.Approximately(gameObject.transform.position.magnitude, movePoint.magnitude))
            {
                isMoving = false;
            }
        }
    }

    public void MoveTo(Vector3 position)
    {
        isMoving = true;
        movePoint = position;
    }
}
