using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    
    public GameObject thePlatform;
    
    public Transform generationPoint;
   
    public float distanceBetween;

    private float platformWidth;

    public float distanceBetweenMin;


    public float distanceBetweenMax;

    private int platformSelector;


    private float[] platformWidths;

    public ObjectPooler[] theObjectPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    
    private CarrotGenerator theCarrotGenerator;

    
    public float randomCarrotThreshold;


   
    public float randomSpikeThreshold;

    
    public ObjectPooler spikePool;



    // Start is called before the first frame update
    void Start()
    {
        

        platformWidths = new float[theObjectPools.Length];

        for (int i = 0; i < theObjectPools.Length; i++) {

            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;



        }
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        
        theCarrotGenerator = FindObjectOfType<CarrotGenerator>();


    }

    // Update is called once per frame
    void Update()
    {

       
        if (transform.position.x < generationPoint.position.x)
        {
            
            distanceBetween = Random.Range(distanceBetweenMin,distanceBetweenMax);

            platformSelector = Random.Range(0, platformWidths.Length);

            
            heightChange = transform.position.y + Random.Range(maxHeightChange,-maxHeightChange);



            
            if (heightChange > maxHeight)
            {

                heightChange = maxHeight;

            }
            else if (heightChange < minHeight) {

                heightChange = minHeight;
            }


            
            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

          
         
            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

            
            newPlatform.transform.position = transform.position;
            
            
            newPlatform.transform.rotation = transform.rotation;
            
            
            newPlatform.SetActive(true);

            if (Random.Range(0f, 100f) < randomCarrotThreshold)
            {
                theCarrotGenerator.SpawnCarrots(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
            }


            // if the a random number between 0-100 is below the randomSpikeThreshold number 
            // and the platform width is not 3 then create the spikes
            if ((Random.Range(0f, 100f) < randomSpikeThreshold) && (platformWidths[platformSelector] != 3))
            {
                    
                    GameObject newSpike = spikePool.GetPooledObject();
                    
                    float spikeXPosition = Random.Range(-platformWidths[platformSelector] / 2f +1f, platformWidths[platformSelector] / 2f - 1f);


                    
                    Vector3 spikePosition = new Vector3(spikeXPosition, 0.5f, 0f);

                    
                    newSpike.transform.position = transform.position + spikePosition;        
                    
                    newSpike.transform.rotation = transform.rotation;
                    
                    newSpike.SetActive(true);

            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);

        }
    }
}
