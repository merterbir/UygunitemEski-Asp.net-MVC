//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Uygunitem
{
    using System;
    using System.Collections.Generic;
    
    public partial class urunler
    {
        public int urun_id { get; set; }
        public string urun_isim { get; set; }
        public string urun_foto_path { get; set; }
        public Nullable<int> altkate_id { get; set; }
        public int üstkate_id { get; set; }
        public string urun_aciklama { get; set; }
        public string anahtar_kelimeler { get; set; }
    
        public virtual alt_kategoriler alt_kategoriler { get; set; }
        public virtual kategoriler kategoriler { get; set; }
    }
}
