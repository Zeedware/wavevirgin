using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxCloud : MonoBehaviour 
{
	public Transform[] clouds;
	public float parallax_speed= 0.1f;

	private float minPos;
	private float secPos;


	void Start()
	{
		minPos = clouds [0].position.x;
		secPos = clouds [1].position.x;
	}

	void Update()
	{
		for(int i=0;i<clouds.Length;i++)
		{
			clouds [i].Translate (new Vector3 (parallax_speed * Time.deltaTime, 0, 0));
		}

		if(clouds[1].position.x<=minPos)
		{
			SwapClouds ();
		}
	}

	void SwapClouds()
	{
		Transform temp = clouds [1];
		clouds [1] = clouds [0];
		clouds [0] = temp;
		clouds [1].position = new Vector3 (secPos, clouds [1].position.y, clouds [1].position.z);
	}
}
