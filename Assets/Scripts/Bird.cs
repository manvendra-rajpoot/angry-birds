using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D _myBody;
    private SpriteRenderer _sr;
    
    private Vector2 _startPosition;

    [SerializeField]
    private float _launchForce = 555;

    //Awake is called only once during the lifetime of the script instance.
    private void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _myBody.isKinematic = true;
        _startPosition = _myBody.position;
    }

    private void OnMouseDown()
    {
        _sr.color = Color.red; 
    }
    private void OnMouseUp()
    {
        Vector2 currentPosition = _myBody.position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();

        _myBody.isKinematic = false;
        _myBody.AddForce(direction * _launchForce); 

        _sr.color = Color.white;
    }
    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z); //changing position of bird to dragged point
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());
    }
    
    private IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        
        _myBody.position = _startPosition;
        _myBody.isKinematic = true;
        _myBody.velocity = Vector2.zero;
    }
  
}
