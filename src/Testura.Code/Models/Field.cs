﻿using System;
using System.Collections.Generic;

namespace Testura.Code.Models
{
    /// <summary>
    /// Represent a class field.
    /// </summary>
    public class Field
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Field"/> class.
        /// </summary>
        /// <param name="name">Name of the field.</param>
        /// <param name="type">Type of the field.</param>
        /// <param name="modifiers">The fields modifiers.</param>
        /// <param name="attributes">The fields attributes.</param>
        public Field(
            string name,
            Type type,
            IEnumerable<Modifiers> modifiers = null,
            IEnumerable<Attribute> attributes = null)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            Name = name;
            Type = type;
            Modifiers = modifiers;
            Attributes = attributes;
        }

        /// <summary>
        /// Gets or sets the name of the field.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the field.
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        /// Gets or sets the modifier(s) of the field.
        /// </summary>
        public IEnumerable<Modifiers> Modifiers { get; set; }

        /// <summary>
        /// Gets or sets the attributes of the field.
        /// </summary>
        public IEnumerable<Attribute> Attributes { get; set; }
    }
}
