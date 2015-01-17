using UnityEngine;
using System.Collections;

public class joystickAnimacionesScript : MonoBehaviour {
	
	public CNJoystick movementJoystick;
	
	private Transform transformCache;
	private AnimacionesScript animador;
	public float turnSpeed;
	
	private Transform camaraPrincipal;
	
	public float Velocidad;
	// Use this for initialization
	void Awake()
	{
		animador = GetComponent<AnimacionesScript>();
		if (movementJoystick == null)
		{
			throw new UnassignedReferenceException("Please specify movement Joystick object");
		}
		
		transformCache = transform;
		camaraPrincipal= Camera.main.GetComponent<Transform>();
	}
	
	void Update()
	{
		var movement = new Vector3(
			movementJoystick.GetAxis("Horizontal"),
			movementJoystick.GetAxis("Vertical"),
			0f);
		
		if(movement == Vector3.zero)
			StopMoving();
		else
			Move(movement);
	}
	
	// You can extend this class and override any of these virtual methods
	private void Move(Vector3 relativeVector)
	{
		
		// It's actually 2D vector
		
		
		relativeVector = camaraPrincipal.TransformDirection(relativeVector);
		relativeVector.z = 0f;
		relativeVector.Normalize();
		Vector3 sigPosicion = relativeVector * Velocidad + transformCache.position;
		transform.position = Vector3.Lerp( transformCache.position, sigPosicion, Time.deltaTime );
		FaceMovementDirection(relativeVector);
	}
	
	private void FaceMovementDirection(Vector3 direction)
	{
		
		float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		if(targetAngle > 68 && targetAngle <= 112)
			animador.estado = 1;
		if(targetAngle > 22 && targetAngle <= 68)
			animador.estado = 3;
		if(targetAngle > -22 && targetAngle <= 22)
			animador.estado = 5;
		if(targetAngle > -68 && targetAngle <= -22)
			animador.estado = 7;
		if(targetAngle > -112 && targetAngle <= -68)
			animador.estado = 9;
		if(targetAngle > -158 && targetAngle <= -112)
			animador.estado = 11;
		if((targetAngle > 158 && targetAngle <= 180)|(targetAngle > -180 && targetAngle <= -158))
			animador.estado = 13;
		if(targetAngle > 112 && targetAngle <= 158)
			animador.estado = 15;
		
	}
	
	private void StopMoving()
	{
		//Se mueve arriba
		animador.pararAnimacion();
	}
}
