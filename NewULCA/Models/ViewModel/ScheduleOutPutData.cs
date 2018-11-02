using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NewULCA.Models;

namespace NewULCA.Models.ViewModel
{
    public class ScheduleIndexDataViewModel
    {
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Channels> Channels { get; set; }
        public virtual DbSet<Schedules> Schedules { get; set; }
        public virtual DbSet<Shows> Shows { get; set; }
    }
}