using UnityEngine;
using System.Collections;

/*
 * Realizado no ambito da UC Inteligencia Artificial - EDJD 3ºano
 * 
 *  Maze Generator - Backtracker
 * Escolhemos um ponto no campo para começar
 * Escolhemos aleatoriamente uma parede nesse ponto e 
 * faz uma passagem até À celula adjacente, de seguida essa celula
 * fica a ser a nova celula atual
 * Caso todos as celulas adjacentes tenham sido visitadas, volta para a ultima
 * celula q ntneh paredes e repete e sempre assim ate o processo for feito até ao
 * de inicio.
 */
public class MazeLoader : MonoBehaviour {
	public int mazeRows, mazeColumns;
	public GameObject wall;
    public GameObject floor;
    public GameObject Parent;
    public GameObject model;
    public GameObject chara;
	public float size = 2f;
    public Transform positionXmin, positionXmax;
    public Transform positionZmin, positionZmax;

    private MazeCell[,] mazeCells;

    private float _position;
    GameObject player;

    // Use this for initialization
    void Start () {


        player = GameObject.FindWithTag("Player");

        InitializeMaze ();

	   MazeAlgorithm ma = new BackTrackAlgorithm (mazeCells);

		ma.CreateMaze ();
	}

    public void DeleteAll()
    {
      
        {
            Destroy(Parent);
            Instantiate(Parent);
        }
    }

    //Gerar diversas vezes o labirinto, 
    IEnumerator Repetir()
    {
       
        yield return new WaitForSeconds(2f);

        DeleteAll();

        InitializeMaze();

        MazeAlgorithm ma = new BackTrackAlgorithm(mazeCells);

        ma.CreateMaze();
    }
	// Update is called once per frame
	void Update ()
    {
       
        //if (Vector3.Distance(transform.position, player.transform.position) < 10f)
            //StartCoroutine("Repetir");
	}

	private void InitializeMaze() {

		mazeCells = new MazeCell[mazeRows,mazeColumns];

		for (int linha = 0; linha < mazeRows; linha++) {
			for (int coluna = 0; coluna < mazeColumns; coluna++) {
				mazeCells[linha, coluna] = new MazeCell ();
				mazeCells[linha, coluna].floor = Instantiate (floor, new Vector3 (linha*size, -(size/2f), coluna*size), Quaternion.identity) as GameObject;
				mazeCells[linha, coluna].floor.name = "Floor " + linha + "," + coluna;
				mazeCells[linha, coluna].floor.transform.Rotate (Vector3.right, 90f);
                mazeCells[linha, coluna].floor.transform.parent = Parent.transform;


                if (coluna == 0) {
					mazeCells[linha, coluna].westWall = Instantiate (wall, new Vector3 (linha*size, 0, (coluna*size) - (size/2f)), Quaternion.identity) as GameObject;
					mazeCells[linha, coluna].westWall.name = "West Wall " + linha + "," + coluna;
                    mazeCells[linha, coluna].westWall.transform.parent = Parent.transform;
                }

				mazeCells[linha, coluna].eastWall = Instantiate (wall, new Vector3 (linha*size, 0, (coluna*size) + (size/2f)), Quaternion.identity) as GameObject;
				mazeCells[linha, coluna].eastWall.name = "East Wall " + linha + "," + coluna;
                mazeCells[linha, coluna].eastWall.transform.parent = Parent.transform;

                if (linha == 0) {
					mazeCells[linha, coluna].northWall = Instantiate (wall, new Vector3 ((linha*size) - (size/2f), 0, coluna*size), Quaternion.identity) as GameObject;
					mazeCells[linha, coluna].northWall.name = "North Wall " + linha + "," + coluna;
					mazeCells[linha, coluna].northWall.transform.Rotate (Vector3.up * 90f);
                    mazeCells[linha, coluna].northWall.transform.parent = Parent.transform;
                }

				mazeCells[linha,coluna].southWall = Instantiate (wall, new Vector3 ((linha*size) + (size/2f), 0, coluna*size), Quaternion.identity) as GameObject;
				mazeCells[linha, coluna].southWall.name = "South Wall " + linha + "," + coluna;
				mazeCells[linha, coluna].southWall.transform.Rotate (Vector3.up * 90f);
                mazeCells[linha, coluna].southWall.transform.parent = Parent.transform;
                
            }
		}

        //MakeEntrance();

       // SpawnObject();
    }
    
    void MakeEntrance()
    {
        mazeCells[15, 7].southWall.gameObject.active = false;
        mazeCells[8, 0].westWall.gameObject.active = false;
        mazeCells[7, 15].eastWall.gameObject.active = false;
        mazeCells[0, 7].northWall.gameObject.active = false;
    }

    void SpawnObject()
    {
        // positionXmin = transform.position;

        Vector3 position = new Vector3(Random.Range(0.0f, 89.5f), 0, Random.Range(0.0f, 89.5f));
        Vector3 position1 = new Vector3(Random.Range(0.0f, 89.5f), 0, Random.Range(0.0f, 89.5f));
        //Vector3 position = new Vector3(Random.Range(positionXmin.position.x, positionXmin.position.x), 0, Random.Range(positionZmin.position.z, positionZmax.position.z));
        Instantiate(model, position, Quaternion.identity);
        Instantiate(chara, position1, Quaternion.identity);
        
    }
}
