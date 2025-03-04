using Data.Models;

namespace Services
{
    public class CameraService : ICameraService
    {
        private readonly endel_weighbridgeContext _context;
        public CameraService(endel_weighbridgeContext context)
        {
            _context = context;
        }
        public List<Camera> GetAllCamera()
        {
            return _context.Cameras.ToList();
        }
        public Camera GetCameraById(int id)
        {
            return _context.Cameras.Where(x => x.CameraId == id).FirstOrDefault();
        }
        public Camera AddCamera(Camera camera)
        {
            var cam = _context.Cameras.Where(p => p.CameraName == camera.CameraName).FirstOrDefault();
            if (cam != null)
                return null;
            else
            {
                camera.Active = 1;
                camera.CreatedTime = DateTime.Now;
                _context.Cameras.Add(camera);
                _context.SaveChanges();
                return camera;
            }
        }
        public Camera DeleteCamera(int id)
        {
            var cameraData = _context.Cameras.Where(x => x.CameraId == id).FirstOrDefault();
            if (cameraData != null)
            {
                _context.Cameras.Remove(cameraData);
                _context.SaveChanges();
            }
            return cameraData;
        }
        public Camera UpdateCamera(CameraVM camera)
        {
            var cameraData = _context.Cameras.Where(x => x.CameraId == camera.CameraId).FirstOrDefault();
            if (cameraData != null)
            {
                cameraData.CameraName = camera.CameraName;
                cameraData.WeightBridgeId = camera.WeightBridgeId;
                cameraData.CameraType = camera.CameraType;
                cameraData.Ipaddress = camera.Ipaddress;
                cameraData.Port = camera.Port;
                cameraData.UserName = camera.UserName;
                cameraData.CameraPassword = camera.CameraPassword;
                cameraData.Active = camera.Active;
                cameraData.UpdateTime = DateTime.Now;
                _context.SaveChanges();
            }
            return cameraData;
        }
        public Camera ActivateCamera(int id)
        {
            var cameraData = _context.Cameras.Where(x => x.CameraId == id).FirstOrDefault();
            cameraData.UpdateTime = DateTime.Now;
            if (cameraData != null)
            {
                if (cameraData.Active == 1)
                    cameraData.Active = 0;
                else
                {
                    cameraData.Active = 0;
                }
                _context.SaveChanges();
            }
            return cameraData;
        }

    }
}
