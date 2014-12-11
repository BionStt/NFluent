﻿#region File header
// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="ILabelBlock.cs" company="">
// //   Copyright 2014 Cyrille Dupuydauby, Thomas PIERRAIN
// //   Licensed under the Apache License, Version 2.0 (the "License");
// //   you may not use this file except in compliance with the License.
// //   You may obtain a copy of the License at
// //       http://www.apache.org/licenses/LICENSE-2.0
// //   Unless required by applicable law or agreed to in writing, software
// //   distributed under the License is distributed on an "AS IS" BASIS,
// //   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// //   See the License for the specific language governing permissions and
// //   limitations under the License.
// // </copyright>
// // --------------------------------------------------------------------------------------------------------------------
#endregion
namespace NFluent.Extensibility
{
    /// <summary>
    /// Interface for Label generator.
    /// </summary>
    internal interface ILabelBlock
    {
        /// <summary>
        /// Customs the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        string CustomMessage(string message);
    }

    internal class GenericLabelBlock : ILabelBlock
    {
        private string adjective;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericLabelBlock" /> class.
        /// </summary>
        /// <param name="adjective">The adjective.</param>
        /// <param name="namer">The entity naming logic.</param>
        public GenericLabelBlock(string adjective, EntityNamer namer)
        {
            this.adjective = adjective;
            this.EntityLogic = namer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericLabelBlock"/> class.
        /// </summary>
        public GenericLabelBlock()
        {
            this.adjective = string.Empty;
        }

        /// <summary>
        /// Gets or sets the entity logic.
        /// </summary>
        /// <value>
        /// The entity logic.
        /// </value>
        public EntityNamer EntityLogic { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0} {1}", this.Adjective(), this.EntityName());
        }

        /// <summary>
        /// Customs the message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public string CustomMessage(string message)
        {
            return string.Format(message ?? "The {0} {1}:", this.Adjective(), this.EntityName());
        }

        protected virtual string Adjective()
        {
            return this.adjective;
        }

        private string EntityName()
        {
            return this.EntityLogic == null ? "value" : this.EntityLogic.EntityName;
        }

        static public ILabelBlock BuildActualBlock(EntityNamer namer)
        {
            return new GenericLabelBlock("actual", namer);
        }

        static public ILabelBlock BuildCheckedBlock(EntityNamer namer)
        {
            return new GenericLabelBlock("checked", namer);
        }

        static public ILabelBlock BuildExpectedBlock(EntityNamer namer)
        {
            return new GenericLabelBlock("expected", namer);
        }

        static public ILabelBlock BuildGivenBlock(EntityNamer namer)
        {
            return new GenericLabelBlock("given", namer);
        }
    }
}