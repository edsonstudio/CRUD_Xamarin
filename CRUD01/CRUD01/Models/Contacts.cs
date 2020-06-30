using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD01.Models
{
    public class Contacts
    {
        private int id;
        [PrimaryKey]
        [AutoIncrement]

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
    }
}
