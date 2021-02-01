using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using IOTProject.DanhMuc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IOTProject.IOTProjectConsts;

namespace IOTProject.ThongTin
{
    public class ThongTin_ThietBi : FullAuditedEntity<long>, IMustHaveTenant
    {
        public virtual long IDTHIETBI { get; set; }
        [ForeignKey("IDTHIETBI")]
        public virtual DM_ThietBi THIETBI { get; set; }
        public virtual long IDTHONGTINQUANLY { get; set; }
        [ForeignKey("IDTHONGTINQUANLY")]
        public virtual DM_THONGTINQUANLY THONGTINQUANLY { get; set; }
        [StringLength(LimitTextLength.Length100)]
        public virtual string TRANGTHAI { get; set; }
        [StringLength(LimitTextLength.Length100)]
        public virtual string DESCRIPTION { get; set; }
        public int TenantId { get; set; }
    }
}
