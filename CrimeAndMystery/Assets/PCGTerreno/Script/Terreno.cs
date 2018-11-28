using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Terreno : MonoBehaviour {

    public int profundidade = 10;
    public int largura = 256;
    public int altura = 256;
    public float escala = 10f;
    public float offsetx = 100f;
    public float offsety = 100f;
   

    // Use this for initialization
    void Start () {

        offsetx = UnityEngine.Random.Range(0, 999);
        offsety = UnityEngine.Random.Range(0, 999);

        
	}
	
	// Update is called once per frame
	void Update () {

        offsetx += Time.deltaTime ;
        offsety -= Time.deltaTime ;
        Terrain terreno = GetComponent<Terrain>();
        terreno.terrainData = GeraTerreno(terreno.terrainData);


    }

    //
    TerrainData GeraTerreno(TerrainData terrainData)
    {
        terrainData.heightmapResolution = largura + 1; //Resolução do heightmap

        terrainData.size = new Vector3(largura, profundidade, largura);

        terrainData.SetHeights(0, 0, GeraAlturas());//Define um array de amstras de heightmap
        return terrainData;
    }

    //Gera as alturas
    float[,] GeraAlturas()
    {
        float[,] alturas = new float[largura, altura];
        for(int x = 0; x<largura; x++)
        {
            for (int y = 0; y < altura; y++)
            {
                alturas[x, y] = CalculaAlturas(x, y);
            }
        }

        return alturas;
    }

    /*Calcula alturas retorna de forma "aleatoria" um padrao 
    Da um formato onda pq o noise n contem um valor completamente aleatorio em cada ponto, 
    mas consiste em "ondas" cujos valores aumentam ou diminuem gradualmente em todo o padrao.
    */
    float CalculaAlturas(int x, int y)
    {
        float xCoordenada = (float)x / largura * escala + offsetx;
        float yCoordenada = (float)y / largura * escala + offsety;

        return Mathf.PerlinNoise(xCoordenada, yCoordenada);
    }

}
