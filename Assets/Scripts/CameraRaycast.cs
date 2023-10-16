using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;

public class CameraRaycast : MonoBehaviour
{
    [SerializeField] private ParticleSystem polygonParticleSystem;
    [SerializeField] private CinemachineImpulseSource cinemachineImpulseSource;
    private RaycastHit rayHit;
    private PolygonCreator selected = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit))
            {
                if (rayHit.collider.CompareTag("Polygon"))
                {
                    MatchSelectedPolygons();
                }
            }
        }
    }
    private void MatchSelectedPolygons()
    {
        if (rayHit.collider.TryGetComponent(out PolygonCreator component))
        {
            if (selected == null)
            {
                selected = component;
                component.meshRenderer.material.color = Color.black;
            }
            else if (selected.numVertices == component.numVertices && selected.polygonType == component.polygonType
                && selected.gameObject.transform.position != component.gameObject.transform.position)
            {
                selected.meshRenderer.material.color = Color.white;
                component.CreatePolygon(selected.numVertices + 1, selected.polygonType);
                polygonParticleSystem.gameObject.transform.position = component.transform.position;
                polygonParticleSystem.Play();
                selected.gameObject.SetActive(false);
                selected.gameObject.transform.position += Vector3.up * 7.99f;
                selected.CreatePolygon(Random.Range(3, 7), (PolygonType)Random.Range(0, 3));
                selected.gameObject.SetActive(true);
                selected = null;
                GameManager.instance.AddPoint();
            }
            else if(selected.gameObject.transform.position != component.gameObject.transform.position)
            {
                selected.meshRenderer.material.color = Color.white;
                selected = null;
                cinemachineImpulseSource.GenerateImpulse(1f);
            }
        }
    }
}