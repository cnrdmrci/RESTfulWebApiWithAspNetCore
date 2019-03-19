using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiExample.Model
{
    public class OgretmenVeOgrenciBilgi
    {
        public int Id { get; set; }

        OgretmenVeOgrenciBilgi()
        {

        }
        OgretmenVeOgrenciBilgi(string ogretmenKullaniciAdi,string sifre,string ogrenciNo,string ogrenciSinif,string ogrenciSube,NotBilgisi[] dersNotlari)
        {
            OgretmenKullaniciAdi = ogretmenKullaniciAdi;
            Sifre = sifre;
            OgrenciNo = ogrenciNo;
            OgrenciSinif = ogrenciSinif;
            OgrenciSube = ogrenciSinif;
            DersNotlari = dersNotlari;
        }
        public string OgretmenKullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string OgrenciNo { get; set; }
        public string OgrenciSinif { get; set; }
        public string OgrenciSube { get; set; }
        public NotBilgisi[] DersNotlari { get; set; }
    }
}
