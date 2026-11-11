using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YarismaSunucusu.DBContext;
using YarismaSunucusu.Model;
using YarismaSunucusu.DTOs;
using YarismaSunucusu.Mapper;

namespace YarismaSunucusu.Repository
{
    public class QRKoordinatlariRepository
    {
        private readonly YarismaSunucusuDBContext _context;

        public QRKoordinatlariRepository(YarismaSunucusuDBContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<QRKoordinatlariDTO>> GetQrKoordinatiAsync()
        {
            var qr = await _context.QRKoordinatlaris.FirstOrDefaultAsync();
            var qrDTO = qr?.toQRKoordinatlariDTO();
            
            if (qrDTO == null)
            {
                qrDTO = new QRKoordinatlariDTO{
                    qrEnlem = 41.51238882,
                    qrBoylam = 36.11935778
                };
            }
            return qrDTO;
        }

        public async Task PostQRCoordinateAsync()
        {
            await _context.QRKoordinatlaris.AddAsync(new QRKoordinatlari{
                qrEnlem = 41.51238882,
                qrBoylam = 36.11935778
            });

            await _context.SaveChangesAsync();
        }
    }
}