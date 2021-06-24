using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace jtcBarcode
{
    public static class Constants
    {
        //  All application wide constants to be defined here
        public const string DBName = "basictemplate.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            //  open in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            //  create if doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            //  enable multi thread access
            SQLite.SQLiteOpenFlags.SharedCache;
    }
}
