using UnityEngine;

public class Player : MonoBehaviour
{

    public float velocidad_jugador = 1.5f;
    private Rigidbody2D rb2D;

    private float move;

    public float fuerzaSalto = 4;
    private bool enSuelo;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;

    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        rb2D.linearVelocity = new Vector2(move * velocidad_jugador, rb2D.linearVelocity.y);

        if (move != 0)
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);

        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, fuerzaSalto);
        }

        animator.SetFloat("Velocidad", Mathf.Abs(move));
    }

    private void FixedUpdate()
    {
        enSuelo = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }
}
