using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiExample.Model;
using WebApiExample.Services;

namespace WebApiExample.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IOgretmenVeOgrenciServis _services;
        public ValuesController(IOgretmenVeOgrenciServis services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("NotEkle")]
        public ActionResult<string> NotEkle(OgretmenVeOgrenciBilgi veri)
        {
            return Ok(_services.NotGir(veri));
            
        }

        [HttpGet]
        [Route("NotGoster")]
        public ActionResult<Dictionary<int, OgretmenVeOgrenciBilgi>> NotGoster()
        {
            var notlar = _services.NotGoster();

            if (notlar.Count == 0)
            {
                return NotFound();
            }

            return notlar;
        }

        [HttpGet]
        [Route("NotGoster/{id}")]
        public ActionResult<OgretmenVeOgrenciBilgi> SeciliNotGoster(int id)
        {
            var notlar = _services.SeciliNotGoster(id);
            if (notlar == null)
            {
                return NotFound();
            }

            return notlar;
        }

        [HttpDelete]
        [Route("NotSil/{id}")]
        public ActionResult<string> NotSil(int id)
        {
            var sonuc = _services.NotSil(id);
            if (sonuc == 1)
                return Ok(id + " Numaralı kayıt silindi.");
            else
                return BadRequest(id + " Numaralı kayıt bulunamadı.");
        }

        [HttpDelete]
        [Route("SubeninTumunuSil/{sube}")]
        public ActionResult<string> SubeninTumunuSil(string sube)
        {
            try
            {
                return Ok(_services.SubeninTumunuSil(sube));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("BilgiGuncelle")]
        public ActionResult<string> BilgiGuncelle(OgretmenVeOgrenciBilgi veri)
        {
            return Ok(_services.BilgiGuncelle(veri));
        }

    }
}
