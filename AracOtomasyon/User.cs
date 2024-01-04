using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracOtomasyon
{
    public class User
    {
        public ObjectId _id;

        public string name;

        public string email;

        public string password;

        public int role;

    }
}
