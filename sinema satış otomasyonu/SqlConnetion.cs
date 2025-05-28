using System;
using System.Data.SqlClient;

namespace sinema_satış_otomasyonu
{
    internal class SqlConnetion
    {
        private string v;

        public SqlConnetion(string v)
        {
            this.v = v;
        }

        public SqlConnetion(string v, SqlConnetion baglanti)
        {
            this.v = v;
        }

        internal void Close()
        {
            throw new NotImplementedException();
        }

        internal SqlDataReader ExecuteReader()
        {
            throw new NotImplementedException();
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }
    }
}