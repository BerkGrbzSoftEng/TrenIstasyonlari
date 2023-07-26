using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TrenIstasyonlar.DataAccess.Entities;
using TrenIstasyonlari.Business.Services;
using TrenIstasyonlari.Models;

namespace TrenIstasyonlari.Controllers
{
    public class TrainSchedules : Controller
    {
        private IIstasyonService _istasyonService;
        private ITrenSeferleriService _trenSeferleriService;

        public TrainSchedules(IIstasyonService istasyonService, ITrenSeferleriService trenSeferleriService)
        {
            _istasyonService = istasyonService;
            _trenSeferleriService = trenSeferleriService;
        }


        public IActionResult List()
        {
            Doldur();
            var list = new List<TrenSeferleriDto>();
            var result = _trenSeferleriService.GetSeferList();
            foreach (var item in result.Result)
            {
                list.Add(new TrenSeferleriDto()
                {
                    KalkisIstasyonAdi = _istasyonService.Get(x => x.IstasyonId == item.KalkisIstasyonId).Result.IstasyonAdi,
                    VarisIstasyonAdi = _istasyonService.Get(x => x.IstasyonId == item.VarisIstasyonId).Result.IstasyonAdi,
                    KalkisSaati = (DateTime)item.KalkisSaati,
                    VarisSaati = (DateTime)item.VarisSaati,
                    SeferId = item.SeferId
                });
            }
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TrenSeferleriDto sefer)
        {
            var result = _trenSeferleriService.Add(new Sefer()
            {

                KalkisIstasyonId = sefer.KalkisIstasyonId,
                VarisIstasyonId = sefer.VarisIstasyonId,
                KalkisSaati = sefer.KalkisSaati,
                VarisSaati = sefer.VarisSaati
            });
            if (result.IsCompleted)
                return Ok(result);

            return BadRequest();
        }

        void Doldur()
        {
            var istasyonlar = _istasyonService.GetAllAsync().Result;
            List<SelectListItem> stations = new() { };
            foreach (var item in istasyonlar)
            {
                stations.Add(new SelectListItem()
                {
                    Value = item.IstasyonId.ToString(),
                    Text = item.IstasyonAdi
                });
            }
            ViewBag.Stations = stations;
        }

        public IActionResult Edit(TrenSeferleriDto sefer)
        {
            var update = _trenSeferleriService.Update(new Sefer()
            {
                KalkisIstasyonId = sefer.KalkisIstasyonId,
                SeferId = sefer.SeferId,
                VarisIstasyonId = sefer.VarisIstasyonId,
                VarisSaati = sefer.VarisSaati,
                KalkisSaati = sefer.KalkisSaati
            });
            return View(update);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var schedules = _trenSeferleriService.Get(x => x.SeferId == id);
            var delete = _trenSeferleriService.Delete(schedules);
            if (delete.Result)
            {
                return Ok(delete.Result);
            }

            return BadRequest(delete.Result);
        }
    }
}
