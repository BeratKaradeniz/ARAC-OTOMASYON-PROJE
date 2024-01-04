using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracOtomasyon
{
    public class Seller
    {
        public ObjectId _id;

        public string ad, soyad;
        public string vkn, adres, telefon;
    }
}
