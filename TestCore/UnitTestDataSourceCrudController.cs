using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core;
using Core.Controllers;
using Core.LibraryHelper;
using DEWESDb;
using DEWESDb.Table;
using Interfaces.Enums;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCore
{
    
    [TestClass]
    public class UnitTestDataSourceCrudController : UnitTestCrudController<DataSource>
    {
        public UnitTestDataSourceCrudController() : base(new DataSourceCrudController(new DbScheduleContext()))
        {
        }

        protected override DataSource CreateObject()
        {
            return new DataSource()
            {
                DataSourceId = Guid.NewGuid(),
            };
        }
    }
}