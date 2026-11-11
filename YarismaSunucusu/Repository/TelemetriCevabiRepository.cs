using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YarismaSunucusu.DBContext;
using YarismaSunucusu.DTOs;
using YarismaSunucusu.Mapper;
using YarismaSunucusu.Model;

namespace YarismaSunucusu.Repository
{
    public class TelemetriCevabiRepository
    {
        private readonly YarismaSunucusuDBContext _context;
        private readonly SunucuSaatiRepository _sunucuSaatiRepository;

        public TelemetriCevabiRepository(YarismaSunucusuDBContext context)
        {
            _context = context;
            _sunucuSaatiRepository = new SunucuSaatiRepository(_context);
        }

        public async Task<TelemetriCevabiDTO> GetTelemetriCevabiDTOAsync()
        {
            var sunucuSaatiDTO = await _sunucuSaatiRepository.GetSunucuSaatiAsync();
            var telemetriCevabi = await _context.TelemetriCevabis
            .Include(tc => tc.sunucusaati)
            .Include(tc => tc.konumBilgileri)
            .FirstOrDefaultAsync(tc => tc.Id == 1);
            var telemetriCevabiDTO = telemetriCevabi?.toTelemetriCevabiDTO();

            if (telemetriCevabiDTO == null)
            {
                return new TelemetriCevabiDTO{
                    sunucusaati = sunucuSaatiDTO?.Value ?? new SunucuSaatiDTO{
                        gun = DateTime.Now.Day,
                        saat = DateTime.Now.Hour,
                        dakika = DateTime.Now.Minute,
                        saniye = DateTime.Now.Second,
                        milisaniye = DateTime.Now.Millisecond
                    },
                    konumBilgileri = new List<KonumBilgisiDTO>()
                };
            }

            return telemetriCevabiDTO;
        }

        public async Task<TelemetriCevabi> GetTelemetriCevabiAsync()
        {
            var sunucuSaatiDTO = await _sunucuSaatiRepository.GetSunucuSaatiAsync();
            var telemetriCevabi = await _context.TelemetriCevabis
            .Include(tc => tc.sunucusaati)
            .Include(tc => tc.konumBilgileri)
            .FirstOrDefaultAsync(tc => tc.Id == 1);

            if (telemetriCevabi == null)
            {
                return new TelemetriCevabi{
                    sunucusaati = sunucuSaatiDTO?.Value?.toSunucuSaati() ?? new SunucuSaati{
                        gun = DateTime.Now.Day,
                        saat = DateTime.Now.Hour,
                        dakika = DateTime.Now.Minute,
                        saniye = DateTime.Now.Second,
                        milisaniye = DateTime.Now.Millisecond
                    },
                    konumBilgileri = new List<KonumBilgisi>()
                };
            }

            return telemetriCevabi;
        }

        public async Task SendUpdatedTelemetriCevabiAsync(TelemetriPaketi updatedTelemetriPaketi)
        {
            var telemetriCevabi = await GetTelemetriCevabiAsync();
            var zamanFarki = CalculateSaatFarki(updatedTelemetriPaketi);

            var telemetriKonumBilgisi = telemetriCevabi.konumBilgileri.Find(kb => kb.takim_numarasi == updatedTelemetriPaketi.takim_numarasi);

            if (telemetriKonumBilgisi is not null)
            {
                telemetriKonumBilgisi.iha_enlem = updatedTelemetriPaketi.iha_enlem;
                telemetriKonumBilgisi.iha_boylam = updatedTelemetriPaketi.iha_boylam;
                telemetriKonumBilgisi.iha_irtifa = updatedTelemetriPaketi.iha_irtifa;
                telemetriKonumBilgisi.iha_dikilme = updatedTelemetriPaketi.iha_dikilme;
                telemetriKonumBilgisi.iha_yonelme = updatedTelemetriPaketi.iha_yonelme;
                telemetriKonumBilgisi.iha_yatis = updatedTelemetriPaketi.iha_yatis;
                telemetriKonumBilgisi.iha_hizi = updatedTelemetriPaketi.iha_hiz;
                telemetriKonumBilgisi.zaman_farki = zamanFarki;
                await _context.SaveChangesAsync();
            }
            else
            {
                AddTelemetriAsync(updatedTelemetriPaketi);
            }
            
        }

        public async void AddTelemetriAsync(TelemetriPaketi newTelemetriPaketi)
        {
            var telemetriCevabi = await GetTelemetriCevabiAsync();
            var zamanFarki = CalculateSaatFarki(newTelemetriPaketi);

            telemetriCevabi.konumBilgileri.Add(new KonumBilgisi{
                takim_numarasi = newTelemetriPaketi.takim_numarasi,
                iha_enlem = newTelemetriPaketi.iha_enlem,
                iha_boylam = newTelemetriPaketi.iha_boylam,
                iha_irtifa = newTelemetriPaketi.iha_irtifa,
                iha_dikilme = newTelemetriPaketi.iha_dikilme,
                iha_hizi = newTelemetriPaketi.iha_hiz,
                zaman_farki = zamanFarki
            });    
            _context.SaveChanges();
        }
        
        private int CalculateSaatFarki(TelemetriPaketi telemetriPaketi)
        {
            var saatFarki = 
            ((DateTime.Now.Hour - telemetriPaketi.gps_saati.saat) * 3600000) + 
            ((DateTime.Now.Minute - telemetriPaketi.gps_saati.dakika) * 60000) +
            ((DateTime.Now.Second - telemetriPaketi.gps_saati.saniye) * 1000) +
            ((DateTime.Now.Millisecond - telemetriPaketi.gps_saati.milisaniye) * 1);

            return saatFarki;
        }
    }
}