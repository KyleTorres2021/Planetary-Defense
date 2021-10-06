using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{

    private GameObject selectedGameObject;
    

    private void Awake()
    {
        //// 
        //selectedGameObject = transform.Find("Selected").gameObject;
        //SetSelectedVisible(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Allows us to control of select highlight is active or not
    /// </summary>
    /// <param name="visible"></param>
    public void SetSelectedVisible(bool visible)
    {
        selectedGameObject.SetActive(visible);
    }

    //public void MoveTo(Vector3 targetPosition)
    //{
        
    //}
}
