using Microsoft.AspNetCore.Mvc;
using TrenIstasyonlar.DataAccess.Abstract;
using TrenIstasyonlar.DataAccess.Entities;
using TrenIstasyonlari.Business.Services;
using TrenIstasyonlari.Models;

namespace TrenIstasyonlari.Controllers
{
    public class TrainController : Controller
    {
        private IIstasyonService _istasyonService;
        private ITrenSeferleriService _trenSeferleriService;
        public TrainController(IIstasyonService istasyonService, ITrenSeferleriService trenSeferleriService)
        {
            _istasyonService = istasyonService;
            _trenSeferleriService = trenSeferleriService;
        }

        public IActionResult List()
        {
            var data = _istasyonService.GetAllAsync();
            var list=new List<IstasyonDto>();
            foreach (var item in data.Result)
            {
                list.Add(new IstasyonDto()
                {
                    IstasyonAdres = item.IstasyonAdres,
                    IstasyonAdi = item.IstasyonAdi,
                    IstasyonKonum = item.IstasyonKonum,
                    IstasyonID = item.IstasyonId
                });
            }
            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> AddTrain(IstasyonDto istasyon)
        {
            var data = _istasyonService.AddAsync(new Istasyon()
            {
                IstasyonAdi = istasyon.IstasyonAdi,
                IstasyonAdres = istasyon.IstasyonAdres,
                IstasyonKonum = istasyon.IstasyonKonum
            });
            if (data.Result!=null)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(IstasyonDto istasyon)
        {
            var update = _istasyonService.Update(new Istasyon()
            {
                IstasyonAdi = istasyon.IstasyonAdi,
                IstasyonAdres = istasyon.IstasyonAdres,
                IstasyonId = istasyon.IstasyonID,
                IstasyonKonum = istasyon.IstasyonKonum
            });
            if (istasyon!=null)
            {
                return Ok(istasyon);
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var station = _istasyonService.Get(x => x.IstasyonId == id);
            var schedules = _trenSeferleriService.Get(x => x.KalkisIstasyonId == station.Result.IstasyonId);

            var deleteSchudules = _trenSeferleriService.Delete(schedules);
            var deleteStation = _istasyonService.Delete(station.Result);
            if (deleteSchudules.Result || deleteStation.Result)
            {
                return Ok(deleteStation.Result);
            }

            return BadRequest(deleteStation.Result);
        }
    }
}
