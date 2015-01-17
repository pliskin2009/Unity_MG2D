using UnityEngine;
using System.Collections;

public class JoystickScript : MonoBehaviour {
	
	public CNAbstractController movementJoystick;
	
	private Transform transformCache;
	private Animator animador;
	
	private Transform camaraPrincipal;
	
	public float Velocidad;
	private int estado, estadoAnterior;
	// Use this for initialization
	void Awake()
	{
		animador = GetComponent<Animator>();
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
		
		relativeVector = camaraPrincipal.TransformDirection(relativeVector);
		relativeVector.z = 0f;
		relativeVector.Normalize();
		
		// It's actually 2D vector
		transformCache.position = transformCache.position + relativeVector*Velocidad;
		FaceMovementDirection(relativeVector);
	}
	
	private void FaceMovementDirection(Vector3 direction)
	{
		float AnguloObjetivo = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		if(AnguloObjetivo > 68 && AnguloObjetivo <= 112)
			estado = 1;
		if(AnguloObjetivo > 22 && AnguloObjetivo <= 68)
			estado = 2;
		if(AnguloObjetivo > -22 && AnguloObjetivo <= 22)
			estado = 3;
		if(AnguloObjetivo > -68 && AnguloObjetivo <= -22)
			estado = 4;
		if(AnguloObjetivo > -112 && AnguloObjetivo <= -68)
			estado = 5;
		if(AnguloObjetivo > -158 && AnguloObjetivo <= -112)
			estado = 6;
		if((AnguloObjetivo > 158 && AnguloObjetivo <= 180)|(AnguloObjetivo > -180 && AnguloObjetivo <= -158))
			estado = 7;
		if(AnguloObjetivo > 112 && AnguloObjetivo <= 158)
			estado = 8;
		
		if(estado != estadoAnterior)
		{
			if(estado == 1)
				animador.SetTrigger("Up");
			if(estado == 2)
				animador.SetTrigger("UpRight");
			if(estado == 3)
				animador.SetTrigger("Right");
			if(estado == 4)
				animador.SetTrigger("DownRight");
			if(estado == 5)
				animador.SetTrigger("Down");
			if(estado == 6)
				animador.SetTrigger("DownLeft");
			if(estado == 7)
				animador.SetTrigger("Left");
			if(estado == 8)
				animador.SetTrigger("UpLeft");

			estadoAnterior = estado;
		}
		
		animador.SetTrigger("Go");
	}
	
	private void StopMoving()
	{
		if(estado == 1)
			animador.SetTrigger("Up");
		if(estado == 2)
			animador.SetTrigger("UpRight");
		if(estado == 3)
			animador.SetTrigger("Right");
		if(estado == 4)
			animador.SetTrigger("DownRight");
		if(estado == 5)
			animador.SetTrigger("Down");
		if(estado == 6)
			animador.SetTrigger("DownLeft");
		if(estado == 7)
			animador.SetTrigger("Left");
		if(estado == 8)
			animador.SetTrigger("UpLeft");
	}
}
