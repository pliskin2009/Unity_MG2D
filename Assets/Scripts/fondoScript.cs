using UnityEngine;
using System.Collections;

/*Script Tutorial 2.5D para repetir fondo hasta ocupar tamaño deseado por programacion
 * 
 * Para calcular la distancia se divide el tamaño del Tile por el tamaño del pixel to unit de la Tile del suelo 
 * 
 * */


public class fondoScript : MonoBehaviour {

	//tile a repetir
		public Transform suelo;
	//Repeticiones eje X
		public int xRep;
	//Repeticiones eje Y
		public int yRep;
	//Distancia suelo y eje X
		public float xDistancia;
	//Distancia suelo y eje Y
		public float yDistancia;

	// Use this for initialization
	void Start () {
	
		//Repetir en X
		for (int x=0; x<xRep; x++) 
		{
			//Repetir en Y
			for (int y=0; y<yRep; y++) 
			{
				/*
				//Clonar Suelo (Metodo de instanciar objetos CARGA PESADA NO OPTIMA )
				Instantiate(suelo,new Vector3(x*xDistancia,y*yDistancia,0),Quaternion.identity);
				*/

				//CARGA OPTIMA INSTANCIAR UN UNICO OBJETO

				//Objeto que guardara la instancia
				Transform instancia;

				//Clonamos el Suelo en una nueva instancia
				instancia = Instantiate(suelo,new Vector3(x*xDistancia,y*yDistancia,0),Quaternion.identity) as Transform;

				//Asignamos al objeto Suelo Padre esta instancia , meter un objeto dentro de otro objeto

				instancia.parent = this.transform;
				
			}



		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
