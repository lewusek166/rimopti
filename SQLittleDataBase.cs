﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RimOptiList
{
    class SQLittleDataBase
    {
        public SQLiteConnection sql_con;
        public SQLiteCommand sql_cmd;
        public SQLiteDataAdapter DB;
        public DataSet DS = new DataSet();
        public DataTable DT = new DataTable();

       public SQLittleDataBase()
        {

            SetConnection();
        }

        public void SetConnection()
        {
            sql_con = new SQLiteConnection
                ("Data Source=\\Data\\testDB.db;Version=3;New=False;Compress=True;");
        }

        public void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }
        public void LoadData()
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select id, desc from mains";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            //Grid.DataSource = DT;
            sql_con.Close();
        }
        public void Add()
        {
            string txtSQLQuery = "insert into  mains (desc) values (6666666)";
            ExecuteQuery(txtSQLQuery);
        }

    }
}


