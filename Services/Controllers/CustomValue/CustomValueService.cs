using Data.Models;
using Data.ViewModel;

namespace Services
{
    public class CustomValueService : ICustomValueService
    {
        private readonly endel_weighbridgeContext _context;
        public CustomValueService(endel_weighbridgeContext context)
        {
            _context = context;
        }
        public void AddCustomValue(Customvalue customvalue)
        {
            var custom = _context.Customvalues.Where(p => p.CustomFieldId == customvalue.CustomFieldId).FirstOrDefault();
            if (custom != null)
                return;
            else
            {
                Guid cust = Guid.NewGuid();
                custom.ReceiptTicketId = Convert.ToString(cust);
                customvalue.CreatedTime = DateTime.Now;
                _context.Customvalues.Add(customvalue);
                _context.SaveChanges();
            }
        }
        public List<CustomvalueVM> EditCustomValue(List<CustomvalueVM> custom, string name)
        {
            foreach (var item in custom)
            {
                var customvalue = _context.Customvalues.Where(x => x.CustomValueId == item.CustomValueId).FirstOrDefault();
                if (customvalue != null)
                {
                    customvalue.CustomValue1 = item.CustomValue1;
                    customvalue.UpdatedBy = name;
                    customvalue.UpdatedTime = DateTime.Now;
                    _context.SaveChanges();
                }
            }
            return custom;
        }
        public List<Customvalue> GetCustomValue()
        {
            return _context.Customvalues.ToList();
        }
        public void DeleteCustomValue(int id)
        {
            var customvalue = _context.Customvalues.Where(x => x.CustomValueId == id).FirstOrDefault();
            if (customvalue != null)
            {
                _context.Customvalues.Remove(customvalue);
                _context.SaveChanges();
            }
        }


    }
}
