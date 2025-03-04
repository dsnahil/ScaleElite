using Data.Models;

namespace Services
{
    public class CameraImageService /*: ICameraImageService*/
    {
        private readonly endel_weighbridgeContext _context;
        public CameraImageService(endel_weighbridgeContext context)
        {
            _context = context;
        }
        public Cameraimage AddCamera(Cameraimage camera)
        {
            var cam=_context.Cameraimages.Where(x => x.CameraId == camera.CameraId).FirstOrDefault();
            if(cam!=null)
            {
                var image = _context.Cameraimages.Add(camera);
                _context.Cameraimages.Add(camera);
                _context.SaveChanges();
                return cam;
            }
            else
                return null;
        }
        /*public Cameraimage DeleteCamera(int id)
        {
            var camera = _context.Cameraimages.FirstOrDefault(x => x.Id == id);
            if (camera != null)
            {
                _context.Cameraimages.Remove(camera);
                _context.SaveChanges();
            }
            return camera;
        }*/
        public List<Cameraimage> GetAllCamera()
        {
            return _context.Cameraimages.ToList();
        }
       /* public Cameraimage GetCameraById(int id)
        {
            return _context.Cameraimages.FirstOrDefault(x => x.Id == id);
        }*/
    }
}
