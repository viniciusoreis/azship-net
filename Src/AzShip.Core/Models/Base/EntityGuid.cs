﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AzShip.Core.Models.Base
{
    public abstract class EntityGuid
    {

        public Guid Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as EntityGuid;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(EntityGuid a, EntityGuid b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(EntityGuid a, EntityGuid b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }

        public void SetId(Guid id)
        {
            this.Id = id;
        }
    }
}
