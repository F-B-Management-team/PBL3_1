//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PBL3.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            this.DatMons = new HashSet<DatMon>();
            this.ThongTinHoaDons = new HashSet<ThongTinHoaDon>();
        }
    
        public string IDHoaDon { get; set; }
        public string IDBan { get; set; }
        public Nullable<System.DateTime> NgayXuat { get; set; }
        public Nullable<bool> TrangThai { get; set; }
        public Nullable<double> TongTien { get; set; }
        public string IDNguoiDung { get; set; }
        public string IDCustommer { get; set; }
        public string Note { get; set; }
    
        public virtual Ban Ban { get; set; }
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatMon> DatMons { get; set; }
        public virtual ThongTinNguoiDung ThongTinNguoiDung { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ThongTinHoaDon> ThongTinHoaDons { get; set; }
    }
}
