using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracOtomasyon
{
    public class Arac
    {
        public ObjectId _id, sellerId;
        public string marka, model, yil, plaka, renk, bilgi;
        public float alisTutari, satisTutari;
        public bool satildi;
        public bool ikinciEl;
        public byte[] fotograf;

    }
}
