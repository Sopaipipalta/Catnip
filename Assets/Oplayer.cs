using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oplayer : MonoBehaviour
{
	Rigidbody2D player;
	public float maxVelocidad;
	Animator playerAnim;
	
	bool puedeMover=true;
	
	//saltar
	
	bool enSuelo=false;
	float chequearRadioSuelo=0.2f;
	public LayerMask capaSuelo;
	public Transform chequearSuelo;
	public float poderSalto;
	
	//voltear personaje
	SpriteRenderer playerRender;
	bool voltearPlayer=true;
	
    // Start is called before the first frame update
    void Start()
    {
	player=GetComponent<Rigidbody2D>();
	playerRender= GetComponent<SpriteRenderer>();
	playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		if (enSuelo && Input.GetAxis("Jump")>0)
		{
			playerAnim.SetBool ("EnSuelo",false);
			player.velocity=new Vector2(player.velocity.x,0f);
			player.AddForce(new Vector2(0,poderSalto),ForceMode2D.Impulse);
			enSuelo=false;
		}

		enSuelo=Physics2D.OverlapCircle(chequearSuelo.position,chequearRadioSuelo,capaSuelo);
		playerAnim.SetBool("EnSuelo",enSuelo);
		
        float mover= Input.GetAxis("Horizontal");
		
		if (puedeMover)
		{
					
		if (mover>0 && !voltearPlayer)
		{
			Voltear();

		}
		else if (mover<0 && voltearPlayer)
		{
			Voltear();

		}
				player.velocity=new Vector2 (mover * maxVelocidad,player.velocity.y);
			// Correr
		playerAnim.SetFloat("VelMovimiento",Mathf.Abs(mover));
			
		}
		else
		{
		player.velocity=new Vector2 (0,player.velocity.y);
		playerAnim.SetFloat("VelMovimiento",0);
		}

    }

	void Voltear()
	{
		voltearPlayer=!voltearPlayer;
		playerRender.flipX=!playerRender.flipX;
	}

	public void togglePuedeMover()
	{
	puedeMover=!puedeMover;
	}
}
