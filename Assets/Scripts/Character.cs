using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float speed;
    public KeyCode jumpKey=KeyCode.Space;
    public Sprite walkSprite;
    public Sprite idleSprite;
    public float jumpSpeed;

    bool isWalking;
    bool isGrounded;
    bool facingRight;

    RaycastHit2D hit;


    // Update is called once per frame
    void Update()
    {
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        r.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, r.velocity.y);

        if(Input.GetAxis("Horizontal")>0){
            facingRight = true;
        }
        if(Input.GetAxis("Horizontal")<0){
            facingRight = false;
        }
        if(!facingRight){
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else{
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if(r.velocity.magnitude > 0.1f){
            if(!isWalking){
                StartCoroutine(Walk());
            }
        }

        hit = Physics2D.Raycast(new Vector2(transform.position.x,transform.position.y),Vector2.down);
        if(hit.distance<1.9f){
            isGrounded = true;
        }
        else{
            isGrounded = false;
        }

        if(isGrounded){
            if(Input.GetKeyDown(jumpKey)){
                r.velocity = new Vector2(r.velocity.x,jumpSpeed);
            }
        }
        if(!isWalking){
            GetComponent<SpriteRenderer>().sprite = idleSprite;
        }
        if(Input.GetMouseButtonDown(0)){
            Vector3 c = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D mouseHit = Physics2D.Raycast(c, Vector2.zero);
            if(mouseHit.collider.gameObject.GetComponent<TileData>() !=null){
                GetComponent<Inventory>().Add(mouseHit.collider.gameObject.GetComponent<TileData>().tileData,1);
                Destroy(mouseHit.collider.gameObject);
            }
            else if(mouseHit.collider.gameObject!=null && mouseHit.collider.tag != "Player"){
                Destroy(mouseHit.collider.gameObject);
            }
        }
    }

    IEnumerator Walk(){
        isWalking = true;
        GetComponent<SpriteRenderer>().sprite = walkSprite;
        yield return new WaitForSeconds(0.25f);
        isWalking = false;
    }
}
