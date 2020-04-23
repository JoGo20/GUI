using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;





public class AIGame : MonoBehaviour
{
    public GameObject whiteStone;
    public GameObject blackStone;
    private GameObject whiteObject;
    private GameObject blackObject;
    public Text player1_Score,player2_Score;
    int player1Score = 0;
    int player2Score = 0;


    int current_position_X = -180;
    int current_position_Y = -180;
    bool hide_On_press=false;
    bool whiteFound=false;
    bool blackFound=false;
    
    // Start is called before the first frame update
    void Start()
    {
        whiteObject=(GameObject) GameObject.Instantiate(whiteStone, new Vector3(-180, -180, -1), Quaternion.identity);
        //whiteObject=(GameObject) GameObject.Instantiate(whiteStone, new Vector3(0, 0, -1), Quaternion.identity);
        //ReadFile();

    }

    void clear_board()
    {
             GameObject[] argo =  GameObject.FindGameObjectsWithTag("whiteStone");
             GameObject[] argo1 =  GameObject.FindGameObjectsWithTag("blackStone");
            foreach (GameObject go in argo) {
              
              go.SetActive(false);
                
            }

            foreach (GameObject go in argo1) {
               
               go.SetActive(false);
               
            }
    }
    

void ReadFile()
{
var lines = File.ReadAllLines("D:/CUFE/6th_Semester/CMPN402_ MI/Project/Unity_GUI/GUI/Assets/board.txt");
var Scores = lines[0].Split(' ');
player1Score=int.Parse(Scores[0]);
player2Score=int.Parse(Scores[1]);

        for (int i = 1; i < lines.Length; i++)
        {
            var number=lines[i].Split(' ');
            var x_pos =int.Parse(number[0]);
            var y_pos =int.Parse(number[1]);
            var color =number[2];
            if(color=="black")
            {
               blackObject=(GameObject) GameObject.Instantiate(blackStone, new Vector3(x_pos*20, y_pos*20, -1), Quaternion.identity);
            }
            else{
                whiteObject=(GameObject) GameObject.Instantiate(whiteStone, new Vector3(x_pos*20, y_pos*20, -1), Quaternion.identity);
            }
            
        }

}




    void Update()
    {
        clear_board();
        ReadFile();
        hide_On_press=false;
        player1_Score.text = "Player 1 score: "+   player1Score.ToString();
        player2_Score.text = "Player 2 score: "+   player2Score.ToString();
          
 
        //test++;
        

        


//-----------------------------------------------------------------------------------------------------------------------------------------------
        if(Input.GetKeyDown("z")){
           
           whiteObject.transform.position= new Vector3(current_position_X,current_position_Y,-1);
           whiteObject=(GameObject) GameObject.Instantiate(whiteStone, new Vector3(current_position_X, current_position_Y, -1), Quaternion.identity);
           hide_On_press=true;
        }

        if(Input.GetKeyDown("y")){
            Instantiate(whiteStone, new Vector3(0, 0, -1), Quaternion.identity);
            Instantiate(whiteStone, new Vector3(0, 20, -1), Quaternion.identity);
            Instantiate(whiteStone, new Vector3(20, 20, -1), Quaternion.identity);

        }
        if(Input.GetKeyDown("b")){
             blackObject=(GameObject) GameObject.Instantiate(blackStone, new Vector3(20, 0, -1), Quaternion.identity);
             Instantiate(blackStone, new Vector3(180, 180, -1), Quaternion.identity);
            Instantiate(blackStone, new Vector3(180, 0, -1), Quaternion.identity);
            Instantiate(blackStone, new Vector3(-180, 0, -1), Quaternion.identity);
            Instantiate(blackStone, new Vector3(-180, -180, -1), Quaternion.identity);
            Instantiate(blackStone, new Vector3(0, 180, -1), Quaternion.identity);
            Instantiate(blackStone, new Vector3(0, -180, -1), Quaternion.identity);
             //blackObject=(GameObject) GameObject.Instantiate(blackStone, new Vector3(20, 0, -1), Quaternion.identity);
         }
         if(Input.GetKeyDown("c")){
             blackObject.SetActive(false);
             //RemoveStone();
             //whiteObject.SetActive(false);
         }

        if(Input.GetKeyDown("e")){
            SceneManager.LoadScene("MainMenu");
        }
        
    }
}
