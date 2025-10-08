using System;
using System.Runtime.CompilerServices;

namespace TransientEventId
{
    //documentation comment for struct
    /// <summary>
    /// Represents a transient event identifier with an ID and a name.
    /// </summary>
    /// <summary>
    /// Identifies a logging event. This struct is designed to be API-compatible with <c>Microsoft.Extensions.Logging.EventId</c>,
    /// but avoids a direct dependency on the <c>Microsoft.Extensions.Logging.Abstractions</c> package.
    /// <para>
    /// The primary identifier is the <see cref="Id"/> property, with the <see cref="Name"/> property providing a short description of the event type.
    /// </para>
    /// <para>
    /// Use this struct when you want to represent logging event identifiers in a portable library or application
    /// without introducing a dependency on Microsoft.Extensions.Logging.Abstractions.
    /// </para>
    /// </summary>
    /// <remarks>
    /// This struct is intended as a drop-in replacement for <c>EventId</c> from the <c>Microsoft.Extensions.Logging</c> namespace.
    /// </remarks>
    public readonly struct TransientEventId : IEquatable<TransientEventId>
    {
        /// <summary>
        /// Gets the numeric identifier for this event.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the name of this event.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransientEventId"/> struct.
        /// </summary>
        /// <param name="id">The numeric identifier for the event.</param>
        /// <param name="name">The name or description of the event.</param>
        public TransientEventId(int id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Deconstructs the <see cref="TransientEventId"/> into its component values.
        /// </summary>
        /// <param name="id">The numeric identifier for the event.</param>
        /// <param name="name">The name or description of the event.</param>
        public void Deconstruct(out int id, out string name)
        {
            id = Id;
            name = Name;
        }


        /// <summary>
        /// Implicitly converts an integer to a <see cref="TransientEventId"/> with an empty name.
        /// </summary>
        /// <param name="value">The numeric identifier for the event.</param>
        /// <returns>A <see cref="TransientEventId"/> with the specified ID and an empty name.</returns>
        public static implicit operator TransientEventId(int value)
        {
            return new TransientEventId(value, string.Empty);
        }


        /// <summary>
        /// Implicitly converts a tuple of (int Id, string Name) to a <see cref="TransientEventId"/>.
        /// </summary>
        /// <param name="value">A tuple containing the event ID and name.</param>
        /// <returns>A <see cref="TransientEventId"/> with the specified ID and name.</returns>
        public static implicit operator TransientEventId((int Id, string Name) value)
        {
            return new TransientEventId(value.Id, value.Name);
        }


        /// <summary>
        /// Indicates whether the current <see cref="TransientEventId"/> is equal to another <see cref="TransientEventId"/>.
        /// </summary>
        /// <param name="other">The other <see cref="TransientEventId"/> to compare with.</param>
        /// <returns><c>true</c> if both have the same ID and name; otherwise, <c>false</c>.</returns>
        public bool Equals(TransientEventId other)
        {
            return Id == other.Id && string.Equals(Name, other.Name, StringComparison.Ordinal);
        }

        

        /// <summary>
        /// Determines whether the specified object is equal to the current <see cref="TransientEventId"/>.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns><c>true</c> if the specified object is a <see cref="TransientEventId"/> and is equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            return obj is TransientEventId eventId && Equals(eventId);
        }


        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for the current <see cref="TransientEventId"/>.</returns>
        public override int GetHashCode()
        {
            return Id;
        }
    }
}
