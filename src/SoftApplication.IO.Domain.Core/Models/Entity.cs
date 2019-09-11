using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftApplication.IO.Domain.Core.Models
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        protected Entity()
        {
            _ValidationResult = new ValidationResult();
        }

        private Guid _Id;
        public Guid Id {
            get { return _Id; }
            protected set { _Id = value; }
        }

        public abstract bool IsValid();

        private ValidationResult _ValidationResult;
        public ValidationResult ValidationResult {
            get { return _ValidationResult; }
            protected set { _ValidationResult = value; }
        }        

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 987) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + "[ id = " + Id + "]";
        }
    }
}
