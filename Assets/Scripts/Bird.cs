using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Rigidbody2D _myBody;
    private SpriteRenderer _sr;
    private LineRenderer _lr;

    private Vector2 _startPosition;

    [SerializeField]
    private float _launchForce = 700f, _maxDragDistance = 5f;

    //Awake is called only once during the lifetime of the script instance.
    private void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _lr = GetComponent<LineRenderer>();
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
        _lr.enabled = true;
    }
    private void OnMouseUp()
    {
        Vector2 currentPosition = _myBody.position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();

        _myBody.isKinematic = false;
        _myBody.AddForce(direction * _launchForce); 

        _sr.color = Color.white;
        _lr.enabled = false;
    }
    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 desiredPosition = mousePosition;

        float distance = Vector2.Distance(desiredPosition, _startPosition);

        // restricting bird to an arc of _maxDragDist
        if (distance > _maxDragDistance)
        {
            Vector2 direction = desiredPosition - _startPosition;
            direction.Normalize();
            desiredPosition = _startPosition + (direction * _maxDragDistance);
        }

        //restricting drag of bird to left only
        /*if (desiredPosition.x > _startPosition.x)
        {
            desiredPosition.x = _startPosition.x;
        }*/

        _myBody.position = desiredPosition;
        
        _lr.SetPosition(1, _startPosition);
        _lr.SetPosition(0, _myBody.position);
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
