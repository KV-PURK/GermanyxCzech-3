using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WallGen : MonoBehaviour
{
    private WallTemp wallTemp;
    private int rand;
    private int rand1;
    public static List<int> RotationList = new List<int>();
    private int RandomRotation;


    void Start()
    {

        RotationList.Add(90);
        RotationList.Add(-90);
        RotationList.Add(180);
        RotationList.Add(0);
        rand = Random.Range(0, 2);

        wallTemp=GameObject.FindGameObjectWithTag("Wall").GetComponent<WallTemp>();





    }

    // Update is called once per frame
    private void Update()
    {
        if (rand == 1)
        {


            rand1 = Random.Range(0, wallTemp.game.Length);
            Instantiate(wallTemp.game[rand1],transform.position = new Vector3(x:transform.position.x+1.35f,y:transform.position.y-1,z:-200), Quaternion.identity);
            rand = 2;
        }
        else if (rand == 2)
        {
            return;
        }
    }
}
