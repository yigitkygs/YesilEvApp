namespace YesilEvAppYigit.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        public int RoleID { get; set; }

        [StringLength(50)]
        public string RoleType { get; set; }
    }
}
