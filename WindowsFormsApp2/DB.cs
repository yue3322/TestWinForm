﻿using Dos.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class DB
    {
        public static readonly DbSession MysqlDB = new DbSession("MysqlConn");
    }
}
