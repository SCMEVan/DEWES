using DEWESDb;
using DEWESDb.Table;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers
{
    [Route("api/[controller]")]
    public class DataSourceCrudController : CrudController<DataSource>
    {
        public DataSourceCrudController(DbScheduleContext db) : base(db)
        {
        }
        
      
        
        
    }
}