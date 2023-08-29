using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TmBussines.WebServerOffice.Data;

namespace TmBussines.WebServerOffice.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repository;

        public BaseController(ILogger<HomeController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }


        public JsonResult GetGsmMData()
        {
            var model = _repository.GsmM.AsNoTracking().OrderBy(o => o.DateStamp)
                .Select(s => new
                {
                    s.Imei,
                    s.PartNumber,
                    s.DeviceType
                })
                //.Take(50)
                .ToList();
            return Json(model);
        }

        public JsonResult GetAsduMiniData()
        {
            var model = _repository.AsduTm3Device.AsNoTracking()
                .Where(w => !string.IsNullOrEmpty(w.AsduPartNumber) && w.AsduPartNumber.Contains("MINI"))
                .Join(_repository.AsduTm3Core, o=>o.CoreId, i=>i.SerialNumber, 
                (o,i)=> new
                {
                    dev = o,
                    core = i
                })
                .Select(s=> new
                {
                    s.dev.DateStamp,
                    s.dev.AsduPartNumber,
                    s.core.Mac1char
                })
                .OrderBy(o=>o.DateStamp)
                .ToList();
            return Json(model);
        }

        public JsonResult GetAsduTM3Data()
        {
            var model = _repository.AsduTm3Device.AsNoTracking()
                .Where(w => !string.IsNullOrEmpty(w.AsduPartNumber) && w.AsduPartNumber.Contains("TM3"))
                .Join(_repository.AsduTm3Core, o => o.CoreId, i => i.SerialNumber,
                (o, i) => new
                {
                    dev = o,
                    core = i
                })
                .Select(s => new
                {
                    s.dev.DateStamp,
                    s.dev.AsduPartNumber,
                    s.dev.MkddPartNumber,
                    s.core.Mac1char,
                    s.core.Mac2char
                })
                .OrderBy(o => o.DateStamp)
                .ToList();
            return Json(model);
        }

        public JsonResult GetAsduTM4Data()
        {
            var model = _repository.AsduTm3Device.AsNoTracking()
                .Where(w => !string.IsNullOrEmpty(w.AsduPartNumber) && w.AsduPartNumber.Contains("TM4"))//ASDU TM4 0002
                .Join(_repository.AsduTm3Core, o => o.CoreId, i => i.SerialNumber,
                (o, i) => new
                {
                    dev = o,
                    core = i
                })
                .Select(s => new
                {
                    s.dev.DateStamp,
                    s.dev.AsduPartNumber,
                    s.core.Mac1char,
                    s.core.Mac2char
                })
                .OrderBy(o => o.DateStamp)
                .ToList();
            return Json(model);
        }

        public JsonResult GetAsduTM5Data()
        {
            var model = _repository.AsduTm3Device.AsNoTracking()
                .Where(w => !string.IsNullOrEmpty(w.AsduPartNumber) && (w.AsduPartNumber.Contains("R111-") || w.AsduPartNumber.Contains("TM5")))
                .Join(_repository.AsduTm3Core, o => o.CoreId, i => i.SerialNumber,
                (o, i) => new
                {
                    dev = o,
                    core = i
                })
                .Select(s => new
                {
                    s.dev.DateStamp,
                    s.dev.AsduPartNumber,
                    s.core.Mac1char
                })
                .OrderBy(o => o.DateStamp)
                .ToList();
            return Json(model);
        }

        //public JsonResult GetData(bool _search, string nd, int rows, int page, string sidx, string sord, string searchField, string searchString, string searchOper, string filters,string extraParam1,int extraParam2, int totalPageCount, bool isPaging)
        public JsonResult GetDatas(string sord, int page, int rows, string searchString)
        {
            //#1 Create Instance of DatabaseContext class for Accessing Database.  
            using var db = _repository.Context;
            //#2 Setting Paging  
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            //#3 Linq Query to Get Customer   
            var Results = db.GsmM.AsNoTracking();

            //#4 Get Total Row Count  
            int totalRecords = Results.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);


            //#5 Setting Sorting  
            if (sord.ToUpper() == "DESC")
            {
                Results = Results.OrderByDescending(s => s.Imei);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                Results = Results.OrderBy(s => s.Imei);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            //#6 Setting Search  
            if (!string.IsNullOrEmpty(searchString))
            {
                Results = Results.Where(m => m.Imei == searchString);
            }


            //#7 Sending Json Object to View.  
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = Results.Select(s => new { imei = s.Imei, partNumber = s.PartNumber, deviceType = s.DeviceType }).ToArray()
            };
            return Json(jsonData);
        }
    }
}
