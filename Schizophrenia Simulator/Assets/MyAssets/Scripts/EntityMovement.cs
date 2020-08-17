using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    private Vector3 OriginalSpot_;
    private Transform EntityMoving_;
    public float movementTimer_,
                 secondsWhileMoving_,
                 secondsUntilMove_,
                 seconds_;

    private bool hasWaited_,
                isMoving_;
    

	// Use this for initialization
	void Start ()
    {
        movementTimer_ = 15;
        secondsUntilMove_ = 5;

        EntityMoving_ = gameObject.GetComponent<Transform>();
        OriginalSpot_ = EntityMoving_.position;
	}

    // FixedUpdate is used for physics based movement
    void FixedUpdate()
    {
        if (hasWaited_)
        {
            if (seconds_ >= secondsUntilMove_)
            {
                StopCoroutine("WaitToMove");
                StopCoroutine("MovementTime");
                isMoving_ = false;
                seconds_ = 0;
                secondsWhileMoving_ = 0;
            }
            if(!isMoving_ && seconds_ == 0)
            {
                StartCoroutine("MovementTime");
                isMoving_ = true;
            }
            if (secondsWhileMoving_ < movementTimer_ && seconds_ == 0)
            {
                EntityMoving_.position += new Vector3(0, 0, -.01f) * Time.fixedDeltaTime;
            }
            else if (secondsWhileMoving_ >= movementTimer_ && seconds_ == 0)
            {
                EntityMoving_.position = OriginalSpot_;
                StopCoroutine("MovementTime");
                secondsWhileMoving_ = 0;
                hasWaited_ = false;
                isMoving_ = false;
                gameObject.SetActive(false);
            }
        }

        else if (!hasWaited_)
        {
            StartCoroutine("WaitToMove");
            hasWaited_ = true;
        }
	}

    IEnumerator WaitToMove()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            seconds_++;
        }
    }

    IEnumerator MovementTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            secondsWhileMoving_++;
        }
    }
}
