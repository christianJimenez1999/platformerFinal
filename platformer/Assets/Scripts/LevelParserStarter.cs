using System.Collections;
using System.Collections.Generic;
using System.IO;
using Packages.Rider.Editor.UnitTesting;
using TMPro;
using UnityEngine;

public class LevelParserStarter : MonoBehaviour
{
    public string filename;

    public GameObject Rock;

    public GameObject Brick;

    public GameObject QuestionBox;

    public GameObject Stone;

    public GameObject Water;

    public GameObject black;

    public GameObject white;

    public Transform parentTransform;

    public TextMeshProUGUI timer;
    public float timeDown = 100;



    // Start is called before the first frame update
    void Start()
    {
        RefreshParse();
    }


    private void Update()
    {
        
        if(timeDown > 0)
        {
            timeDown -= Time.deltaTime;
        }
        else
        {
           Debug.Log("The player has lost!");
        }

    }

    public void endgame()
    {
        Application.Quit();
    }

    private void FileParser()
    {
        string fileToParse = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Resources/", filename);

        //string fileToParse = "Assets/Resources/Test.txt";
        


        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            int row = 0;
            //Debug.Log("spawning1");
            while ((line = sr.ReadLine()) != null)
            {
                int column = 0;
                char[] letters = line.ToCharArray();
                foreach (var letter in letters)
                {
                    //Debug.Log("spawning1");
                    //Debug.Log(letter);
                    
                    SpawnPrefab(letter, new Vector3(column, -row, (float)-0.5));       
             
                    column++;
                }
                row++;
            }
            //Debug.Log("spawning1");
            sr.Close();
        }
    }

    private void SpawnPrefab(char spot, Vector3 positionToSpawn)
    {
        GameObject ToSpawn;

        switch (spot)
        {
            case 'b': ToSpawn = Brick; break;
                Debug.Log("Spawn Brick"); 
            case '?':
                ToSpawn = QuestionBox; break;
                Debug.Log("Spawn QuestionBox"); break;
            case 'x':
                ToSpawn = Rock; break;
                Debug.Log("Spawn Rock"); break;
            case 's':
                ToSpawn = Stone; break;
                Debug.Log("Stone Rock"); break;
            case 'w':
                ToSpawn = Water; break;
            case 'f':
                ToSpawn = black; break;
            case 'l':
                ToSpawn = white; break;
            //default: Debug.Log("Default Entered"); break;
            default: return;
                //ToSpawn = //Brick;       break;
        }

        ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
        ToSpawn.transform.localPosition = positionToSpawn;
    }

    public void RefreshParse()
    {
        GameObject newParent = new GameObject();
        newParent.name = "Environment";
        newParent.transform.position = parentTransform.position;
        newParent.transform.parent = this.transform;
        
        if (parentTransform) Destroy(parentTransform.gameObject);

        parentTransform = newParent.transform;
        FileParser();
    }
}
