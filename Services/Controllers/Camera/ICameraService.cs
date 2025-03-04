using Data.Models;

namespace Services
{
    public interface ICameraService
    {
        Camera ActivateCamera(int id);
        Camera AddCamera(Camera camera);
        Camera DeleteCamera(int id);
        List<Camera> GetAllCamera();
        Camera GetCameraById(int id);
        Camera UpdateCamera(CameraVM camera);
    }
}