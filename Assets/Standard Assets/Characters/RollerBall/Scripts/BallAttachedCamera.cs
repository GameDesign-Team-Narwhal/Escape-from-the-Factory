using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Vehicles.Ball
{
	public class BallAttachedCamera : MonoBehaviour {

		public GameObject ballObject;
		Camera ballCamera;
		Ball ball;
		BallUserControl ballControl;


		// Use this for initialization
		void Awake () {
			ballCamera = GetComponent<Camera> ();
			ball = ballObject.GetComponent<Ball>();
			ballControl = ballObject.GetComponent<BallUserControl>();

			ballControl.cam = transform;
		}
		
		// Update is called once per frame
		void Update () 
		{
			ballCamera.transform.position = ball.transform.position;


		}
	}
}
