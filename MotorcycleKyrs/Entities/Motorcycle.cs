//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MotorcycleKyrs.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Motorcycle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Motorcycle()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public int M_ID { get; set; }
        public int ID_Company { get; set; }
        public string M_Models { get; set; }
        public int M_Year_of_release { get; set; }
        public int M_Engine_capacity { get; set; }
        public int M_Maximum_speed { get; set; }
    
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}