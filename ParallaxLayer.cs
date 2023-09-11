using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public GameObject target;
    public float elementSize;
    private int elementCount;
    public float maximumDistance;


    // Start is called before the first frame update
    void Start()
    {
        elementCount = transform.childCount;
    }

    // Update is called once per frame
	void Update () {
		for (int i = 0; i < elementCount; i++) {
			GameObject currentElement = transform.GetChild (i).gameObject;
			if (target.transform.position.x - currentElement.transform.position.x > maximumDistance) {
				currentElement.transform.position = new Vector3 (
					currentElement.transform.position.x + elementCount * elementSize,
					currentElement.transform.position.y,
					currentElement.transform.position.z
				);
			}
		}
	}
}
