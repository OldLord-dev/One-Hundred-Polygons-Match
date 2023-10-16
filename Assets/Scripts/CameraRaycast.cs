using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraRaycast : MonoBehaviour
{
    [SerializeField] private ParticleSystem polygonParticleSystem;
    private RaycastHit rayHit;
    private PolygonCreator selected = null;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit))
            {
                if (rayHit.collider.CompareTag("Polygon"))
                {             
                    if(rayHit.collider.TryGetComponent(out PolygonCreator component))
                    {
                        if(selected == null)
                        {
                            selected = component;
                            component.meshRenderer.material.color = Color.black;
                        } else if(selected.numVertices == component.numVertices && selected.polygonType == component.polygonType 
                            && selected.gameObject.transform.position!=component.gameObject.transform.position)
                        {
                            selected.meshRenderer.material.color = Color.white  ;
                            component.CreatePolygon(selected.numVertices+1, selected.polygonType);
                            polygonParticleSystem.gameObject.transform.position = component.transform.position;
                            polygonParticleSystem.Play();
                            selected.CreatePolygon(Random.Range(3, 7), (PolygonType)Random.Range(0, 3));
                            selected = null;
                            //TO DO 
                        }
                        else
                        {
                            selected.meshRenderer.material.color = Color.white;
                            selected = component;
                            component.meshRenderer.material.color = Color.black;
                        }   
                    }
                }
            }
        }
    }
}