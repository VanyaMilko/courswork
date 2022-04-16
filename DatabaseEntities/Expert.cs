//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseEntities
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Drawing;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    [Serializable]
    public partial class Expert : IEquatable<Expert>
    {
        public double RateWeight { get; set; }

        public int Id { get; set; }

        public string Password { get; set; }

        public string Login { get; set; }

        public Status UserStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rate> Rate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Expert()
        {
            Login = "empty";
            Password = "empty";
            UserStatus = Status.NotBanned;
            this.Rate = new HashSet<Rate>();
        }

        public Expert(string login, string password, double rateWeight = 0) : this()
        {
            RateWeight = rateWeight;
            Login = login;
            Password = password;
        }

        public bool Equals(Expert other)
        {
            return RateWeight == other.RateWeight && Login == other.Login
                && Password == other.Password && UserStatus == other.UserStatus;
        }
    }
}
