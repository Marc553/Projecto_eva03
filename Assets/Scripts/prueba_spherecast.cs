using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba_spherecast : MonoBehaviour
{
    public List<GameObject> golpea = new List<GameObject>();

    public float speed = 20f;
    
    public float radio;
    public float distanciaMax;
    public LayerMask capa;

    private Vector3 origen;
    private Vector3 direccion;

    private float distanciaDeGolpeo;
    

    void Start()
    {
       
    }

    void Update()
    {
        float verticalInputmov = Input.GetAxis("Verticalmov");
          float horizontalInputmov = Input.GetAxis("Horizontalmov"); 
            
        transform.Translate(Vector3.forward * speed * verticalInputmov * Time.deltaTime);
            transform.Translate(Vector3.right * speed * horizontalInputmov * Time.deltaTime);
        {
            origen = transform.position;
            direccion = transform.forward;
            /*RaycastHit hit;
            if (Physics.SphereCast(origen, radio, direccion, out hit, distanciaMax, capa, QueryTriggerInteraction.UseGlobal))
            {
                golpea = hit.transform.gameObject;
                distanciaDeGolpeo = hit.distance;
            }
            else
            {
                distanciaDeGolpeo = distanciaMax;
                golpea = null;
            }*/
            distanciaDeGolpeo = distanciaMax;

            golpea.Clear();

            RaycastHit[] hits = Physics.SphereCastAll(origen, radio, direccion, distanciaMax, capa, QueryTriggerInteraction.UseGlobal);
            foreach(RaycastHit hit in hits)
            {
                golpea.Add(hit.transform.gameObject);
                distanciaDeGolpeo = hit.distance;
            }
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origen, origen + direccion * distanciaDeGolpeo);
        Gizmos.DrawSphere(origen + direccion * distanciaDeGolpeo, radio);
    }


}
