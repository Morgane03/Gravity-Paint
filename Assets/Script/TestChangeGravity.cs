using UnityEngine;

public class TestChangeGravity : MonoBehaviour
{
    private Rigidbody2D _rb;
    private int _speed = 5;

    void Start()
    {
        this._rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.E))
        {
            if(this._rb.gravityScale == 1)
            {
                this._rb.gravityScale *= -1 * _speed * Time.deltaTime;
            }
            else
            {
                this._rb.gravityScale = 1;
            }   
        }
    }
}
