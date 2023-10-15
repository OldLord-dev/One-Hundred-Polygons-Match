using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraRaycast : MonoBehaviour
{

    RaycastHit rayHit;
    PolygonCreator selected = null;
    void Update()
    {

        // now we check if the mouse left button was pressed
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // we cast a ray from camera to tho our mouse, to see if our mouse is actually over any movable object
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit))
            {
                if (rayHit.collider.CompareTag("Polygon"))
                {             
                    if(rayHit.collider.TryGetComponent<PolygonCreator>(out PolygonCreator component))
                    {
                        if(selected == null)
                        {
                            selected = component;
                            component.meshRenderer.material.color = Color.black;
                        } else if(selected.numVertices == component.numVertices && selected.polygonType == component.polygonType)
                        {
                            selected.meshRenderer.material.color = Color.white  ;
                            component.CreatePolygon(selected.numVertices+1, selected.polygonType);
                            component.ParticlePlay();
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