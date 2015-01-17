using UnityEngine;
using System.Collections;

public class AnimacionesScript : MonoBehaviour {

	//estado = 0 ( Stand UP )  estado = 1 ( Walk UP )
	//estado = 2 ( Stand UP_RIGHT )  estado = 3 ( Walk UP_RIGHT )
	//estado = 5 ( Stand RIGHT )  estado = 5 ( Walk RIGHT )
	//estado = 6 ( Stand DOWN_RIGHT )  estado = 7 ( Walk DOWN_RIGHT )
	//estado = 8 ( Stand DOWN )  estado = 9 ( Walk DOWN )
	//estado = 10 ( Stand DOWN_LEFT )  estado = 11( Walk DOWN_LEFT )
	//estado = 12 ( Stand LEFT )  estado = 13 ( Walk LEFT )
	//estado = 14 ( Stand UP_LEFT )  estado = 15 ( Walk UP_LEFT )

	public int estado = 0;

	//Lista Sprites Stand
	public Sprite[] spritesStand_UP;
	public Sprite[] spritesStand_UP_RIGHT;
	public Sprite[] spritesStand_RIGHT;
	public Sprite[] spritesStand_DOWN_RIGHT;
	public Sprite[] spritesStand_DOWN;
	public Sprite[] spritesStand_DOWN_LEFT;
	public Sprite[] spritesStand_LEFT;
	public Sprite[] spritesStand_UP_LEFT;

	//Lista Sprites Andar
	public Sprite[] spritesUP;
	public Sprite[] spritesUP_RIGHT;
	public Sprite[] spritesRIGHT;
	public Sprite[] spritesDOWN_RIGHT;
	public Sprite[] spritesDOWN;
	public Sprite[] spritesDOWN_LEFT;
	public Sprite[] spritesLEFT;
	public Sprite[] spritesUP_LEFT;

	public float framesPorSegundo;
	private SpriteRenderer spriteRenderer;
	private bool pausa;
	private float tiempoEntreEstados = 0.12f;

	void Start(){

		spriteRenderer = renderer as SpriteRenderer;

		//pausa debe ser igual a una variable global pausa
	}

	void Update(){

		if (pausa == false) 
		{
			int indice = (int)(Time.timeSinceLevelLoad * framesPorSegundo);

			indice = indice % spritesUP.Length;

			if(estado == 0)
				//spriteRenderer.sprite = spritesUP[0];
				spriteRenderer.sprite = spritesStand_UP[0];
			if(estado == 1)
				spriteRenderer.sprite = spritesUP[indice];
			if(estado == 2)
				//spriteRenderer.sprite = spritesUP_RIGHT[0];
				spriteRenderer.sprite = spritesStand_UP_RIGHT[0];
			if(estado == 3)
				spriteRenderer.sprite = spritesUP_RIGHT[indice];
			if(estado == 4)
				spriteRenderer.sprite = spritesStand_RIGHT[0];
			if(estado == 5)
				spriteRenderer.sprite = spritesRIGHT[indice];
			if(estado == 6)
				spriteRenderer.sprite = spritesStand_DOWN_RIGHT[0];
			if(estado == 7)
				spriteRenderer.sprite = spritesDOWN_RIGHT[indice];
			if(estado == 8)
				spriteRenderer.sprite = spritesStand_DOWN[indice];
			if(estado == 9)
				spriteRenderer.sprite = spritesDOWN[indice];
			if(estado == 10)
				spriteRenderer.sprite = spritesStand_DOWN_LEFT[0];
			if(estado == 11)
				spriteRenderer.sprite = spritesDOWN_LEFT[indice];
			if(estado == 12)
				spriteRenderer.sprite = spritesStand_LEFT[0];
			if(estado == 13)
				spriteRenderer.sprite = spritesLEFT[indice];
			if(estado == 14)
				spriteRenderer.sprite = spritesStand_UP_LEFT[0];
			if(estado == 15)
				spriteRenderer.sprite = spritesUP_LEFT[indice];

		}

	}


	public void pararAnimacion()
	{
		if(estado % 2 != 0 )
			estado = estado - 1;
	}

	public void comenzarAnimacion()
	{
		estado = estado + 1;
	}
}
