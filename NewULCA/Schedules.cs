//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewULCA
{
    using System;
    using System.Collections.Generic;
    
    public partial class Schedules
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Schedules()
        {
            this.Shows = new HashSet<Shows>();
        }
    
        public int ScheduledId { get; set; }
        public string Image { get; set; }
        public int ChannelId { get; set; }
        public System.DateTime AirDate { get; set; }
        public System.DateTime StarTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public System.TimeSpan LengthTimeSpan { get; set; }
        public int ShowId { get; set; }
        public int Sorting { get; set; }
        public virtual Channels Channels { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shows> Shows { get; set; }
    }
}
