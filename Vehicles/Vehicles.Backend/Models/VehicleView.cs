using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vehicles.Common.Models;

namespace Vehicles.Backend.Models
{
    public class VehicleView : Vehicle
    {
        public HttpPostedFileBase ImageFile { get; set; }
    }
}