//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ElectronicShop
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contract()
        {
            this.Payment = new HashSet<Payment>();
        }
    
        public int ID_Contract { get; set; }
        public int ID_Employee { get; set; }
        public Nullable<int> ID_Customer { get; set; }
        public int ID_Tariff_Plan { get; set; }
        public int ID_Services { get; set; }
        public System.DateTime Date_Of_Signing { get; set; }
        public Nullable<decimal> Balance { get; set; }
    
        public virtual Closing_Contract Closing_Contract { get; set; }
        public virtual Additional_Services Additional_Services { get; set; }
        public virtual Customers Customers { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Tariff_Plan Tariff_Plan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
