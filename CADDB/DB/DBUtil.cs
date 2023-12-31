﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

using System.Data;
using System.Data.SqlClient;

namespace CADDB.DB
{
    public static class DBUtil
    {
        //Start Point
        //1-Method Signature by [CommandMethod()] 
        [CommandMethod("DBRun")]
        public static void DBRun()
        {
            Main main = new Main();
            main.ShowDialog();
        }


        public static SqlConnection GetConnection()
        {
            string connStr = Settings1.Default.Connstr;
            SqlConnection conn = new SqlConnection(connStr);
            return conn;
        }
    }
}
