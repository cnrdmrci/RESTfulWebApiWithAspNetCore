using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiExample.Model;

namespace WebApiExample.Services
{
    public interface IOgretmenVeOgrenciServis
    {
        string NotGir(OgretmenVeOgrenciBilgi veri);
        Dictionary<int, OgretmenVeOgrenciBilgi> NotGoster();
        OgretmenVeOgrenciBilgi SeciliNotGoster(int id);
        int NotSil(int id);
        string SubeninTumunuSil(string v);
        string BilgiGuncelle(OgretmenVeOgrenciBilgi veri);
    }
}
