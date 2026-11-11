namespace YarismaSunucusu.Model
{
    public class TelemetriPaketiDTO
    {
        public int takim_numarasi { get; set; }
        public double iha_enlem { get; set; }
        public double iha_boylam { get; set; }
        public int iha_irtifa { get; set; }
        public int iha_dikilme { get; set; }
        public int iha_yonelme { get; set; }
        public int iha_yatis { get; set; }
        public int iha_hiz { get; set; }
        public int iha_batarya { get; set; }
        public int iha_otonom { get; set; }
        public int iha_kilitlenme { get; set; }
        public int hedef_merkez_X { get; set; }
        public int hedef_merkez_Y { get; set; }
        public int hedef_genislik { get; set; }
        public int hedef_yukseklik { get; set; }
        public required SaatDTO gps_saati { get; set; }
    }
}