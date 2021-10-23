using UnityEngine;

public class SetScale : MonoBehaviour
{
    public void Scale(float s, GameObject gameObject)
    {
        gameObject.transform.localScale = new Vector3(s, s, s);
        Debug.Log("Succesful");
    }
}
