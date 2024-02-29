using Cinemachine;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;
    private float _cameraSize = 2f;
    private float _cameraZoomSpeed = 1.5f;
    private float _cameraMaxSize = 10f;
    private float _cameraMinSize = 1f;

    void Start()
{
    GameObject vCamObject = GameObject.Find("Camera");
    _virtualCamera = vCamObject.GetComponent<CinemachineVirtualCamera>();
}
    void Update()
    {
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            _cameraSize -= scroll * _cameraZoomSpeed;
            _cameraSize = Mathf.Clamp(_cameraSize, _cameraMinSize, _cameraMaxSize);
            _virtualCamera.m_Lens.OrthographicSize = _cameraSize;
        }
    }
}