using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    public string textValue;
    public Text textElement;

    public void ShowHP(int HP) 
    {
        textElement.text = "Enemy's current health: " + HP;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

}
