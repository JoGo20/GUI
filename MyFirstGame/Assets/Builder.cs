using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;





public class Builder : MonoBehaviour
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
    void RemoveWhiteStone()
    {
        bool surrounded_Right=false;
        bool surrounded_Left=false;
        bool surrounded_Up=false;
        bool surrounded_Down=false;
         GameObject[] argo =  GameObject.FindGameObjectsWithTag("whiteStone");
         GameObject[] argo1 =  GameObject.FindGameObjectsWithTag("blackStone");
         foreach (GameObject go_white in argo) {
            surrounded_Right=false;
            surrounded_Left=false;
            surrounded_Up=false;
            surrounded_Down=false;
            foreach (GameObject go_black in argo1) {
 
                if (go_white.transform.position.y+20==go_black.transform.position.y ){
                     surrounded_Up=true;
                }
                if (go_white.transform.position.y-20==go_black.transform.position.y ){
                    surrounded_Down=true;
                }
                if (go_white.transform.position.x+20==go_black.transform.position.x ){
                    surrounded_Right=true;
                }
                if (go_white.transform.position.x-20==go_black.transform.position.x ){
                    surrounded_Left=true;
                }
            }
            if(surrounded_Up && surrounded_Down && surrounded_Left && surrounded_Right && hide_On_press){
                go_white.SetActive(false);
            }
         }
            
    }


    void RemoveBlackStone()
    {
        bool surrounded_Right=false;
        bool surrounded_Left=false;
        bool surrounded_Up=false;
        bool surrounded_Down=false;
         GameObject[] argo =  GameObject.FindGameObjectsWithTag("whiteStone");
         GameObject[] argo1 =  GameObject.FindGameObjectsWithTag("blackStone");
         foreach (GameObject go_black in argo1) {
            surrounded_Right=false;
            surrounded_Left=false;
            surrounded_Up=false;
            surrounded_Down=false;
            foreach (GameObject go_white in argo) {
                
                if (go_black.transform.position.y+20==go_white.transform.position.y && go_black.transform.position.x==go_white.transform.position.x ){
                    surrounded_Up=true;
                    Debug.Log("here1");
                }
                if (go_black.transform.position.y-20==go_white.transform.position.y && go_black.transform.position.x==go_white.transform.position.x){
                    surrounded_Down=true;
                    Debug.Log("here2");

                }
                if (go_black.transform.position.x+20==go_white.transform.position.x && go_black.transform.position.y==go_white.transform.position.y){
                    surrounded_Right=true;
                    Debug.Log("here3");
                }
                if (go_black.transform.position.x-20==go_white.transform.position.x && go_black.transform.position.y==go_white.transform.position.y){
                    surrounded_Left=true;
                    Debug.Log("here4");
                }

            }
           
            if(surrounded_Up && surrounded_Down && surrounded_Left && surrounded_Right && hide_On_press){
                go_black.SetActive(false);
            }
//-------------------------------------------------------------------------------------------------------------------------------------------
//                                Corners
//-------------------------------------------------------------------------------------------------------------------------------------------
            if( hide_On_press && ((go_black.transform.position.x==180 && surrounded_Down && surrounded_Left && surrounded_Up ) || (go_black.transform.position.x==180 && go_black.transform.position.y==180 && surrounded_Down && surrounded_Left)))
            {
                go_black.SetActive(false);
            }
            if( hide_On_press && ((go_black.transform.position.x==-180 && surrounded_Down && surrounded_Right && surrounded_Up ) || (go_black.transform.position.x==-180 && go_black.transform.position.y==-180 && surrounded_Up && surrounded_Right)))
            {
                go_black.SetActive(false);
            }
            if( hide_On_press && ((go_black.transform.position.y==180 && surrounded_Down && surrounded_Right && surrounded_Left ) || (go_black.transform.position.x==180 && go_black.transform.position.y==-180 && surrounded_Up && surrounded_Left)))
            {
                go_black.SetActive(false);
            }
            if( hide_On_press && ((go_black.transform.position.y==-180 && surrounded_Left && surrounded_Right && surrounded_Up ) || (go_black.transform.position.x==-180 && go_black.transform.position.y==180 && surrounded_Down && surrounded_Right)))
            {
                go_black.SetActive(false);
            }
//---------------------------------------------------------------------------------------------------------------------------------------------
//--------------------------------------------------------------------------------------------------------------------------------------------

            
         }
            
    }








    void Update()
    {
        
        RemoveBlackStone();
        RemoveWhiteStone();
        hide_On_press=false;
        player2_Score.text = "Player 2 score: "+   test.ToString();
        player1_Score.text = "Player 1 score: "+   test.ToString();
        
 
        //test++;
        

        if(Input.GetKeyDown("w")){
             GameObject[] argo =  GameObject.FindGameObjectsWithTag("whiteStone");
             GameObject[] argo1 =  GameObject.FindGameObjectsWithTag("blackStone");
            foreach (GameObject go in argo) {
 
                if((go.transform.position.y==(current_position_Y+20))&&(go.transform.position.x==current_position_X)){
                    whiteFound=true;
                }
            }

            foreach (GameObject go in argo1) {
 
                if((go.transform.position.y==(current_position_Y+20))&&(go.transform.position.x==current_position_X)){
                    blackFound=true;
                }
            }

            if(whiteFound==false && blackFound ==false)
            {
              current_position_Y+=20;
            }

            if(current_position_Y>180){
               current_position_Y=-180; 
            }

           whiteObject.transform.position= new Vector3(current_position_X,current_position_Y,-1);
           whiteFound=false;
           blackFound=false;
        }

//-----------------------------------------------------------------------------------------------------------------------------------------
        
         if(Input.GetKeyDown("s")){

            GameObject[] argo =  GameObject.FindGameObjectsWithTag("whiteStone");
            GameObject[] argo1 =  GameObject.FindGameObjectsWithTag("blackStone");
            foreach (GameObject go in argo) {
 
                if((go.transform.position.y==(current_position_Y-20))&&(go.transform.position.x==current_position_X)){
                    whiteFound=true;
                }
            }

            foreach (GameObject go in argo1) {
 
                if((go.transform.position.y==(current_position_Y-20))&&(go.transform.position.x==current_position_X)){
                    blackFound=true;
                }
            }
            if(whiteFound==false && blackFound ==false)
            {
            current_position_Y-=20;
            }

            if(current_position_Y<-180){
               current_position_Y=180; 
            }
           whiteObject.transform.position= new Vector3(current_position_X,current_position_Y,-1);    // to draw
           whiteFound=false;
           blackFound=false;
        }

//--------------------------------------------------------------------------------------------------------------------------------------------

         if(Input.GetKeyDown("a")){
            GameObject[] argo =  GameObject.FindGameObjectsWithTag("whiteStone");
            GameObject[] argo1 =  GameObject.FindGameObjectsWithTag("blackStone");
            foreach (GameObject go in argo) {
 
                if((go.transform.position.y==(current_position_Y))&&(go.transform.position.x==current_position_X-20)){
                    whiteFound=true;
                }
            }

            foreach (GameObject go in argo1) {
 
                if((go.transform.position.y==(current_position_Y))&&(go.transform.position.x==current_position_X-20)){
                    blackFound=true;
                }
            }
            if(whiteFound==false && blackFound ==false)
            {
              current_position_X-=20;
            }
            
            if(current_position_X<-180){
               current_position_X=180; 
            }
           whiteObject.transform.position= new Vector3(current_position_X,current_position_Y,-1);
           whiteFound=false;
           blackFound=false;
        }

//---------------------------------------------------------------------------------------------------------------------------------------------
        
         if(Input.GetKeyDown("d")){
             GameObject[] argo =  GameObject.FindGameObjectsWithTag("whiteStone");
            GameObject[] argo1 =  GameObject.FindGameObjectsWithTag("blackStone");
            foreach (GameObject go in argo) {
 
                if((go.transform.position.y==(current_position_Y))&&(go.transform.position.x==current_position_X+20)){
                    whiteFound=true;
                }
            }

            foreach (GameObject go in argo1) {
 
                if((go.transform.position.y==(current_position_Y))&&(go.transform.position.x==current_position_X+20)){
                    blackFound=true;
                }
            }
            if(whiteFound==false && blackFound ==false)
            {
              current_position_X+=20;
            }

            if(current_position_X>180){
               current_position_X=-180; 
            }
           whiteObject.transform.position= new Vector3(current_position_X,current_position_Y,-1);
           whiteFound=false;
           blackFound=false;
        }





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
