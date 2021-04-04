using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject menuGameOver;

    public Renderer fondo;
    public GameObject col;
    public GameObject roca1;
    public GameObject roca2;
    public float velocidad = 4;
    public bool gameOver = false;
    public bool start = false;
    private float controlHorizontal, controlVertical; //guarda control horizontal 

    public List<GameObject> cols;
    public List<GameObject> rocas;
    // Start is called before the first frame update
    void Start()
    {
        //Mapa
        for(int i=0; i < 5; i++)
        {
            cols.Add(Instantiate(col, new Vector2(-3 + i * 10, -5), Quaternion.identity));
        }

        //Piedras
        rocas.Add(Instantiate(roca1, new Vector2(15, -2), Quaternion.identity));
        rocas.Add(Instantiate(roca2, new Vector2(17, -1), Quaternion.identity));


    }

    // Update is called once per frame
    void Update()
    {
        controlHorizontal = Input.GetAxis("Horizontal") * velocidad; //obtiene el control horizontal de UNity
        controlVertical = Input.GetAxis("Vertical") * velocidad;
        transform.Translate(controlHorizontal * Time.deltaTime, controlVertical * Time.deltaTime,0); //desplaza objeto (x,y,z)
 
        if(start == false)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                start = true;
            }
        }
        
        if(start == true && gameOver == true)
        {
            menuGameOver.SetActive(true);
            if(Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if(start == true && gameOver == false)
        {
            menuPrincipal.SetActive(false);

            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;

            //Mueve Mapa
            for(int i=0; i<cols.Count; i++)
            {
                if (cols[i].transform.position.x <= -15)
                {
                    cols[i].transform.position = new Vector3(10, -5 , 0);
                }
                cols[i].transform.position = cols[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }

            //Mueve Obstaculos
            for(int i=0; i<rocas.Count; i++)
            {
                if (rocas[i].transform.position.x <= -15)
                {
                    float randomObstaculos = Random.Range(11, 18);
                    rocas[i].transform.position = new Vector3(randomObstaculos, -2, 0);
                }
                rocas[i].transform.position = rocas[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }
        }
    }
}
