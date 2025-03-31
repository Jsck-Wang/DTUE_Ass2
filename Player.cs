using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{


    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private GameInput gameInput;
    [SerializeField] private LayerMask counterslayerMask;

    private bool isWalking;
    private Vector3 lastInteractDir;

    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }


    public bool IsWalking()
    {
        return isWalking;
    }


    private void HandleInteractions()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        if(moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }




        float interactionDistance = 2f;
        if(Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactionDistance,counterslayerMask ))
        {if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                clearCounter.Interact();
            }
            
        }

        
    }


    




    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;


        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

            if (canMove)
            {
                moveDir = moveDirX;
            }

            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    moveDir = moveDirZ;
                }


                else
                {

                }






            }
        }





        if (canMove)
        {
            transform.position += moveDir * moveDistance;

        }




        //transform.position = transform.positon + (Vector3)inputVector;

        isWalking = moveDir != Vector3.zero;

        float rotateSpeed = 10f;

        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
    }



}
