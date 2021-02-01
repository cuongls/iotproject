using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IOTProject.IOTProjectConsts;

namespace IOTProject.DanhMuc
{
    public class DM_TRAM : FullAuditedEntity<long>, IMustHaveTenant
    {
        public virtual long IDDONVI { get; set; }
        [ForeignKey("IDDONVI")]
        public virtual DM_DonVi DONVI { get; set; }
        [StringLength(LimitTextLength.Length100)]
        public virtual string NAME { get; set; }
        [StringLength(LimitTextLength.Length100)]
        public virtual string CODE { get; set; }
        [StringLength(LimitTextLength.Length500)]
        public virtual string ADDRESS { get; set; }
        [StringLength(LimitTextLength.Length500)]
        public virtual string DESCRIPTION { get; set; }
        public int TenantId { get; set; }
    }
}
