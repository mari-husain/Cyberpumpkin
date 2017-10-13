using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallaxManager : MonoBehaviour {
	public float backgroundSize; // must be set manually so the background knows how far
								// to transform itself to either the left or the right.

	public float parallaxSpeed; // controls the speed at which the background moves.

	private Transform cameraTransform;
	private float lastCameraX;

	private Transform[] layers;
	private float viewZone = 10;
	private int leftIndex;
	private int rightIndex;


	private void Start() {
		// populate the layers array with each of the background tiles we have created.
		cameraTransform = Camera.main.transform;
		lastCameraX = cameraTransform.position.x;

		layers = new Transform[transform.childCount];

		for (int i = 0; i < transform.childCount; i++) {
			layers [i] = transform.GetChild (i);
		}

		leftIndex = 0;
		rightIndex = layers.Length - 1;
	}

	private void Update() {

		// update the position of the background based on the speed at which the camera is moving
		// and the parallax speed.
		float deltaX = cameraTransform.position.x - lastCameraX;
		transform.position += Vector3.right * (deltaX * parallaxSpeed);

		// update the camera position
		lastCameraX = cameraTransform.position.x;

		// if we're too far to the left, scroll left, and vice versa.
		if(cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone)) {
			scrollLeft ();
		} else if(cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone)) {
			scrollRight ();
		}
	}

	private void scrollLeft() {
		int prevRight = rightIndex;

		// if the player is too far to the left, move the rightmost background tile to the far left.
		layers [rightIndex].position = new Vector3(layers [leftIndex].position.x - backgroundSize, layers[leftIndex].position.y, layers[leftIndex].position.z);

		// update our layers array to reflect the scroll.
		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex < 0)
			rightIndex = layers.Length - 1;
	}

	private void scrollRight() {
		int prevLeft = leftIndex;

		// if the player is too far to the right, move the leftmost background tile to the far left.
		layers [leftIndex].position = new Vector3(layers [rightIndex].position.x + backgroundSize, layers[rightIndex].position.y, layers[rightIndex].position.z);

		// update our layers array to reflect the scroll.
		rightIndex = leftIndex;
		leftIndex++;
		if (leftIndex == layers.Length)
			leftIndex = 0;
	}
}
