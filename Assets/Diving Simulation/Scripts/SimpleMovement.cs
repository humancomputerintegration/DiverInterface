using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SimpleMovement : MonoBehaviour
{
	public float Speed = 0.0f;
	public OVRCameraRig CameraRig;
	public Text pinchDebug;


	public OVRHand leftHand;
	public OVRHand rightHand;

	public Rigidbody playerRigidbody;
	public InformationManager infMan;

	public event Action CameraUpdated;
	public event Action PreCharacterMove;


	float initialHandSpacing = 0f;
	bool inStroke = false;
	public bool leftFlat = false;
	public bool rightFlat = false;

	public bool leftFist = false;
	public bool rightFist = false;

	public void SetLeft(bool s)
	{
		leftFlat = s;
	}

	public void SetRight(bool s)
	{
		rightFlat = s;
	}

	public void rockLeft(bool s)
    {
		leftFist = s;
    }

	public void rockRight(bool s)
    {
		rightFist = s;
    }

	// Need to do: accept to booleans for swim.
	// Swim needs to check the distance between the two hands
	// Once it widens and then starts to get smaller again, 
	public Transform faceCamera;

	private void Awake()
	{
		if (leftHand == null) leftHand = GetComponent<OVRHand>();
	}

	Vector3 initialGravity;

	void Start ()
	{
		initialGravity = Physics.gravity;
	}
	
	private void FixedUpdate()
	{
		if (infMan.GetDepth() >= 0)
		{
			Physics.gravity = initialGravity;
			PinchMovement();
		} else
        {
			Physics.gravity = initialGravity * 0.01f;
			SwimMovement();
        }

		StopAllMovement();
	}

	void PinchMovement ()
    {
		bool isIndexFingerPinching = leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
		OVRHand.TrackingConfidence confidence = leftHand.GetFingerConfidence(OVRHand.HandFinger.Index);

		if ((confidence == OVRHand.TrackingConfidence.High) && isIndexFingerPinching)
		{
			pinchDebug.text = "Pinching";
			playerRigidbody.MovePosition(playerRigidbody.position + leftHand.PointerPose.forward * Speed * Time.fixedDeltaTime);
		}
		else
		{
			pinchDebug.text = "Not";
		}
	}

	void SwimMovement()
	{
		if (leftFlat && rightFlat) {
			if (!inStroke)
			{
				initialHandSpacing = Vector3.Distance(leftHand.transform.position, rightHand.transform.position);
				inStroke = true;
				StartCoroutine(Stroke());
			}
		} else
        {
			inStroke = false;
			initialHandSpacing = 0f;
        }
    }

	void StopAllMovement()
    {
		if (leftFist && rightFist)
        {
			playerRigidbody.velocity = Vector3.zero;
			playerRigidbody.angularVelocity = Vector3.zero;
        }
    }

	private IEnumerator Stroke ()
    {
		if (leftFlat && rightFlat && inStroke)
		{
			yield return new WaitForSeconds(1f); // Wait two seconds.
			float newHandSpacing = Vector3.Distance(leftHand.transform.position, rightHand.transform.position);
			float difference = newHandSpacing - initialHandSpacing;

			playerRigidbody.AddForce(Mathf.Clamp(difference, 0f, 2f) * 4f * faceCamera.forward, ForceMode.Impulse);
			inStroke = false;
		}
		else
        {
			inStroke = false;
        }
    }
}
