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
    
    public partial class Customers
    {
        public int ID_Customer { get; set; }
    
        public virtual Contract Contract { get; set; }
        public virtual Firm Firm { get; set; }
        public virtual Physical Physical { get; set; }
    }
}
