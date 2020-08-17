using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAudio : MonoBehaviour
{
    public Transform[] speakerPositions;
    private Transform thisAudioSource_;
    private int nextPosition_ = 0;
    private int switchingTo_;
    private int closeEnough_;
    private float speed_ = 2;
    private bool hasMoved_;

    //Random.Range(1, 9)
	// Use this for initialization
	void Start ()
    {
        thisAudioSource_ = gameObject.GetComponent<Transform>(); //enables movement for speaker(s)
        thisAudioSource_.transform.position = speakerPositions[nextPosition_].position; //moves speaker to random starting location
        hasMoved_ = false; //change to true when changing
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        MovingSpeakers();
	}

    void MovingSpeakers()
    {
        if (!hasMoved_) //if hasn't reached new location
        {
            if (thisAudioSource_.position == speakerPositions[nextPosition_].position) //if speaker reaches next location enable switching to adjacent location
            {
                switchingTo_ = Random.Range(1, 11); //determines if going up in list or down
                if (switchingTo_ <= 5)
                {
                    if (nextPosition_ > 0)
                    {
                        nextPosition_--;
                    }
                    else if (nextPosition_ == 0)
                    {
                        nextPosition_ = speakerPositions.Length - 1;
                    }
                }
                else if (switchingTo_ >= 6 && switchingTo_ <= 10)
                {
                    if (nextPosition_ == speakerPositions.Length - 1)
                    {
                        nextPosition_ = 0;
                    }
                    else if (nextPosition_ < speakerPositions.Length)
                    {
                        nextPosition_++;
                    }
                }
            }
            hasMoved_ = true; //sets to true when it has reached its previous location
        }
        else if (hasMoved_ && thisAudioSource_.position != speakerPositions[nextPosition_].position) //if it made it's previous location but is moving to new one
        {
            //below moves it to next location
            thisAudioSource_.transform.position = Vector3.MoveTowards(thisAudioSource_.position, speakerPositions[nextPosition_].position, speed_ * Time.deltaTime);
            hasMoved_ = false; //set up to say it hasn't moved to new location yet
        }
        
    }
}
