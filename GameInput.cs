using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{



    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();


    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputVector = new Vector2(0, 0);
       

        if (Input.GetKey(KeyCode.T))
        {
            inputVector.y = +1;
        }

        if (Input.GetKey(KeyCode.G))
        {
            inputVector.y = -1;
        }

        if (Input.GetKey(KeyCode.F))
        {
            inputVector.x = -1;
        }

        if (Input.GetKey(KeyCode.H))
        {
            inputVector.x = +1;
        }

        inputVector = inputVector.normalized;

        

        return inputVector;
    }
}
