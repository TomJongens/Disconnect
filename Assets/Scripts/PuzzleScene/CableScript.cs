using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//This is the cable script. I was looking for better solution but you can use these codes to. We are using line renderer component to create cables. 
public class CableScript : MonoBehaviour
{
    public LineRenderer cable1;
    public LineRenderer cable2;
    public LineRenderer cable3;
    public Transform c1pos1;
    public Transform c1pos2;
    public Transform c1pos3;
    public Transform c1pos4;
    public Transform c2pos1;
    public Transform c2pos2;
    public Transform c2pos3;
    public Transform c2pos4;
    public Transform c3pos1;
    public Transform c3pos2;
    public Transform c3pos3;
    public Transform c3pos4;
    public Transform c3pos5;
    public Transform c3pos6;
    
    

    // Start is called before the first frame update
    void Start()
    {
        cable1.positionCount = 4;
        cable2.positionCount = 4;
        cable3.positionCount = 6;

    }

    // Update is called once per frame
    void Update()
    {
        cable1.SetPosition(0, c1pos1.position);
        cable1.SetPosition(1, c1pos2.position);
        cable1.SetPosition(2, c1pos3.position);
        cable1.SetPosition(3, c1pos4.position);
       
        
        cable2.SetPosition(0, c2pos1.position);
        cable2.SetPosition(1, c2pos2.position);
        cable2.SetPosition(2, c2pos3.position);
        cable2.SetPosition(3, c2pos4.position);
        
        cable3.SetPosition(0, c3pos1.position);
        cable3.SetPosition(1, c3pos2.position);
        cable3.SetPosition(2, c3pos3.position);
        cable3.SetPosition(3, c3pos4.position);
        cable3.SetPosition(4, c3pos5.position);
        cable3.SetPosition(5, c3pos6.position);

    }
}
