using System;
using System.Collections.Generic;
using SQLite;

namespace Semana7Velasquez9B
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();//Metodo de conexion

        
    }
}
