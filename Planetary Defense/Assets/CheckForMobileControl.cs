using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForMobileControl : MonoBehaviour
{

    // Start is called before the first frame update
    private void Start()
    {
        //Destroy this object if mobile controls are not enabled
        if (GameManager.Instance.currentControlScheme != 3)
        {
            Destroy(this.gameObject);
        }
    }
}
