using Data.Models;

namespace Services
{
    public interface ICameraImageService
    {
        Cameraimage AddCamera(Cameraimage camera);
        Cameraimage DeleteCamera(int id);
        List<Cameraimage> GetAllCamera();
        Cameraimage GetCameraById(int id);
    }
}