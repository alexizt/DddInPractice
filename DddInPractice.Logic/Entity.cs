using System;
using System.Collections.Generic;
using System.Text;

namespace DddInPractice.Logic
{

    // No interface: Code duplication on implementation
    // Interfaces doesn't show proper relations between entities

    // Abstract Class: Relationship --> Is a
    public abstract class Entity:IEquatable<Entity>
    {
        public long Id { get; private set; }



        // Operators: Equality Methods
        #region Operators
        public bool Equals(Entity other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return false;

            if (GetType() != other.GetType())
                return false;

            if (Id == 0 || other.Id == 0)
                return false;

            return Id == other.Id;
        }


        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            return Equals(other);
        }


        // == Operator differs from equal because it accepts nulls
        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a,null) && ReferenceEquals(b,null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a==b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString()+Id).GetHashCode();
        }
        #endregion
    }
}
