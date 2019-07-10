<<<<<<< HEAD
﻿using Capstone.Web.Models;
=======
﻿using Microsoft.AspNetCore.Mvc.Rendering;
>>>>>>> d509311d06f478e0da036e79a806e8464f471243
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IParkDao
    {
        IList<Park> GetParks();
        Park GetPark(string parkCode);
<<<<<<< HEAD
        ParkWeather GetParkWeather(string parkCode);

=======
        List<SelectListItem> GetParkSelectList();
>>>>>>> d509311d06f478e0da036e79a806e8464f471243
    }
}
