using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    //
    int waveCount; //Which number wave we're on
    bool waveActive; //Whether we are currently spawning enemies
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BuildWave()
    {

    }

    /// <summary>
    /// Increases wave count and begins wave when UI button is clicked.
    /// </summary>
    void BeginNextWave()
    {
        waveCount++;
        waveActive = true;
    }


}
