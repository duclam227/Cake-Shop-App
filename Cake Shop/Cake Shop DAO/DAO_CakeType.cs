﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Cake_Shop_DAO
{
    public class DAO_CakeType : DBConnect
    {
        private static DAO_CakeType _instance = null;

        public static DAO_CakeType Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DAO_CakeType();
                }

                return _instance;
            }
        }

        public DataTable GetAllTypes()
        {
            DataTable result = new DataTable();

            string query = "select * from CakeType";

            SqlDataAdapter adapter = new SqlDataAdapter(query, _conn);
            adapter.Fill(result);

            return result;
        }

        public DataTable GetStatistic()
        {
            DataTable result = new DataTable();

            string query = "select CT.CakeTypeName, COALESCE(sum(OD.CakeAmount), 0) as Amount " +
                           "from CakeType CT left join Cake C on C.CakeTypeID = CT.CakeTypeID " +
                           "left join  OrderDetail OD on OD.CakeID = C.CakeID group by CT.CakeTypeName";

            SqlDataAdapter adapter = new SqlDataAdapter(query, _conn);
            adapter.Fill(result);

            return result;
        }
    }
}
