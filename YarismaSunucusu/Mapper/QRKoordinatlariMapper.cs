using YarismaSunucusu.DTOs;
using YarismaSunucusu.Model;

namespace YarismaSunucusu.Mapper
{
    public static class QRKoordinatlariMapper
    {
        public static QRKoordinatlariDTO toQRKoordinatlariDTO(this QRKoordinatlari QRKoordinatlari)
        {
            return new QRKoordinatlariDTO{
                qrEnlem = QRKoordinatlari.qrEnlem,
                qrBoylam = QRKoordinatlari.qrBoylam
            };
        }
    }
}