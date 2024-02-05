namespace KonyvtarBackEnd.Dto
{
    public record FelhasznaloDto(uint Id,string Nev,DateTime Tagsagkezdete,DateTime Tagsagvege,bool Kolcsonozhet,bool Tag_felvehet,string Felhasznaloi_nev);
    public record CreateFelhasznaloDto(uint Id, string Nev, DateTime Tagsagkezdete, DateTime Tagsagvege, bool Kolcsonozhet, bool Tag_felvehet, string Felhasznaloi_nev,string Hash);
    public record ModifyFelhasznaloDto(uint Id, string Nev, DateTime Tagsagkezdete, DateTime Tagsagvege, bool Kolcsonozhet, bool Tag_felvehet, string Felhasznaloi_nev);
    public record ModifyJelszo(string Jelszo);

    public record SzerzoDto(uint Id,string Nev);
    public record CreateOrModifySzerzoDto(uint Id, string Nev);

    public record KiadoDto(uint Id, string Nev);
    public record CreateOrModifyKiadoDto(uint Id, string Nev);

    public record SorozatDto(uint Id, string Nev);
    public record CreateOrModifySorozatDto(uint Id, string Nev);

    public record KolcsonzesTortenetDto(uint Id,int Konyv_Id,int Tag_Id,DateTime Datum);
    public record CreateOrModifyKolcsonzesTortenetDto(uint Id, uint Konyv_Id, uint Tag_Id, DateTime Datum);

    public record KonyvDto(uint Id,int Raktari_Szam,DateTime Beszerzes_Datuma,uint Szerzo_Id,string Cim,int Sorozat_Id,decimal isbn_szam,decimal Szakjelzet,string Cutter_Jelzet,uint Kiado_Id,short Kiadas_Eve,decimal Ar,string Megjegyzes,uint Tag_Id);
    public record CreateOrModifyKonyvDto(uint Id, uint Raktari_Szam, DateTime Beszerzes_Datuma, uint Szerzo_Id, string Cim, uint Sorozat_Id, decimal isbn_szam, decimal Szakjelzet, string Cutter_Jelzet, uint Kiado_Id, short Kiadas_Eve, decimal Ar, string Megjegyzes, uint Tag_Id);

}
