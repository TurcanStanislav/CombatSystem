using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    public string textValue;
    public Text textElement;

    public void ShowHP(int HP, string str) 
    {
        textElement.text = str + "'s current health: " + HP;
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
