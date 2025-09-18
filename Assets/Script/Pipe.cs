using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] public float speed;
    
    void Start()
    {
        speed = PlayerPrefs.GetFloat("NewPipe", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }
    public void Move()
    {
        transform.Translate(Vector2.left * speed*Time.deltaTime);
    }
    
}
