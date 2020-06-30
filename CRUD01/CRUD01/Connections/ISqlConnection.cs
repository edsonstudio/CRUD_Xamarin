using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CRUD01.Connections
{
    public interface ISqlConnection
    {
        SQLiteAsyncConnection GetConnection();
    }
}