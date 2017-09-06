using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MySql.Data.Entity;

namespace ccb_web
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MyConfiguration
    {
    }
}