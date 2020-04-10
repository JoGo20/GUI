using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;





public class AIGame : MonoBehaviour
{
    public GameObject whiteStone;
    public GameObject blackStone;
    private GameObject whiteObject;
    private GameObject blackObject;
    public Text player1_Score,player2_Score;
    int test = 0;

    int current_position_X = -180;
    int current_position_Y = -180;
    bool hide_On_press=false;
    bool whiteFound=false;
    bool blackFound=false;
    
    // Start is called before the first frame update
    void Start()
    {
        whiteObject=(GameObject) GameObject.Instantiate(whiteStone, new Vector3(-180, -180, -1), Quaternion.identity);

    }
    






    void Update()
    {
        
        
        hide_On_press=false;
        player2_Score.text = "Player 2 score: "+   test.ToString();
        player1_Score.text = "Player 1 score: "+   test.ToString();
        
 
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
