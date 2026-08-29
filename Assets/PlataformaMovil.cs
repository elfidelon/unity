using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlataformaMovil : MonoBehaviour
{
    public Vector3 puntoB = new Vector3(3f, 0f, 0f);
    public float velocidad = 2f;

    private Rigidbody _rb;
    private Vector3 _puntoA;
    private Vector3 _destino;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.isKinematic = true;

        _puntoA = transform.position;
        _destino = _puntoA + puntoB;
    }

    void FixedUpdate()
    {
        Vector3 nuevaPosicion = Vector3.MoveTowards(_rb.position, _destino, velocidad * Time.fixedDeltaTime);
        _rb.MovePosition(nuevaPosicion);

        if (Vector3.Distance(_rb.position, _destino) < 0.05f)
        {
            _destino = _destino == _puntoA + puntoB ? _puntoA : _puntoA + puntoB;
        }
    }
}
