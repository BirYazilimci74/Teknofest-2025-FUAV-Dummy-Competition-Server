using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using YarismaSunucusu.DBContext;
using YarismaSunucusu.Mapper;
using YarismaSunucusu.Model;

namespace YarismaSunucusu.Repository
{
    public class TelemetriPaketiRepository
    {
        private readonly YarismaSunucusuDBContext _context;
        private readonly TelemetriCevabiRepository _telemetriCevabiRepository;

        public TelemetriPaketiRepository(YarismaSunucusuDBContext context)
        {
            _context = context;
            _telemetriCevabiRepository = new TelemetriCevabiRepository(_context);
        }
        
        public async Task<List<TelemetriPaketiDTO>> GetTelemetriPaketiAsync()
        {
            var telemetriPaketi = await _context.TelemetriPaketis
            .Include(tp => tp.gps_saati)
            .ToListAsync();
            var TelemetriPaketiDTO = telemetriPaketi
            .Select(tp => tp.toTelemetriPaketiDTO())
            .ToList();

            return TelemetriPaketiDTO;
        }

        public void AddTelemetriPaketiAsync(TelemetriPaketi telemetriPaketi)
        {
            _context.TelemetriPaketis.Add(telemetriPaketi);
            _context.SaveChanges();
            
        }

        public async Task SendTelemetriPaketiAsync(TelemetriPaketi newTelemetriPaketi)
        {
            var telemetriPaketiToUpdate = await _context.TelemetriPaketis
            .Include(tp => tp.gps_saati)
            .FirstOrDefaultAsync(tp => tp.takim_numarasi == newTelemetriPaketi.takim_numarasi);

            if (telemetriPaketiToUpdate is null)
            {
                AddTelemetriPaketiAsync(newTelemetriPaketi);
                _telemetriCevabiRepository.AddTelemetriAsync(newTelemetriPaketi);
                return;
            }

            telemetriPaketiToUpdate.iha_enlem = newTelemetriPaketi.iha_enlem;
            telemetriPaketiToUpdate.iha_boylam = newTelemetriPaketi.iha_boylam;
            telemetriPaketiToUpdate.iha_irtifa = newTelemetriPaketi.iha_irtifa;
            telemetriPaketiToUpdate.iha_dikilme = newTelemetriPaketi.iha_dikilme;
            telemetriPaketiToUpdate.iha_yonelme = newTelemetriPaketi.iha_yonelme;
            telemetriPaketiToUpdate.iha_yatis = newTelemetriPaketi.iha_yatis;
            telemetriPaketiToUpdate.iha_hiz = newTelemetriPaketi.iha_hiz;
            telemetriPaketiToUpdate.iha_batarya = newTelemetriPaketi.iha_batarya;
            telemetriPaketiToUpdate.iha_otonom = newTelemetriPaketi.iha_otonom;
            telemetriPaketiToUpdate.iha_kilitlenme = newTelemetriPaketi.iha_kilitlenme;
            telemetriPaketiToUpdate.hedef_merkez_X = newTelemetriPaketi.hedef_merkez_X;
            telemetriPaketiToUpdate.hedef_merkez_Y = newTelemetriPaketi.hedef_merkez_Y;
            telemetriPaketiToUpdate.hedef_genislik = newTelemetriPaketi.hedef_genislik;
            telemetriPaketiToUpdate.hedef_yukseklik = newTelemetriPaketi.hedef_yukseklik;
            telemetriPaketiToUpdate.gps_saati = newTelemetriPaketi.gps_saati;

            await _context.SaveChangesAsync();
            await _telemetriCevabiRepository.SendUpdatedTelemetriCevabiAsync(telemetriPaketiToUpdate);
        }
    }
}