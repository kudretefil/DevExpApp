//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DXWebApplication1.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class BILDIRIM
    {
        public BILDIRIM()
        {
            this.BILDIRIM_KIMYASALLARI = new HashSet<BILDIRIM_KIMYASALLARI>();
        }
    
        public int BILDIRIM_ID { get; set; }
        public int FK_COB_TESIS_ID { get; set; }
        public System.DateTime TARIH { get; set; }
        public int FK_KATEGORI { get; set; }
        public string MADDE_METIN { get; set; }
        public bool YENI_FORMAT { get; set; }
        public bool GONDERILDI { get; set; }
    
        public virtual ICollection<BILDIRIM_KIMYASALLARI> BILDIRIM_KIMYASALLARI { get; set; }
    }
}
