using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierGenerator : MonoBehaviour
{
    int pierLength = 15;
    [SerializeField] GameObject pierBlock;
    [SerializeField] GameObject pierOrigin;
    float pierSpacing = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0;i<=15;i++){
            GameObject newBlock = Instantiate(pierBlock);
            Vector3 posOffset = new Vector3(0, 0, pierSpacing * i);
            newBlock.transform.position = pierOrigin.transform.position + posOffset;
        }

        for( int i = 0;i <= 15;i++ )
        {
            GameObject newBlock = Instantiate(pierBlock);
            Vector3 posOffset = new Vector3(0, 0, -(pierSpacing * (i + 1)));
            newBlock.transform.position = pierOrigin.transform.position + posOffset;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
